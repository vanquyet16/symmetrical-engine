using EmployeeManagement.Utils;

namespace EmployeeManagement.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadUserInfo();
            SetupMenuPermissions();
        }

        private void LoadUserInfo()
        {
            if (CurrentUser.User != null)
            {
                lblWelcome.Text = $"Xin chào, {CurrentUser.User.Username} ({CurrentUser.User.RoleName})";
            }
        }

        private void SetupMenuPermissions()
        {
            // Ẩn/hiện menu theo quyền
            menuEmployeeManagement.Visible = CurrentUser.CanManageEmployees;
            menuDepartmentManagement.Visible = CurrentUser.CanManageDepartments;
            menuPositionManagement.Visible = CurrentUser.CanManagePositions;
            menuSalaryManagement.Visible = CurrentUser.CanManageSalary;
            menuReports.Visible = CurrentUser.CanViewReports;
        }

        private void menuEmployeeManagement_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeManagementForm();
            employeeForm.ShowDialog();
        }

        private void menuDepartmentManagement_Click(object sender, EventArgs e)
        {
            var departmentForm = new DepartmentManagementForm();
            departmentForm.ShowDialog();
        }

        private void menuPositionManagement_Click(object sender, EventArgs e)
        {
            var positionForm = new PositionManagementForm();
            positionForm.ShowDialog();
        }

        private void menuSalaryManagement_Click(object sender, EventArgs e)
        {
            var salaryForm = new SalaryManagementForm();
            salaryForm.ShowDialog();
        }

        private void menuReports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng báo cáo đang được phát triển!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuChangePassword_Click(object sender, EventArgs e)
        {
            var changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ShowDialog();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                CurrentUser.User = null;
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
