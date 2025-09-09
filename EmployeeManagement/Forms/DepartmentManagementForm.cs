using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using EmployeeManagement.Utils;

namespace EmployeeManagement.Forms
{
    public partial class DepartmentManagementForm : Form
    {
        private DepartmentDAL departmentDAL;
        private EmployeeDAL employeeDAL;
        private List<Department> departments;
        private List<Employee> employees;

        public DepartmentManagementForm()
        {
            InitializeComponent();
            departmentDAL = new DepartmentDAL();
            employeeDAL = new EmployeeDAL();
            LoadData();
            SetupPermissions();
        }

        private void LoadData()
        {
            try
            {
                departments = departmentDAL.GetAllDepartments();
                employees = employeeDAL.GetAllEmployees();

                LoadDepartments();
                LoadManagerComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDepartments()
        {
            dgvDepartments.DataSource = departments;
            dgvDepartments.Columns["DepartmentId"].Visible = false;
            dgvDepartments.Columns["ManagerId"].Visible = false;
            dgvDepartments.Columns["CreatedDate"].Visible = false;
            dgvDepartments.Columns["UpdatedDate"].Visible = false;
        }

        private void LoadManagerComboBox()
        {
            cmbManager.DataSource = employees.Where(e => e.IsActive).ToList();
            cmbManager.DisplayMember = "FullName";
            cmbManager.ValueMember = "EmployeeId";
            cmbManager.SelectedIndex = -1;
        }

        private void SetupPermissions()
        {
            bool canEdit = CurrentUser.CanManageDepartments;
            btnAdd.Enabled = canEdit;
            btnEdit.Enabled = canEdit;
            btnDelete.Enabled = canEdit;
            btnSave.Enabled = canEdit;
            btnCancel.Enabled = canEdit;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtDepartmentName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count > 0)
            {
                var selectedDepartment = (Department)dgvDepartments.SelectedRows[0].DataBoundItem;
                LoadDepartmentToForm(selectedDepartment);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count > 0)
            {
                var selectedDepartment = (Department)dgvDepartments.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng ban {selectedDepartment.DepartmentName}?", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = departmentDAL.DeleteDepartment(selectedDepartment.DepartmentId);
                        if (success)
                        {
                            MessageBox.Show("Xóa phòng ban thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa phòng ban có nhân viên!", "Lỗi", 
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
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    var department = GetDepartmentFromForm();
                    bool success;

                    if (department.DepartmentId == 0) // Add new
                    {
                        success = departmentDAL.AddDepartment(department);
                        if (success)
                        {
                            MessageBox.Show("Thêm phòng ban thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // Update existing
                    {
                        success = departmentDAL.UpdateDepartment(department);
                        if (success)
                        {
                            MessageBox.Show("Cập nhật phòng ban thành công!", "Thông báo", 
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

        private void btnViewEmployees_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count > 0)
            {
                var selectedDepartment = (Department)dgvDepartments.SelectedRows[0].DataBoundItem;
                try
                {
                    var departmentEmployees = departmentDAL.GetEmployeesByDepartment(selectedDepartment.DepartmentId);
                    var employeeForm = new DepartmentEmployeesForm(selectedDepartment.DepartmentName, departmentEmployees);
                    employeeForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban để xem nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadDepartmentToForm(Department department)
        {
            txtDepartmentName.Text = department.DepartmentName;
            txtDescription.Text = department.Description;
            cmbManager.SelectedValue = department.ManagerId ?? -1;
            chkIsActive.Checked = department.IsActive;
        }

        private Department GetDepartmentFromForm()
        {
            return new Department
            {
                DepartmentId = GetCurrentDepartmentId(),
                DepartmentName = txtDepartmentName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                ManagerId = cmbManager.SelectedValue != null ? (int?)cmbManager.SelectedValue : null,
                IsActive = chkIsActive.Checked
            };
        }

        private int GetCurrentDepartmentId()
        {
            if (dgvDepartments.SelectedRows.Count > 0)
            {
                var selectedDepartment = (Department)dgvDepartments.SelectedRows[0].DataBoundItem;
                return selectedDepartment.DepartmentId;
            }
            return 0;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtDepartmentName.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên phòng ban!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepartmentName.Focus();
                return false;
            }

            // Check if department name exists (for new departments)
            int currentId = GetCurrentDepartmentId();
            if (currentId == 0 && departmentDAL.IsDepartmentNameExists(txtDepartmentName.Text.Trim()))
            {
                MessageBox.Show("Tên phòng ban đã tồn tại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepartmentName.Focus();
                return false;
            }

            // Check if department name exists for other departments (for updates)
            if (currentId > 0 && departmentDAL.IsDepartmentNameExists(txtDepartmentName.Text.Trim(), currentId))
            {
                MessageBox.Show("Tên phòng ban đã tồn tại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepartmentName.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtDepartmentName.Clear();
            txtDescription.Clear();
            cmbManager.SelectedIndex = -1;
            chkIsActive.Checked = true;
        }
    }
}
