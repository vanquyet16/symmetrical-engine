namespace EmployeeManagement.Forms
{
    partial class SalaryManagementForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCoefficient = new System.Windows.Forms.TabPage();
            this.lblCalculatedSalary = new System.Windows.Forms.Label();
            this.btnAddCoefficient = new System.Windows.Forms.Button();
            this.dtpEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.lblEffectiveDate = new System.Windows.Forms.Label();
            this.numAllowance = new System.Windows.Forms.NumericUpDown();
            this.lblAllowance = new System.Windows.Forms.Label();
            this.numCoefficient = new System.Windows.Forms.NumericUpDown();
            this.lblCoefficient = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblTitleCoefficient = new System.Windows.Forms.Label();
            this.tabPayroll = new System.Windows.Forms.TabPage();
            this.panelPayrollButtons = new System.Windows.Forms.Panel();
            this.btnApprovePayroll = new System.Windows.Forms.Button();
            this.btnSavePayroll = new System.Windows.Forms.Button();
            this.btnCalculateSalary = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelPayrollForm = new System.Windows.Forms.Panel();
            this.numNetSalary = new System.Windows.Forms.NumericUpDown();
            this.lblNetSalary = new System.Windows.Forms.Label();
            this.numInsurance = new System.Windows.Forms.NumericUpDown();
            this.lblInsurance = new System.Windows.Forms.Label();
            this.numTax = new System.Windows.Forms.NumericUpDown();
            this.lblTax = new System.Windows.Forms.Label();
            this.numGrossSalary = new System.Windows.Forms.NumericUpDown();
            this.lblGrossSalary = new System.Windows.Forms.Label();
            this.numOvertimePay = new System.Windows.Forms.NumericUpDown();
            this.lblOvertimePay = new System.Windows.Forms.Label();
            this.numOvertimeHoursPayroll = new System.Windows.Forms.NumericUpDown();
            this.lblOvertimeHoursPayroll = new System.Windows.Forms.Label();
            this.numWorkDaysPayroll = new System.Windows.Forms.NumericUpDown();
            this.lblWorkDaysPayroll = new System.Windows.Forms.Label();
            this.numAllowancePayroll = new System.Windows.Forms.NumericUpDown();
            this.lblAllowancePayroll = new System.Windows.Forms.Label();
            this.numCoefficientPayroll = new System.Windows.Forms.NumericUpDown();
            this.lblCoefficientPayroll = new System.Windows.Forms.Label();
            this.numBasicSalary = new System.Windows.Forms.NumericUpDown();
            this.lblBasicSalary = new System.Windows.Forms.Label();
            this.dtpPayPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.lblPayPeriodEnd = new System.Windows.Forms.Label();
            this.dtpPayPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.lblPayPeriodStart = new System.Windows.Forms.Label();
            this.numOvertimeHours = new System.Windows.Forms.NumericUpDown();
            this.lblOvertimeHours = new System.Windows.Forms.Label();
            this.numWorkDays = new System.Windows.Forms.NumericUpDown();
            this.lblWorkDays = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dgvPayrolls = new System.Windows.Forms.DataGridView();
            this.lblTitlePayroll = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabCoefficient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficient)).BeginInit();
            this.tabPayroll.SuspendLayout();
            this.panelPayrollButtons.SuspendLayout();
            this.panelPayrollForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNetSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsurance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGrossSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOvertimePay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOvertimeHoursPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkDaysPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAllowancePayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficientPayroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasicSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOvertimeHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayrolls)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCoefficient);
            this.tabControl1.Controls.Add(this.tabPayroll);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 700);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCoefficient
            // 
            this.tabCoefficient.Controls.Add(this.lblCalculatedSalary);
            this.tabCoefficient.Controls.Add(this.btnAddCoefficient);
            this.tabCoefficient.Controls.Add(this.dtpEffectiveDate);
            this.tabCoefficient.Controls.Add(this.lblEffectiveDate);
            this.tabCoefficient.Controls.Add(this.numAllowance);
            this.tabCoefficient.Controls.Add(this.lblAllowance);
            this.tabCoefficient.Controls.Add(this.numCoefficient);
            this.tabCoefficient.Controls.Add(this.lblCoefficient);
            this.tabCoefficient.Controls.Add(this.cmbEmployee);
            this.tabCoefficient.Controls.Add(this.lblEmployee);
            this.tabCoefficient.Controls.Add(this.lblTitleCoefficient);
            this.tabCoefficient.Location = new System.Drawing.Point(4, 24);
            this.tabCoefficient.Name = "tabCoefficient";
            this.tabCoefficient.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoefficient.Size = new System.Drawing.Size(1192, 672);
            this.tabCoefficient.TabIndex = 0;
            this.tabCoefficient.Text = "Quản lý hệ số lương";
            this.tabCoefficient.UseVisualStyleBackColor = true;
            // 
            // lblCalculatedSalary
            // 
            this.lblCalculatedSalary.AutoSize = true;
            this.lblCalculatedSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCalculatedSalary.ForeColor = System.Drawing.Color.Red;
            this.lblCalculatedSalary.Location = new System.Drawing.Point(300, 300);
            this.lblCalculatedSalary.Name = "lblCalculatedSalary";
            this.lblCalculatedSalary.Size = new System.Drawing.Size(200, 20);
            this.lblCalculatedSalary.TabIndex = 10;
            this.lblCalculatedSalary.Text = "Lương tính được: 0 VNĐ";
            this.lblCalculatedSalary.Visible = false;
            // 
            // btnAddCoefficient
            // 
            this.btnAddCoefficient.Location = new System.Drawing.Point(300, 250);
            this.btnAddCoefficient.Name = "btnAddCoefficient";
            this.btnAddCoefficient.Size = new System.Drawing.Size(120, 35);
            this.btnAddCoefficient.TabIndex = 9;
            this.btnAddCoefficient.Text = "Thêm hệ số lương";
            this.btnAddCoefficient.UseVisualStyleBackColor = true;
            this.btnAddCoefficient.Click += new System.EventHandler(this.btnAddCoefficient_Click);
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.Location = new System.Drawing.Point(300, 210);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEffectiveDate.TabIndex = 8;
            // 
            // lblEffectiveDate
            // 
            this.lblEffectiveDate.AutoSize = true;
            this.lblEffectiveDate.Location = new System.Drawing.Point(200, 213);
            this.lblEffectiveDate.Name = "lblEffectiveDate";
            this.lblEffectiveDate.Size = new System.Drawing.Size(80, 15);
            this.lblEffectiveDate.TabIndex = 7;
            this.lblEffectiveDate.Text = "Ngày hiệu lực:";
            // 
            // numAllowance
            // 
            this.numAllowance.DecimalPlaces = 2;
            this.numAllowance.Location = new System.Drawing.Point(300, 170);
            this.numAllowance.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numAllowance.Name = "numAllowance";
            this.numAllowance.Size = new System.Drawing.Size(200, 23);
            this.numAllowance.TabIndex = 6;
            this.numAllowance.ThousandsSeparator = true;
            // 
            // lblAllowance
            // 
            this.lblAllowance.AutoSize = true;
            this.lblAllowance.Location = new System.Drawing.Point(200, 173);
            this.lblAllowance.Name = "lblAllowance";
            this.lblAllowance.Size = new System.Drawing.Size(50, 15);
            this.lblAllowance.TabIndex = 5;
            this.lblAllowance.Text = "Phụ cấp:";
            // 
            // numCoefficient
            // 
            this.numCoefficient.DecimalPlaces = 2;
            this.numCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCoefficient.Location = new System.Drawing.Point(300, 130);
            this.numCoefficient.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoefficient.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCoefficient.Name = "numCoefficient";
            this.numCoefficient.Size = new System.Drawing.Size(200, 23);
            this.numCoefficient.TabIndex = 4;
            this.numCoefficient.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCoefficient
            // 
            this.lblCoefficient.AutoSize = true;
            this.lblCoefficient.Location = new System.Drawing.Point(200, 133);
            this.lblCoefficient.Name = "lblCoefficient";
            this.lblCoefficient.Size = new System.Drawing.Size(70, 15);
            this.lblCoefficient.TabIndex = 3;
            this.lblCoefficient.Text = "Hệ số lương:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(300, 90);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(300, 23);
            this.cmbEmployee.TabIndex = 2;
            this.cmbEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbEmployee_SelectedIndexChanged);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(200, 93);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(70, 15);
            this.lblEmployee.TabIndex = 1;
            this.lblEmployee.Text = "Nhân viên:";
            // 
            // lblTitleCoefficient
            // 
            this.lblTitleCoefficient.AutoSize = true;
            this.lblTitleCoefficient.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleCoefficient.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitleCoefficient.Location = new System.Drawing.Point(300, 30);
            this.lblTitleCoefficient.Name = "lblTitleCoefficient";
            this.lblTitleCoefficient.Size = new System.Drawing.Size(250, 26);
            this.lblTitleCoefficient.TabIndex = 0;
            this.lblTitleCoefficient.Text = "QUẢN LÝ HỆ SỐ LƯƠNG";
            // 
            // tabPayroll
            // 
            this.tabPayroll.Controls.Add(this.panelPayrollButtons);
            this.tabPayroll.Controls.Add(this.panelPayrollForm);
            this.tabPayroll.Controls.Add(this.dgvPayrolls);
            this.tabPayroll.Controls.Add(this.lblTitlePayroll);
            this.tabPayroll.Location = new System.Drawing.Point(4, 24);
            this.tabPayroll.Name = "tabPayroll";
            this.tabPayroll.Padding = new System.Windows.Forms.Padding(3);
            this.tabPayroll.Size = new System.Drawing.Size(1192, 672);
            this.tabPayroll.TabIndex = 1;
            this.tabPayroll.Text = "Quản lý bảng lương";
            this.tabPayroll.UseVisualStyleBackColor = true;
            // 
            // panelPayrollButtons
            // 
            this.panelPayrollButtons.Controls.Add(this.btnApprovePayroll);
            this.panelPayrollButtons.Controls.Add(this.btnSavePayroll);
            this.panelPayrollButtons.Controls.Add(this.btnCalculateSalary);
            this.panelPayrollButtons.Controls.Add(this.btnRefresh);
            this.panelPayrollButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPayrollButtons.Location = new System.Drawing.Point(3, 620);
            this.panelPayrollButtons.Name = "panelPayrollButtons";
            this.panelPayrollButtons.Size = new System.Drawing.Size(1186, 49);
            this.panelPayrollButtons.TabIndex = 3;
            // 
            // btnApprovePayroll
            // 
            this.btnApprovePayroll.Location = new System.Drawing.Point(300, 10);
            this.btnApprovePayroll.Name = "btnApprovePayroll";
            this.btnApprovePayroll.Size = new System.Drawing.Size(100, 30);
            this.btnApprovePayroll.TabIndex = 3;
            this.btnApprovePayroll.Text = "Duyệt lương";
            this.btnApprovePayroll.UseVisualStyleBackColor = true;
            this.btnApprovePayroll.Click += new System.EventHandler(this.btnApprovePayroll_Click);
            // 
            // btnSavePayroll
            // 
            this.btnSavePayroll.Location = new System.Drawing.Point(200, 10);
            this.btnSavePayroll.Name = "btnSavePayroll";
            this.btnSavePayroll.Size = new System.Drawing.Size(100, 30);
            this.btnSavePayroll.TabIndex = 2;
            this.btnSavePayroll.Text = "Lưu bảng lương";
            this.btnSavePayroll.UseVisualStyleBackColor = true;
            this.btnSavePayroll.Click += new System.EventHandler(this.btnSavePayroll_Click);
            // 
            // btnCalculateSalary
            // 
            this.btnCalculateSalary.Location = new System.Drawing.Point(100, 10);
            this.btnCalculateSalary.Name = "btnCalculateSalary";
            this.btnCalculateSalary.Size = new System.Drawing.Size(100, 30);
            this.btnCalculateSalary.TabIndex = 1;
            this.btnCalculateSalary.Text = "Tính lương";
            this.btnCalculateSalary.UseVisualStyleBackColor = true;
            this.btnCalculateSalary.Click += new System.EventHandler(this.btnCalculateSalary_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(10, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelPayrollForm
            // 
            this.panelPayrollForm.Controls.Add(this.numNetSalary);
            this.panelPayrollForm.Controls.Add(this.lblNetSalary);
            this.panelPayrollForm.Controls.Add(this.numInsurance);
            this.panelPayrollForm.Controls.Add(this.lblInsurance);
            this.panelPayrollForm.Controls.Add(this.numTax);
            this.panelPayrollForm.Controls.Add(this.lblTax);
            this.panelPayrollForm.Controls.Add(this.numGrossSalary);
            this.panelPayrollForm.Controls.Add(this.lblGrossSalary);
            this.panelPayrollForm.Controls.Add(this.numOvertimePay);
            this.panelPayrollForm.Controls.Add(this.lblOvertimePay);
            this.panelPayrollForm.Controls.Add(this.numOvertimeHoursPayroll);
            this.panelPayrollForm.Controls.Add(this.lblOvertimeHoursPayroll);
            this.panelPayrollForm.Controls.Add(this.numWorkDaysPayroll);
            this.panelPayrollForm.Controls.Add(this.lblWorkDaysPayroll);
            this.panelPayrollForm.Controls.Add(this.numAllowancePayroll);
            this.panelPayrollForm.Controls.Add(this.lblAllowancePayroll);
            this.panelPayrollForm.Controls.Add(this.numCoefficientPayroll);
            this.panelPayrollForm.Controls.Add(this.lblCoefficientPayroll);
            this.panelPayrollForm.Controls.Add(this.numBasicSalary);
            this.panelPayrollForm.Controls.Add(this.lblBasicSalary);
            this.panelPayrollForm.Controls.Add(this.dtpPayPeriodEnd);
            this.panelPayrollForm.Controls.Add(this.lblPayPeriodEnd);
            this.panelPayrollForm.Controls.Add(this.dtpPayPeriodStart);
            this.panelPayrollForm.Controls.Add(this.lblPayPeriodStart);
            this.panelPayrollForm.Controls.Add(this.numOvertimeHours);
            this.panelPayrollForm.Controls.Add(this.lblOvertimeHours);
            this.panelPayrollForm.Controls.Add(this.numWorkDays);
            this.panelPayrollForm.Controls.Add(this.lblWorkDays);
            this.panelPayrollForm.Controls.Add(this.dtpEndDate);
            this.panelPayrollForm.Controls.Add(this.lblEndDate);
            this.panelPayrollForm.Controls.Add(this.dtpStartDate);
            this.panelPayrollForm.Controls.Add(this.lblStartDate);
            this.panelPayrollForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPayrollForm.Location = new System.Drawing.Point(600, 3);
            this.panelPayrollForm.Name = "panelPayrollForm";
            this.panelPayrollForm.Size = new System.Drawing.Size(589, 617);
            this.panelPayrollForm.TabIndex = 2;
            // 
            // numNetSalary
            // 
            this.numNetSalary.DecimalPlaces = 2;
            this.numNetSalary.Location = new System.Drawing.Point(150, 550);
            this.numNetSalary.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numNetSalary.Name = "numNetSalary";
            this.numNetSalary.Size = new System.Drawing.Size(200, 23);
            this.numNetSalary.TabIndex = 31;
            this.numNetSalary.ThousandsSeparator = true;
            // 
            // lblNetSalary
            // 
            this.lblNetSalary.AutoSize = true;
            this.lblNetSalary.Location = new System.Drawing.Point(20, 553);
            this.lblNetSalary.Name = "lblNetSalary";
            this.lblNetSalary.Size = new System.Drawing.Size(70, 15);
            this.lblNetSalary.TabIndex = 30;
            this.lblNetSalary.Text = "Lương thực lĩnh:";
            // 
            // numInsurance
            // 
            this.numInsurance.DecimalPlaces = 2;
            this.numInsurance.Location = new System.Drawing.Point(150, 510);
            this.numInsurance.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numInsurance.Name = "numInsurance";
            this.numInsurance.Size = new System.Drawing.Size(200, 23);
            this.numInsurance.TabIndex = 29;
            this.numInsurance.ThousandsSeparator = true;
            // 
            // lblInsurance
            // 
            this.lblInsurance.AutoSize = true;
            this.lblInsurance.Location = new System.Drawing.Point(20, 513);
            this.lblInsurance.Name = "lblInsurance";
            this.lblInsurance.Size = new System.Drawing.Size(60, 15);
            this.lblInsurance.TabIndex = 28;
            this.lblInsurance.Text = "Bảo hiểm:";
            // 
            // numTax
            // 
            this.numTax.DecimalPlaces = 2;
            this.numTax.Location = new System.Drawing.Point(150, 470);
            this.numTax.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numTax.Name = "numTax";
            this.numTax.Size = new System.Drawing.Size(200, 23);
            this.numTax.TabIndex = 27;
            this.numTax.ThousandsSeparator = true;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(20, 473);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(40, 15);
            this.lblTax.TabIndex = 26;
            this.lblTax.Text = "Thuế:";
            // 
            // numGrossSalary
            // 
            this.numGrossSalary.DecimalPlaces = 2;
            this.numGrossSalary.Location = new System.Drawing.Point(150, 430);
            this.numGrossSalary.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numGrossSalary.Name = "numGrossSalary";
            this.numGrossSalary.Size = new System.Drawing.Size(200, 23);
            this.numGrossSalary.TabIndex = 25;
            this.numGrossSalary.ThousandsSeparator = true;
            // 
            // lblGrossSalary
            // 
            this.lblGrossSalary.AutoSize = true;
            this.lblGrossSalary.Location = new System.Drawing.Point(20, 433);
            this.lblGrossSalary.Name = "lblGrossSalary";
            this.lblGrossSalary.Size = new System.Drawing.Size(80, 15);
            this.lblGrossSalary.TabIndex = 24;
            this.lblGrossSalary.Text = "Tổng lương:";
            // 
            // numOvertimePay
            // 
            this.numOvertimePay.DecimalPlaces = 2;
            this.numOvertimePay.Location = new System.Drawing.Point(150, 390);
            this.numOvertimePay.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numOvertimePay.Name = "numOvertimePay";
            this.numOvertimePay.Size = new System.Drawing.Size(200, 23);
            this.numOvertimePay.TabIndex = 23;
            this.numOvertimePay.ThousandsSeparator = true;
            // 
            // lblOvertimePay
            // 
            this.lblOvertimePay.AutoSize = true;
            this.lblOvertimePay.Location = new System.Drawing.Point(20, 393);
            this.lblOvertimePay.Name = "lblOvertimePay";
            this.lblOvertimePay.Size = new System.Drawing.Size(100, 15);
            this.lblOvertimePay.TabIndex = 22;
            this.lblOvertimePay.Text = "Lương làm thêm:";
            // 
            // numOvertimeHoursPayroll
            // 
            this.numOvertimeHoursPayroll.DecimalPlaces = 2;
            this.numOvertimeHoursPayroll.Location = new System.Drawing.Point(150, 350);
            this.numOvertimeHoursPayroll.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numOvertimeHoursPayroll.Name = "numOvertimeHoursPayroll";
            this.numOvertimeHoursPayroll.Size = new System.Drawing.Size(200, 23);
            this.numOvertimeHoursPayroll.TabIndex = 21;
            // 
            // lblOvertimeHoursPayroll
            // 
            this.lblOvertimeHoursPayroll.AutoSize = true;
            this.lblOvertimeHoursPayroll.Location = new System.Drawing.Point(20, 353);
            this.lblOvertimeHoursPayroll.Name = "lblOvertimeHoursPayroll";
            this.lblOvertimeHoursPayroll.Size = new System.Drawing.Size(100, 15);
            this.lblOvertimeHoursPayroll.TabIndex = 20;
            this.lblOvertimeHoursPayroll.Text = "Giờ làm thêm:";
            // 
            // numWorkDaysPayroll
            // 
            this.numWorkDaysPayroll.Location = new System.Drawing.Point(150, 310);
            this.numWorkDaysPayroll.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numWorkDaysPayroll.Name = "numWorkDaysPayroll";
            this.numWorkDaysPayroll.Size = new System.Drawing.Size(200, 23);
            this.numWorkDaysPayroll.TabIndex = 19;
            // 
            // lblWorkDaysPayroll
            // 
            this.lblWorkDaysPayroll.AutoSize = true;
            this.lblWorkDaysPayroll.Location = new System.Drawing.Point(20, 313);
            this.lblWorkDaysPayroll.Name = "lblWorkDaysPayroll";
            this.lblWorkDaysPayroll.Size = new System.Drawing.Size(80, 15);
            this.lblWorkDaysPayroll.TabIndex = 18;
            this.lblWorkDaysPayroll.Text = "Số ngày công:";
            // 
            // numAllowancePayroll
            // 
            this.numAllowancePayroll.DecimalPlaces = 2;
            this.numAllowancePayroll.Location = new System.Drawing.Point(150, 270);
            this.numAllowancePayroll.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numAllowancePayroll.Name = "numAllowancePayroll";
            this.numAllowancePayroll.Size = new System.Drawing.Size(200, 23);
            this.numAllowancePayroll.TabIndex = 17;
            this.numAllowancePayroll.ThousandsSeparator = true;
            // 
            // lblAllowancePayroll
            // 
            this.lblAllowancePayroll.AutoSize = true;
            this.lblAllowancePayroll.Location = new System.Drawing.Point(20, 273);
            this.lblAllowancePayroll.Name = "lblAllowancePayroll";
            this.lblAllowancePayroll.Size = new System.Drawing.Size(50, 15);
            this.lblAllowancePayroll.TabIndex = 16;
            this.lblAllowancePayroll.Text = "Phụ cấp:";
            // 
            // numCoefficientPayroll
            // 
            this.numCoefficientPayroll.DecimalPlaces = 2;
            this.numCoefficientPayroll.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCoefficientPayroll.Location = new System.Drawing.Point(150, 230);
            this.numCoefficientPayroll.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCoefficientPayroll.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCoefficientPayroll.Name = "numCoefficientPayroll";
            this.numCoefficientPayroll.Size = new System.Drawing.Size(200, 23);
            this.numCoefficientPayroll.TabIndex = 15;
            this.numCoefficientPayroll.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCoefficientPayroll
            // 
            this.lblCoefficientPayroll.AutoSize = true;
            this.lblCoefficientPayroll.Location = new System.Drawing.Point(20, 233);
            this.lblCoefficientPayroll.Name = "lblCoefficientPayroll";
            this.lblCoefficientPayroll.Size = new System.Drawing.Size(70, 15);
            this.lblCoefficientPayroll.TabIndex = 14;
            this.lblCoefficientPayroll.Text = "Hệ số lương:";
            // 
            // numBasicSalary
            // 
            this.numBasicSalary.DecimalPlaces = 2;
            this.numBasicSalary.Location = new System.Drawing.Point(150, 190);
            this.numBasicSalary.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numBasicSalary.Name = "numBasicSalary";
            this.numBasicSalary.Size = new System.Drawing.Size(200, 23);
            this.numBasicSalary.TabIndex = 13;
            this.numBasicSalary.ThousandsSeparator = true;
            // 
            // lblBasicSalary
            // 
            this.lblBasicSalary.AutoSize = true;
            this.lblBasicSalary.Location = new System.Drawing.Point(20, 193);
            this.lblBasicSalary.Name = "lblBasicSalary";
            this.lblBasicSalary.Size = new System.Drawing.Size(80, 15);
            this.lblBasicSalary.TabIndex = 12;
            this.lblBasicSalary.Text = "Lương cơ bản:";
            // 
            // dtpPayPeriodEnd
            // 
            this.dtpPayPeriodEnd.Location = new System.Drawing.Point(150, 150);
            this.dtpPayPeriodEnd.Name = "dtpPayPeriodEnd";
            this.dtpPayPeriodEnd.Size = new System.Drawing.Size(200, 23);
            this.dtpPayPeriodEnd.TabIndex = 11;
            // 
            // lblPayPeriodEnd
            // 
            this.lblPayPeriodEnd.AutoSize = true;
            this.lblPayPeriodEnd.Location = new System.Drawing.Point(20, 153);
            this.lblPayPeriodEnd.Name = "lblPayPeriodEnd";
            this.lblPayPeriodEnd.Size = new System.Drawing.Size(100, 15);
            this.lblPayPeriodEnd.TabIndex = 10;
            this.lblPayPeriodEnd.Text = "Ngày kết thúc:";
            // 
            // dtpPayPeriodStart
            // 
            this.dtpPayPeriodStart.Location = new System.Drawing.Point(150, 110);
            this.dtpPayPeriodStart.Name = "dtpPayPeriodStart";
            this.dtpPayPeriodStart.Size = new System.Drawing.Size(200, 23);
            this.dtpPayPeriodStart.TabIndex = 9;
            // 
            // lblPayPeriodStart
            // 
            this.lblPayPeriodStart.AutoSize = true;
            this.lblPayPeriodStart.Location = new System.Drawing.Point(20, 113);
            this.lblPayPeriodStart.Name = "lblPayPeriodStart";
            this.lblPayPeriodStart.Size = new System.Drawing.Size(100, 15);
            this.lblPayPeriodStart.TabIndex = 8;
            this.lblPayPeriodStart.Text = "Ngày bắt đầu:";
            // 
            // numOvertimeHours
            // 
            this.numOvertimeHours.DecimalPlaces = 2;
            this.numOvertimeHours.Location = new System.Drawing.Point(150, 70);
            this.numOvertimeHours.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numOvertimeHours.Name = "numOvertimeHours";
            this.numOvertimeHours.Size = new System.Drawing.Size(200, 23);
            this.numOvertimeHours.TabIndex = 7;
            // 
            // lblOvertimeHours
            // 
            this.lblOvertimeHours.AutoSize = true;
            this.lblOvertimeHours.Location = new System.Drawing.Point(20, 73);
            this.lblOvertimeHours.Name = "lblOvertimeHours";
            this.lblOvertimeHours.Size = new System.Drawing.Size(100, 15);
            this.lblOvertimeHours.TabIndex = 6;
            this.lblOvertimeHours.Text = "Giờ làm thêm:";
            // 
            // numWorkDays
            // 
            this.numWorkDays.Location = new System.Drawing.Point(150, 30);
            this.numWorkDays.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numWorkDays.Name = "numWorkDays";
            this.numWorkDays.Size = new System.Drawing.Size(200, 23);
            this.numWorkDays.TabIndex = 5;
            // 
            // lblWorkDays
            // 
            this.lblWorkDays.AutoSize = true;
            this.lblWorkDays.Location = new System.Drawing.Point(20, 33);
            this.lblWorkDays.Name = "lblWorkDays";
            this.lblWorkDays.Size = new System.Drawing.Size(80, 15);
            this.lblWorkDays.TabIndex = 4;
            this.lblWorkDays.Text = "Số ngày công:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(100, 30);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 23);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(10, 33);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(60, 15);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "Đến ngày:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(100, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 23);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(10, 3);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(60, 15);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Từ ngày:";
            // 
            // dgvPayrolls
            // 
            this.dgvPayrolls.AllowUserToAddRows = false;
            this.dgvPayrolls.AllowUserToDeleteRows = false;
            this.dgvPayrolls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayrolls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayrolls.Location = new System.Drawing.Point(3, 3);
            this.dgvPayrolls.Name = "dgvPayrolls";
            this.dgvPayrolls.ReadOnly = true;
            this.dgvPayrolls.RowTemplate.Height = 25;
            this.dgvPayrolls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayrolls.Size = new System.Drawing.Size(597, 617);
            this.dgvPayrolls.TabIndex = 1;
            // 
            // lblTitlePayroll
            // 
            this.lblTitlePayroll.AutoSize = true;
            this.lblTitlePayroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitlePayroll.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitlePayroll.Location = new System.Drawing.Point(200, 10);
            this.lblTitlePayroll.Name = "lblTitlePayroll";
            this.lblTitlePayroll.Size = new System.Drawing.Size(250, 26);
            this.lblTitlePayroll.TabIndex = 0;
            this.lblTitlePayroll.Text = "QUẢN LÝ BẢNG LƯƠNG";
            // 
            // SalaryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl1);
            this.Name = "SalaryManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý lương";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabCoefficient.ResumeLayout(false);
            this.tabCoefficient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficient)).EndInit();
            this.tabPayroll.ResumeLayout(false);
            this.tabPayroll.PerformLayout();
            this.panelPayrollButtons.ResumeLayout(false);
            this.panelPayrollForm.ResumeLayout(false);
            this.panelPayrollForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNetSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsurance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGrossSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOvertimePay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOvertimeHoursPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkDaysPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAllowancePayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoefficientPayroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBasicSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOvertimeHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayrolls)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCoefficient;
        private System.Windows.Forms.TabPage tabPayroll;
        private System.Windows.Forms.Label lblTitleCoefficient;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.NumericUpDown numCoefficient;
        private System.Windows.Forms.Label lblCoefficient;
        private System.Windows.Forms.NumericUpDown numAllowance;
        private System.Windows.Forms.Label lblAllowance;
        private System.Windows.Forms.DateTimePicker dtpEffectiveDate;
        private System.Windows.Forms.Label lblEffectiveDate;
        private System.Windows.Forms.Button btnAddCoefficient;
        private System.Windows.Forms.Label lblCalculatedSalary;
        private System.Windows.Forms.Label lblTitlePayroll;
        private System.Windows.Forms.DataGridView dgvPayrolls;
        private System.Windows.Forms.Panel panelPayrollForm;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.NumericUpDown numWorkDays;
        private System.Windows.Forms.Label lblWorkDays;
        private System.Windows.Forms.NumericUpDown numOvertimeHours;
        private System.Windows.Forms.Label lblOvertimeHours;
        private System.Windows.Forms.DateTimePicker dtpPayPeriodStart;
        private System.Windows.Forms.Label lblPayPeriodStart;
        private System.Windows.Forms.DateTimePicker dtpPayPeriodEnd;
        private System.Windows.Forms.Label lblPayPeriodEnd;
        private System.Windows.Forms.NumericUpDown numBasicSalary;
        private System.Windows.Forms.Label lblBasicSalary;
        private System.Windows.Forms.NumericUpDown numCoefficientPayroll;
        private System.Windows.Forms.Label lblCoefficientPayroll;
        private System.Windows.Forms.NumericUpDown numAllowancePayroll;
        private System.Windows.Forms.Label lblAllowancePayroll;
        private System.Windows.Forms.NumericUpDown numWorkDaysPayroll;
        private System.Windows.Forms.Label lblWorkDaysPayroll;
        private System.Windows.Forms.NumericUpDown numOvertimeHoursPayroll;
        private System.Windows.Forms.Label lblOvertimeHoursPayroll;
        private System.Windows.Forms.NumericUpDown numOvertimePay;
        private System.Windows.Forms.Label lblOvertimePay;
        private System.Windows.Forms.NumericUpDown numGrossSalary;
        private System.Windows.Forms.Label lblGrossSalary;
        private System.Windows.Forms.NumericUpDown numTax;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.NumericUpDown numInsurance;
        private System.Windows.Forms.Label lblInsurance;
        private System.Windows.Forms.NumericUpDown numNetSalary;
        private System.Windows.Forms.Label lblNetSalary;
        private System.Windows.Forms.Panel panelPayrollButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCalculateSalary;
        private System.Windows.Forms.Button btnSavePayroll;
        private System.Windows.Forms.Button btnApprovePayroll;
    }
}
