namespace EmployeeManagement.Forms
{
    partial class ReportsForm
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

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDepartmentStats = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvPositionStats = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvSalaryReport = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvAttendanceReport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositionStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 550);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDepartmentStats);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(992, 522);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống kê phòng ban";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDepartmentStats
            // 
            this.dgvDepartmentStats.AllowUserToAddRows = false;
            this.dgvDepartmentStats.AllowUserToDeleteRows = false;
            this.dgvDepartmentStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartmentStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartmentStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartmentStats.Location = new System.Drawing.Point(3, 3);
            this.dgvDepartmentStats.Name = "dgvDepartmentStats";
            this.dgvDepartmentStats.ReadOnly = true;
            this.dgvDepartmentStats.Size = new System.Drawing.Size(986, 516);
            this.dgvDepartmentStats.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvPositionStats);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(992, 522);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thống kê chức vụ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvPositionStats
            // 
            this.dgvPositionStats.AllowUserToAddRows = false;
            this.dgvPositionStats.AllowUserToDeleteRows = false;
            this.dgvPositionStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPositionStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPositionStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPositionStats.Location = new System.Drawing.Point(3, 3);
            this.dgvPositionStats.Name = "dgvPositionStats";
            this.dgvPositionStats.ReadOnly = true;
            this.dgvPositionStats.Size = new System.Drawing.Size(986, 516);
            this.dgvPositionStats.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvSalaryReport);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(992, 522);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Báo cáo lương";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvSalaryReport
            // 
            this.dgvSalaryReport.AllowUserToAddRows = false;
            this.dgvSalaryReport.AllowUserToDeleteRows = false;
            this.dgvSalaryReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalaryReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalaryReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalaryReport.Location = new System.Drawing.Point(3, 3);
            this.dgvSalaryReport.Name = "dgvSalaryReport";
            this.dgvSalaryReport.ReadOnly = true;
            this.dgvSalaryReport.Size = new System.Drawing.Size(986, 516);
            this.dgvSalaryReport.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvAttendanceReport);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(992, 522);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Báo cáo chấm công";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvAttendanceReport
            // 
            this.dgvAttendanceReport.AllowUserToAddRows = false;
            this.dgvAttendanceReport.AllowUserToDeleteRows = false;
            this.dgvAttendanceReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendanceReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttendanceReport.Location = new System.Drawing.Point(3, 3);
            this.dgvAttendanceReport.Name = "dgvAttendanceReport";
            this.dgvAttendanceReport.ReadOnly = true;
            this.dgvAttendanceReport.Size = new System.Drawing.Size(986, 516);
            this.dgvAttendanceReport.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 550);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Green;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(200, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(50, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo và thống kê";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositionStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        //endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDepartmentStats;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvPositionStats;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvSalaryReport;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvAttendanceReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
    }
}
