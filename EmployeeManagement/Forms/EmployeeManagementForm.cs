using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using EmployeeManagement.Utils;

namespace EmployeeManagement.Forms
{
    public partial class EmployeeManagementForm : Form
    {
        private EmployeeDAL employeeDAL;
        private DepartmentDAL departmentDAL;
        private PositionDAL positionDAL;
        private List<Employee> employees;
        private List<Department> departments;
        private List<Position> positions;

        public EmployeeManagementForm()
        {
            InitializeComponent();
            employeeDAL = new EmployeeDAL();
            departmentDAL = new DepartmentDAL();
            positionDAL = new PositionDAL();
            LoadData();
            SetupPermissions();
        }

        private void LoadData()
        {
            try
            {
                employees = employeeDAL.GetAllEmployees();
                departments = departmentDAL.GetAllDepartments();
                positions = positionDAL.GetAllPositions();

                LoadEmployees();
                LoadComboBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployees()
        {
            dgvEmployees.DataSource = employees;
            dgvEmployees.Columns["EmployeeId"].Visible = false;
            dgvEmployees.Columns["DepartmentId"].Visible = false;
            dgvEmployees.Columns["PositionId"].Visible = false;
            dgvEmployees.Columns["CreatedDate"].Visible = false;
            dgvEmployees.Columns["UpdatedDate"].Visible = false;
        }

        private void LoadComboBoxes()
        {
            // Load departments
            cmbDepartment.DataSource = departments;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentId";
            cmbDepartment.SelectedIndex = -1;

            // Load positions
            cmbPosition.DataSource = positions;
            cmbPosition.DisplayMember = "PositionName";
            cmbPosition.ValueMember = "PositionId";
            cmbPosition.SelectedIndex = -1;

            // Load gender
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
        }

        private void SetupPermissions()
        {
            bool canEdit = CurrentUser.CanManageEmployees;
            btnAdd.Enabled = canEdit;
            btnEdit.Enabled = canEdit;
            btnDelete.Enabled = canEdit;
            btnSave.Enabled = canEdit;
            btnCancel.Enabled = canEdit;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtEmployeeCode.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var selectedEmployee = (Employee)dgvEmployees.SelectedRows[0].DataBoundItem;
                LoadEmployeeToForm(selectedEmployee);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var selectedEmployee = (Employee)dgvEmployees.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {selectedEmployee.FullName}?", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = employeeDAL.DeleteEmployee(selectedEmployee.EmployeeId);
                        if (success)
                        {
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi xóa nhân viên!", "Lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    var employee = GetEmployeeFromForm();
                    bool success;

                    if (employee.EmployeeId == 0) // Add new
                    {
                        success = employeeDAL.AddEmployee(employee);
                        if (success)
                        {
                            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // Update existing
                    {
                        success = employeeDAL.UpdateEmployee(employee);
                        if (success)
                        {
                            MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (success)
                    {
                        LoadData();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                try
                {
                    var searchResults = employeeDAL.SearchEmployees(searchTerm);
                    dgvEmployees.DataSource = searchResults;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LoadEmployees();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            txtSearch.Clear();
        }

        private void LoadEmployeeToForm(Employee employee)
        {
            txtEmployeeCode.Text = employee.EmployeeCode;
            txtFirstName.Text = employee.FirstName;
            txtLastName.Text = employee.LastName;
            txtEmail.Text = employee.Email;
            txtPhone.Text = employee.Phone;
            txtAddress.Text = employee.Address;
            dtpDateOfBirth.Value = employee.DateOfBirth ?? DateTime.Now.AddYears(-25);
            cmbGender.Text = employee.Gender;
            cmbDepartment.SelectedValue = employee.DepartmentId ?? -1;
            cmbPosition.SelectedValue = employee.PositionId ?? -1;
            dtpHireDate.Value = employee.HireDate;
            chkIsActive.Checked = employee.IsActive;
        }

        private Employee GetEmployeeFromForm()
        {
            return new Employee
            {
                EmployeeId = GetCurrentEmployeeId(),
                EmployeeCode = txtEmployeeCode.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                DateOfBirth = dtpDateOfBirth.Value.Date,
                Gender = cmbGender.Text,
                DepartmentId = cmbDepartment.SelectedValue != null ? (int?)cmbDepartment.SelectedValue : null,
                PositionId = cmbPosition.SelectedValue != null ? (int?)cmbPosition.SelectedValue : null,
                HireDate = dtpHireDate.Value.Date,
                IsActive = chkIsActive.Checked
            };
        }

        private int GetCurrentEmployeeId()
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                var selectedEmployee = (Employee)dgvEmployees.SelectedRows[0].DataBoundItem;
                return selectedEmployee.EmployeeId;
            }
            return 0;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtEmployeeCode.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập họ nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            // Check if employee code exists (for new employees)
            int currentId = GetCurrentEmployeeId();
            if (currentId == 0 && employeeDAL.IsEmployeeCodeExists(txtEmployeeCode.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }

            // Check if employee code exists for other employees (for updates)
            if (currentId > 0 && employeeDAL.IsEmployeeCodeExists(txtEmployeeCode.Text.Trim(), currentId))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtEmployeeCode.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-25);
            cmbGender.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            dtpHireDate.Value = DateTime.Now;
            chkIsActive.Checked = true;
        }
    }
}
