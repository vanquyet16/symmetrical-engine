using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using EmployeeManagement.Utils;

namespace EmployeeManagement.Forms
{
    public partial class PositionManagementForm : Form
    {
        private PositionDAL positionDAL;
        private EmployeeDAL employeeDAL;
        private List<Position> positions;
        private List<Employee> employees;

        public PositionManagementForm()
        {
            InitializeComponent();
            positionDAL = new PositionDAL();
            employeeDAL = new EmployeeDAL();
            LoadData();
            SetupPermissions();
        }

        private void LoadData()
        {
            try
            {
                positions = positionDAL.GetAllPositions();
                employees = employeeDAL.GetAllEmployees();

                LoadPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPositions()
        {
            dgvPositions.DataSource = positions;
            dgvPositions.Columns["PositionId"].Visible = false;
            dgvPositions.Columns["CreatedDate"].Visible = false;
        }

        private void SetupPermissions()
        {
            bool canEdit = CurrentUser.CanManagePositions;
            btnAdd.Enabled = canEdit;
            btnEdit.Enabled = canEdit;
            btnDelete.Enabled = canEdit;
            btnSave.Enabled = canEdit;
            btnCancel.Enabled = canEdit;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtPositionName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                var selectedPosition = (Position)dgvPositions.SelectedRows[0].DataBoundItem;
                LoadPositionToForm(selectedPosition);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                var selectedPosition = (Position)dgvPositions.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa chức vụ {selectedPosition.PositionName}?", 
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = positionDAL.DeletePosition(selectedPosition.PositionId);
                        if (success)
                        {
                            MessageBox.Show("Xóa chức vụ thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa chức vụ có nhân viên!", "Lỗi", 
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
                MessageBox.Show("Vui lòng chọn chức vụ cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    var position = GetPositionFromForm();
                    bool success;

                    if (position.PositionId == 0) // Add new
                    {
                        success = positionDAL.AddPosition(position);
                        if (success)
                        {
                            MessageBox.Show("Thêm chức vụ thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else // Update existing
                    {
                        success = positionDAL.UpdatePosition(position);
                        if (success)
                        {
                            MessageBox.Show("Cập nhật chức vụ thành công!", "Thông báo", 
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
            if (dgvPositions.SelectedRows.Count > 0)
            {
                var selectedPosition = (Position)dgvPositions.SelectedRows[0].DataBoundItem;
                try
                {
                    var positionEmployees = positionDAL.GetEmployeesByPosition(selectedPosition.PositionId);
                    var employeeForm = new PositionEmployeesForm(selectedPosition.PositionName, positionEmployees);
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
                MessageBox.Show("Vui lòng chọn chức vụ để xem nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadPositionToForm(Position position)
        {
            txtPositionName.Text = position.PositionName;
            txtDescription.Text = position.Description;
            numBaseSalary.Value = position.BaseSalary;
            chkIsActive.Checked = position.IsActive;
        }

        private Position GetPositionFromForm()
        {
            return new Position
            {
                PositionId = GetCurrentPositionId(),
                PositionName = txtPositionName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                BaseSalary = numBaseSalary.Value,
                IsActive = chkIsActive.Checked
            };
        }

        private int GetCurrentPositionId()
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                var selectedPosition = (Position)dgvPositions.SelectedRows[0].DataBoundItem;
                return selectedPosition.PositionId;
            }
            return 0;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtPositionName.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên chức vụ!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPositionName.Focus();
                return false;
            }

            if (numBaseSalary.Value <= 0)
            {
                MessageBox.Show("Lương cơ bản phải lớn hơn 0!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numBaseSalary.Focus();
                return false;
            }

            // Check if position name exists (for new positions)
            int currentId = GetCurrentPositionId();
            if (currentId == 0 && positionDAL.IsPositionNameExists(txtPositionName.Text.Trim()))
            {
                MessageBox.Show("Tên chức vụ đã tồn tại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPositionName.Focus();
                return false;
            }

            // Check if position name exists for other positions (for updates)
            if (currentId > 0 && positionDAL.IsPositionNameExists(txtPositionName.Text.Trim(), currentId))
            {
                MessageBox.Show("Tên chức vụ đã tồn tại!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPositionName.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtPositionName.Clear();
            txtDescription.Clear();
            numBaseSalary.Value = 0;
            chkIsActive.Checked = true;
        }
    }
}
