namespace EmployeeManagement.Forms
{
    partial class SalaryForm
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
            this.dgvSalaries = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIsPaid = new System.Windows.Forms.CheckBox();
            this.numTotalSalary = new System.Windows.Forms.NumericUpDown();
            this.lblTotalSalary = new System.Windows.Forms.Label();
            this.numTotalDays = new System.Windows.Forms.NumericUpDown();
            this.lblTotalDays = new System.Windows.Forms.Label();
            this.numWorkingDays = new System.Windows.Forms.NumericUpDown();
            this.lblWorkingDays = new System.Windows.Forms.Label();
            this.numAllowance = new System.Windows.Forms.NumericUpDown();
            this.lblAllowance = new System.Windows.Forms.Label();
            this.numSalaryCoefficient = new System.Windows.Forms.NumericUpDown();
            this.lblSalaryCoefficient = new System.Windows.Forms.Label();
            this.numBasicSalary = new System.Windows.Forms.NumericUpDown();
            this.lblBasicSalary = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.numMonth = new System.Windows.Forms.NumericUpDown();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnUpdatePayment = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTotalSalaries = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkingDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalaryCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasicSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalaries
            // 
            this.dgvSalaries.AllowUserToAddRows = false;
            this.dgvSalaries.AllowUserToDeleteRows = false;
            this.dgvSalaries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalaries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalaries.Location = new System.Drawing.Point(0, 300);
            this.dgvSalaries.Name = "dgvSalaries";
            this.dgvSalaries.ReadOnly = true;
            this.dgvSalaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalaries.Size = new System.Drawing.Size(1000, 300);
            this.dgvSalaries.TabIndex = 0;
            this.dgvSalaries.SelectionChanged += new System.EventHandler(this.dgvSalaries_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkIsPaid);
            this.panel1.Controls.Add(this.numTotalSalary);
            this.panel1.Controls.Add(this.lblTotalSalary);
            this.panel1.Controls.Add(this.numTotalDays);
            this.panel1.Controls.Add(this.lblTotalDays);
            this.panel1.Controls.Add(this.numWorkingDays);
            this.panel1.Controls.Add(this.lblWorkingDays);
            this.panel1.Controls.Add(this.numAllowance);
            this.panel1.Controls.Add(this.lblAllowance);
            this.panel1.Controls.Add(this.numSalaryCoefficient);
            this.panel1.Controls.Add(this.lblSalaryCoefficient);
            this.panel1.Controls.Add(this.numBasicSalary);
            this.panel1.Controls.Add(this.lblBasicSalary);
            this.panel1.Controls.Add(this.numYear);
            this.panel1.Controls.Add(this.lblYear);
            this.panel1.Controls.Add(this.numMonth);
            this.panel1.Controls.Add(this.lblMonth);
            this.panel1.Controls.Add(this.cmbEmployee);
            this.panel1.Controls.Add(this.lblEmployee);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 300);
            this.panel1.TabIndex = 1;
            // 
            // chkIsPaid
            // 
            this.chkIsPaid.AutoSize = true;
            this.chkIsPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkIsPaid.Location = new System.Drawing.Point(20, 250);
            this.chkIsPaid.Name = "chkIsPaid";
            this.chkIsPaid.Size = new System.Drawing.Size(120, 21);
            this.chkIsPaid.TabIndex = 19;
            this.chkIsPaid.Text = "Đã thanh toán";
            this.chkIsPaid.UseVisualStyleBackColor = true;
            // 
            // numTotalSalary
            // 
            this.numTotalSalary.DecimalPlaces = 0;
            this.numTotalSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numTotalSalary.Location = new System.Drawing.Point(450, 210);
            this.numTotalSalary.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numTotalSalary.Name = "numTotalSalary";
            this.numTotalSalary.ReadOnly = true;
            this.numTotalSalary.Size = new System.Drawing.Size(150, 23);
            this.numTotalSalary.TabIndex = 18;
            this.numTotalSalary.ThousandsSeparator = true;
            // 
            // lblTotalSalary
            // 
            this.lblTotalSalary.AutoSize = true;
            this.lblTotalSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSalary.ForeColor = System.Drawing.Color.Red;
            this.lblTotalSalary.Location = new System.Drawing.Point(350, 213);
            this.lblTotalSalary.Name = "lblTotalSalary";
            this.lblTotalSalary.Size = new System.Drawing.Size(80, 17);
            this.lblTotalSalary.TabIndex = 17;
            this.lblTotalSalary.Text = "Tổng lương:";
            // 
            // numTotalDays
            // 
            this.numTotalDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numTotalDays.Location = new System.Drawing.Point(130, 210);
            this.numTotalDays.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numTotalDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTotalDays.Name = "numTotalDays";
            this.numTotalDays.Size = new System.Drawing.Size(100, 23);
            this.numTotalDays.TabIndex = 16;
            this.numTotalDays.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblTotalDays
            // 
            this.lblTotalDays.AutoSize = true;
            this.lblTotalDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDays.Location = new System.Drawing.Point(20, 213);
            this.lblTotalDays.Name = "lblTotalDays";
            this.lblTotalDays.Size = new System.Drawing.Size(80, 17);
            this.lblTotalDays.TabIndex = 15;
            this.lblTotalDays.Text = "Tổng ngày:";
            // 
            // numWorkingDays
            // 
            this.numWorkingDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numWorkingDays.Location = new System.Drawing.Point(130, 170);
            this.numWorkingDays.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numWorkingDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWorkingDays.Name = "numWorkingDays";
            this.numWorkingDays.Size = new System.Drawing.Size(100, 23);
            this.numWorkingDays.TabIndex = 14;
            this.numWorkingDays.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // lblWorkingDays
            // 
            this.lblWorkingDays.AutoSize = true;
            this.lblWorkingDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWorkingDays.Location = new System.Drawing.Point(20, 173);
            this.lblWorkingDays.Name = "lblWorkingDays";
            this.lblWorkingDays.Size = new System.Drawing.Size(100, 17);
            this.lblWorkingDays.TabIndex = 13;
            this.lblWorkingDays.Text = "Số ngày làm:";
            // 
            // numAllowance
            // 
            this.numAllowance.DecimalPlaces = 0;
            this.numAllowance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numAllowance.Location = new System.Drawing.Point(450, 130);
            this.numAllowance.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numAllowance.Name = "numAllowance";
            this.numAllowance.Size = new System.Drawing.Size(150, 23);
            this.numAllowance.TabIndex = 12;
            this.numAllowance.ThousandsSeparator = true;
            // 
            // lblAllowance
            // 
            this.lblAllowance.AutoSize = true;
            this.lblAllowance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAllowance.Location = new System.Drawing.Point(350, 133);
            this.lblAllowance.Name = "lblAllowance";
            this.lblAllowance.Size = new System.Drawing.Size(70, 17);
            this.lblAllowance.TabIndex = 11;
            this.lblAllowance.Text = "Phụ cấp:";
            // 
            // numSalaryCoefficient
            // 
            this.numSalaryCoefficient.DecimalPlaces = 2;
            this.numSalaryCoefficient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numSalaryCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numSalaryCoefficient.Location = new System.Drawing.Point(130, 130);
            this.numSalaryCoefficient.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSalaryCoefficient.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSalaryCoefficient.Name = "numSalaryCoefficient";
            this.numSalaryCoefficient.Size = new System.Drawing.Size(100, 23);
            this.numSalaryCoefficient.TabIndex = 10;
            this.numSalaryCoefficient.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSalaryCoefficient
            // 
            this.lblSalaryCoefficient.AutoSize = true;
            this.lblSalaryCoefficient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSalaryCoefficient.Location = new System.Drawing.Point(20, 133);
            this.lblSalaryCoefficient.Name = "lblSalaryCoefficient";
            this.lblSalaryCoefficient.Size = new System.Drawing.Size(100, 17);
            this.lblSalaryCoefficient.TabIndex = 9;
            this.lblSalaryCoefficient.Text = "Hệ số lương:";
            // 
            // numBasicSalary
            // 
            this.numBasicSalary.DecimalPlaces = 0;
            this.numBasicSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numBasicSalary.Location = new System.Drawing.Point(130, 90);
            this.numBasicSalary.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numBasicSalary.Name = "numBasicSalary";
            this.numBasicSalary.Size = new System.Drawing.Size(150, 23);
            this.numBasicSalary.TabIndex = 8;
            this.numBasicSalary.ThousandsSeparator = true;
            // 
            // lblBasicSalary
            // 
            this.lblBasicSalary.AutoSize = true;
            this.lblBasicSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBasicSalary.Location = new System.Drawing.Point(20, 93);
            this.lblBasicSalary.Name = "lblBasicSalary";
            this.lblBasicSalary.Size = new System.Drawing.Size(90, 17);
            this.lblBasicSalary.TabIndex = 7;
            this.lblBasicSalary.Text = "Lương cơ bản:";
            // 
            // numYear
            // 
            this.numYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numYear.Location = new System.Drawing.Point(450, 50);
            this.numYear.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(100, 23);
            this.numYear.TabIndex = 6;
            this.numYear.Value = new decimal(new int[] {
            2024,
            0,
            0,
            0});
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblYear.Location = new System.Drawing.Point(350, 53);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(40, 17);
            this.lblYear.TabIndex = 5;
            this.lblYear.Text = "Năm:";
            // 
            // numMonth
            // 
            this.numMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMonth.Location = new System.Drawing.Point(130, 50);
            this.numMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMonth.Name = "numMonth";
            this.numMonth.Size = new System.Drawing.Size(100, 23);
            this.numMonth.TabIndex = 4;
            this.numMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMonth.Location = new System.Drawing.Point(20, 53);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(50, 17);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "Tháng:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(130, 10);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(300, 24);
            this.cmbEmployee.TabIndex = 2;
            this.cmbEmployee.SelectionChangeCommitted += new System.EventHandler(this.cmbEmployee_SelectionChangeCommitted);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmployee.Location = new System.Drawing.Point(20, 13);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(80, 17);
            this.lblEmployee.TabIndex = 1;
            this.lblEmployee.Text = "Nhân viên:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnUpdatePayment);
            this.panel2.Controls.Add(this.btnCalculate);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.lblTotalSalaries);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 550);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 50);
            this.panel2.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Green;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(800, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 30);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnUpdatePayment
            // 
            this.btnUpdatePayment.BackColor = System.Drawing.Color.Purple;
            this.btnUpdatePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdatePayment.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePayment.Location = new System.Drawing.Point(700, 10);
            this.btnUpdatePayment.Name = "btnUpdatePayment";
            this.btnUpdatePayment.Size = new System.Drawing.Size(90, 30);
            this.btnUpdatePayment.TabIndex = 4;
            this.btnUpdatePayment.Text = "Cập nhật TT";
            this.btnUpdatePayment.UseVisualStyleBackColor = false;
            this.btnUpdatePayment.Click += new System.EventHandler(this.btnUpdatePayment_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(600, 10);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(90, 30);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Tính lương";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(500, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(400, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTotalSalaries
            // 
            this.lblTotalSalaries.AutoSize = true;
            this.lblTotalSalaries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSalaries.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalSalaries.Location = new System.Drawing.Point(20, 15);
            this.lblTotalSalaries.Name = "lblTotalSalaries";
            this.lblTotalSalaries.Size = new System.Drawing.Size(150, 17);
            this.lblTotalSalaries.TabIndex = 0;
            this.lblTotalSalaries.Text = "Tổng số bảng lương: 0";
            // 
            // SalaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvSalaries);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "SalaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý lương";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaries)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkingDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalaryCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasicSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonth)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
        }

        //endregion

        private System.Windows.Forms.DataGridView dgvSalaries;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.NumericUpDown numMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblBasicSalary;
        private System.Windows.Forms.NumericUpDown numBasicSalary;
        private System.Windows.Forms.Label lblSalaryCoefficient;
        private System.Windows.Forms.NumericUpDown numSalaryCoefficient;
        private System.Windows.Forms.Label lblAllowance;
        private System.Windows.Forms.NumericUpDown numAllowance;
        private System.Windows.Forms.Label lblWorkingDays;
        private System.Windows.Forms.NumericUpDown numWorkingDays;
        private System.Windows.Forms.Label lblTotalDays;
        private System.Windows.Forms.NumericUpDown numTotalDays;
        private System.Windows.Forms.Label lblTotalSalary;
        private System.Windows.Forms.NumericUpDown numTotalSalary;
        private System.Windows.Forms.CheckBox chkIsPaid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalSalaries;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnUpdatePayment;
        private System.Windows.Forms.Button btnExport;
    }
}
