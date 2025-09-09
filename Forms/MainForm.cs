using System;
using System.Windows.Forms;
using EmployeeManagement.Models;

namespace EmployeeManagement.Forms
{
    /// <summary>
    /// Form chính của ứng dụng với menu và phân quyền
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeMenu();
        }
        
        /// <summary>
        /// Khởi tạo menu dựa trên quyền của user
        /// </summary>
        private void InitializeMenu()
        {
            if (LoginForm.CurrentUser != null)
            {
                // Hiển thị thông tin user
                lblWelcome.Text = $"Xin chào, {LoginForm.CurrentUser.FullName} ({LoginForm.CurrentUser.Role})";
                
                // Phân quyền menu
                if (LoginForm.CurrentUser.Role == "Admin")
                {
                    // Admin có đầy đủ quyền
                    EnableAllMenus();
                }
                else
                {
                    // User chỉ được xem
                    EnableViewOnlyMenus();
                }
            }
        }
        
        /// <summary>
        /// Kích hoạt tất cả menu cho Admin
        /// </summary>
        private void EnableAllMenus()
        {
            // Tất cả menu đều được kích hoạt
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.Enabled = true;
                foreach (ToolStripMenuItem subItem in item.DropDownItems)
                {
                    subItem.Enabled = true;
                }
            }
        }
        
        /// <summary>
        /// Chỉ kích hoạt menu xem cho User
        /// </summary>
        private void EnableViewOnlyMenus()
        {
            // Chỉ kích hoạt các menu xem
            employeeManagementToolStripMenuItem.Enabled = true;
            viewEmployeesToolStripMenuItem.Enabled = true;
            viewDepartmentsToolStripMenuItem.Enabled = true;
            viewPositionsToolStripMenuItem.Enabled = true;
            viewAttendanceToolStripMenuItem.Enabled = true;
            viewSalaryToolStripMenuItem.Enabled = true;
            reportsToolStripMenuItem.Enabled = true;
            searchToolStripMenuItem.Enabled = true;
            
            // Vô hiệu hóa các menu thêm/sửa/xóa
            addEmployeeToolStripMenuItem.Enabled = false;
            editEmployeeToolStripMenuItem.Enabled = false;
            deleteEmployeeToolStripMenuItem.Enabled = false;
            manageDepartmentsToolStripMenuItem.Enabled = false;
            managePositionsToolStripMenuItem.Enabled = false;
            manageAttendanceToolStripMenuItem.Enabled = false;
            manageSalaryToolStripMenuItem.Enabled = false;
            userManagementToolStripMenuItem.Enabled = false;
            backupRestoreToolStripMenuItem.Enabled = false;
        }
        
        /// <summary>
        /// Xử lý sự kiện đăng xuất
        /// </summary>
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                LoginForm.Logout();
                this.Hide();
                
                var loginForm = new LoginForm();
                loginForm.Show();
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện thoát ứng dụng
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        /// <summary>
        /// Xử lý sự kiện xem danh sách nhân viên
        /// </summary>
        private void viewEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EmployeeListForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện thêm nhân viên
        /// </summary>
        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EmployeeForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện quản lý phòng ban
        /// </summary>
        private void manageDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DepartmentForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện quản lý chức vụ
        /// </summary>
        private void managePositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PositionForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện quản lý chấm công
        /// </summary>
        private void manageAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AttendanceForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện quản lý lương
        /// </summary>
        private void manageSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SalaryForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện quản lý tài khoản
        /// </summary>
        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new UserManagementForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện tìm kiếm nâng cao
        /// </summary>
        private void advancedSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AdvancedSearchForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện báo cáo
        /// </summary>
        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ReportsForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện sao lưu và phục hồi
        /// </summary>
        private void backupRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new BackupRestoreForm();
            form.MdiParent = this;
            form.Show();
        }
        
        /// <summary>
        /// Xử lý sự kiện đóng form
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
