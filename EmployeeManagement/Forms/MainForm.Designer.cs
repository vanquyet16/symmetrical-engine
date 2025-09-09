namespace EmployeeManagement.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEmployeeManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDepartmentManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPositionManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalaryManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSystem,
            this.menuEmployeeManagement,
            this.menuDepartmentManagement,
            this.menuPositionManagement,
            this.menuSalaryManagement,
            this.menuReports});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuSystem
            // 
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChangePassword,
            this.menuLogout,
            this.toolStripSeparator1,
            this.menuExit});
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(57, 20);
            this.menuSystem.Text = "Hệ thống";
            // 
            // menuChangePassword
            // 
            this.menuChangePassword.Name = "menuChangePassword";
            this.menuChangePassword.Size = new System.Drawing.Size(180, 22);
            this.menuChangePassword.Text = "Đổi mật khẩu";
            this.menuChangePassword.Click += new System.EventHandler(this.menuChangePassword_Click);
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(180, 22);
            this.menuLogout.Text = "Đăng xuất";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(180, 22);
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuEmployeeManagement
            // 
            this.menuEmployeeManagement.Name = "menuEmployeeManagement";
            this.menuEmployeeManagement.Size = new System.Drawing.Size(100, 20);
            this.menuEmployeeManagement.Text = "Quản lý nhân viên";
            this.menuEmployeeManagement.Click += new System.EventHandler(this.menuEmployeeManagement_Click);
            // 
            // menuDepartmentManagement
            // 
            this.menuDepartmentManagement.Name = "menuDepartmentManagement";
            this.menuDepartmentManagement.Size = new System.Drawing.Size(100, 20);
            this.menuDepartmentManagement.Text = "Quản lý phòng ban";
            this.menuDepartmentManagement.Click += new System.EventHandler(this.menuDepartmentManagement_Click);
            // 
            // menuPositionManagement
            // 
            this.menuPositionManagement.Name = "menuPositionManagement";
            this.menuPositionManagement.Size = new System.Drawing.Size(100, 20);
            this.menuPositionManagement.Text = "Quản lý chức vụ";
            this.menuPositionManagement.Click += new System.EventHandler(this.menuPositionManagement_Click);
            // 
            // menuSalaryManagement
            // 
            this.menuSalaryManagement.Name = "menuSalaryManagement";
            this.menuSalaryManagement.Size = new System.Drawing.Size(100, 20);
            this.menuSalaryManagement.Text = "Quản lý lương";
            this.menuSalaryManagement.Click += new System.EventHandler(this.menuSalaryManagement_Click);
            // 
            // menuReports
            // 
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(60, 20);
            this.menuReports.Text = "Báo cáo";
            this.menuReports.Click += new System.EventHandler(this.menuReports_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome});
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(39, 17);
            this.lblWelcome.Text = "Xin chào";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.LightBlue;
            this.panelMain.Controls.Add(this.lblMainTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1000, 554);
            this.panelMain.TabIndex = 2;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMainTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMainTitle.Location = new System.Drawing.Point(300, 250);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(400, 37);
            this.lblMainTitle.TabIndex = 0;
            this.lblMainTitle.Text = "HỆ THỐNG QUẢN LÝ NHÂN VIÊN";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuEmployeeManagement;
        private System.Windows.Forms.ToolStripMenuItem menuDepartmentManagement;
        private System.Windows.Forms.ToolStripMenuItem menuPositionManagement;
        private System.Windows.Forms.ToolStripMenuItem menuSalaryManagement;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblMainTitle;
    }
}
