namespace EmployeeManagement.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDepartmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDepartmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.employeeManagementToolStripMenuItem,
            this.departmentManagementToolStripMenuItem,
            this.positionManagementToolStripMenuItem,
            this.attendanceManagementToolStripMenuItem,
            this.salaryManagementToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.userManagementToolStripMenuItem,
            this.backupRestoreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "Hệ thống";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.logoutToolStripMenuItem.Text = "Đăng xuất";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Thoát";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // employeeManagementToolStripMenuItem
            // 
            this.employeeManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewEmployeesToolStripMenuItem,
            this.addEmployeeToolStripMenuItem,
            this.editEmployeeToolStripMenuItem,
            this.deleteEmployeeToolStripMenuItem});
            this.employeeManagementToolStripMenuItem.Name = "employeeManagementToolStripMenuItem";
            this.employeeManagementToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.employeeManagementToolStripMenuItem.Text = "Quản lý nhân viên";
            // 
            // viewEmployeesToolStripMenuItem
            // 
            this.viewEmployeesToolStripMenuItem.Name = "viewEmployeesToolStripMenuItem";
            this.viewEmployeesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewEmployeesToolStripMenuItem.Text = "Xem danh sách";
            this.viewEmployeesToolStripMenuItem.Click += new System.EventHandler(this.viewEmployeesToolStripMenuItem_Click);
            // 
            // addEmployeeToolStripMenuItem
            // 
            this.addEmployeeToolStripMenuItem.Name = "addEmployeeToolStripMenuItem";
            this.addEmployeeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.addEmployeeToolStripMenuItem.Text = "Thêm nhân viên";
            this.addEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addEmployeeToolStripMenuItem_Click);
            // 
            // editEmployeeToolStripMenuItem
            // 
            this.editEmployeeToolStripMenuItem.Name = "editEmployeeToolStripMenuItem";
            this.editEmployeeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.editEmployeeToolStripMenuItem.Text = "Sửa nhân viên";
            // 
            // deleteEmployeeToolStripMenuItem
            // 
            this.deleteEmployeeToolStripMenuItem.Name = "deleteEmployeeToolStripMenuItem";
            this.deleteEmployeeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.deleteEmployeeToolStripMenuItem.Text = "Xóa nhân viên";
            // 
            // departmentManagementToolStripMenuItem
            // 
            this.departmentManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDepartmentsToolStripMenuItem,
            this.manageDepartmentsToolStripMenuItem});
            this.departmentManagementToolStripMenuItem.Name = "departmentManagementToolStripMenuItem";
            this.departmentManagementToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.departmentManagementToolStripMenuItem.Text = "Quản lý phòng ban";
            // 
            // viewDepartmentsToolStripMenuItem
            // 
            this.viewDepartmentsToolStripMenuItem.Name = "viewDepartmentsToolStripMenuItem";
            this.viewDepartmentsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewDepartmentsToolStripMenuItem.Text = "Xem phòng ban";
            // 
            // manageDepartmentsToolStripMenuItem
            // 
            this.manageDepartmentsToolStripMenuItem.Name = "manageDepartmentsToolStripMenuItem";
            this.manageDepartmentsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.manageDepartmentsToolStripMenuItem.Text = "Quản lý phòng ban";
            this.manageDepartmentsToolStripMenuItem.Click += new System.EventHandler(this.manageDepartmentsToolStripMenuItem_Click);
            // 
            // positionManagementToolStripMenuItem
            // 
            this.positionManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPositionsToolStripMenuItem,
            this.managePositionsToolStripMenuItem});
            this.positionManagementToolStripMenuItem.Name = "positionManagementToolStripMenuItem";
            this.positionManagementToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.positionManagementToolStripMenuItem.Text = "Quản lý chức vụ";
            // 
            // viewPositionsToolStripMenuItem
            // 
            this.viewPositionsToolStripMenuItem.Name = "viewPositionsToolStripMenuItem";
            this.viewPositionsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewPositionsToolStripMenuItem.Text = "Xem chức vụ";
            // 
            // managePositionsToolStripMenuItem
            // 
            this.managePositionsToolStripMenuItem.Name = "managePositionsToolStripMenuItem";
            this.managePositionsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.managePositionsToolStripMenuItem.Text = "Quản lý chức vụ";
            this.managePositionsToolStripMenuItem.Click += new System.EventHandler(this.managePositionsToolStripMenuItem_Click);
            // 
            // attendanceManagementToolStripMenuItem
            // 
            this.attendanceManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAttendanceToolStripMenuItem,
            this.manageAttendanceToolStripMenuItem});
            this.attendanceManagementToolStripMenuItem.Name = "attendanceManagementToolStripMenuItem";
            this.attendanceManagementToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.attendanceManagementToolStripMenuItem.Text = "Quản lý chấm công";
            // 
            // viewAttendanceToolStripMenuItem
            // 
            this.viewAttendanceToolStripMenuItem.Name = "viewAttendanceToolStripMenuItem";
            this.viewAttendanceToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewAttendanceToolStripMenuItem.Text = "Xem chấm công";
            // 
            // manageAttendanceToolStripMenuItem
            // 
            this.manageAttendanceToolStripMenuItem.Name = "manageAttendanceToolStripMenuItem";
            this.manageAttendanceToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.manageAttendanceToolStripMenuItem.Text = "Quản lý chấm công";
            this.manageAttendanceToolStripMenuItem.Click += new System.EventHandler(this.manageAttendanceToolStripMenuItem_Click);
            // 
            // salaryManagementToolStripMenuItem
            // 
            this.salaryManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSalaryToolStripMenuItem,
            this.manageSalaryToolStripMenuItem});
            this.salaryManagementToolStripMenuItem.Name = "salaryManagementToolStripMenuItem";
            this.salaryManagementToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.salaryManagementToolStripMenuItem.Text = "Quản lý lương";
            // 
            // viewSalaryToolStripMenuItem
            // 
            this.viewSalaryToolStripMenuItem.Name = "viewSalaryToolStripMenuItem";
            this.viewSalaryToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewSalaryToolStripMenuItem.Text = "Xem bảng lương";
            // 
            // manageSalaryToolStripMenuItem
            // 
            this.manageSalaryToolStripMenuItem.Name = "manageSalaryToolStripMenuItem";
            this.manageSalaryToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.manageSalaryToolStripMenuItem.Text = "Quản lý lương";
            this.manageSalaryToolStripMenuItem.Click += new System.EventHandler(this.manageSalaryToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.reportsToolStripMenuItem.Text = "Báo cáo";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedSearchToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.searchToolStripMenuItem.Text = "Tìm kiếm";
            // 
            // advancedSearchToolStripMenuItem
            // 
            this.advancedSearchToolStripMenuItem.Name = "advancedSearchToolStripMenuItem";
            this.advancedSearchToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.advancedSearchToolStripMenuItem.Text = "Tìm kiếm nâng cao";
            this.advancedSearchToolStripMenuItem.Click += new System.EventHandler(this.advancedSearchToolStripMenuItem_Click);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.userManagementToolStripMenuItem.Text = "Quản lý tài khoản";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.backupRestoreToolStripMenuItem.Text = "Sao lưu & Phục hồi";
            this.backupRestoreToolStripMenuItem.Click += new System.EventHandler(this.backupRestoreToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome});
            this.statusStrip1.Location = new System.Drawing.Point(0, 728);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(39, 17);
            this.lblWelcome.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDepartmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDepartmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewPositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupRestoreToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
    }
}
