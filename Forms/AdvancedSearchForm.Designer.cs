namespace EmployeeManagement.Forms
{
    partial class AdvancedSearchForm
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
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblResults = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.numMaxSalary = new System.Windows.Forms.NumericUpDown();
            this.lblMaxSalary = new System.Windows.Forms.Label();
            this.numMinSalary = new System.Windows.Forms.NumericUpDown();
            this.lblMinSalary = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 200);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(1000, 400);
            this.dgvResults.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblResults);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.numMaxSalary);
            this.panel1.Controls.Add(this.lblMaxSalary);
            this.panel1.Controls.Add(this.numMinSalary);
            this.panel1.Controls.Add(this.lblMinSalary);
            this.panel1.Controls.Add(this.cmbPosition);
            this.panel1.Controls.Add(this.lblPosition);
            this.panel1.Controls.Add(this.cmbDepartment);
            this.panel1.Controls.Add(this.lblDepartment);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 200);
            this.panel1.TabIndex = 1;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblResults.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblResults.Location = new System.Drawing.Point(20, 170);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(150, 17);
            this.lblResults.TabIndex = 12;
            this.lblResults.Text = "Kết quả tìm kiếm: 0 nhân viên";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(200, 130);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Xóa";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(100, 130);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // numMaxSalary
            // 
            this.numMaxSalary.DecimalPlaces = 0;
            this.numMaxSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMaxSalary.Location = new System.Drawing.Point(450, 90);
            this.numMaxSalary.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numMaxSalary.Name = "numMaxSalary";
            this.numMaxSalary.Size = new System.Drawing.Size(150, 23);
            this.numMaxSalary.TabIndex = 9;
            this.numMaxSalary.ThousandsSeparator = true;
            // 
            // lblMaxSalary
            // 
            this.lblMaxSalary.AutoSize = true;
            this.lblMaxSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMaxSalary.Location = new System.Drawing.Point(350, 93);
            this.lblMaxSalary.Name = "lblMaxSalary";
            this.lblMaxSalary.Size = new System.Drawing.Size(100, 17);
            this.lblMaxSalary.TabIndex = 8;
            this.lblMaxSalary.Text = "Lương tối đa:";
            // 
            // numMinSalary
            // 
            this.numMinSalary.DecimalPlaces = 0;
            this.numMinSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMinSalary.Location = new System.Drawing.Point(130, 90);
            this.numMinSalary.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numMinSalary.Name = "numMinSalary";
            this.numMinSalary.Size = new System.Drawing.Size(150, 23);
            this.numMinSalary.TabIndex = 7;
            this.numMinSalary.ThousandsSeparator = true;
            // 
            // lblMinSalary
            // 
            this.lblMinSalary.AutoSize = true;
            this.lblMinSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMinSalary.Location = new System.Drawing.Point(20, 93);
            this.lblMinSalary.Name = "lblMinSalary";
            this.lblMinSalary.Size = new System.Drawing.Size(110, 17);
            this.lblMinSalary.TabIndex = 6;
            this.lblMinSalary.Text = "Lương tối thiểu:";
            // 
            // cmbPosition
            // 
            this.cmbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(450, 50);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(200, 24);
            this.cmbPosition.TabIndex = 5;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPosition.Location = new System.Drawing.Point(350, 53);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(70, 17);
            this.lblPosition.TabIndex = 4;
            this.lblPosition.Text = "Chức vụ:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(130, 50);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(200, 24);
            this.cmbDepartment.TabIndex = 3;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDepartment.Location = new System.Drawing.Point(20, 53);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(80, 17);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Phòng ban:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(130, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 23);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(20, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ tên:";
            // 
            // AdvancedSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.panel1);
            this.Name = "AdvancedSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm nâng cao";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSalary)).EndInit();
            this.ResumeLayout(false);
        }

        //endregion

        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblMinSalary;
        private System.Windows.Forms.NumericUpDown numMinSalary;
        private System.Windows.Forms.Label lblMaxSalary;
        private System.Windows.Forms.NumericUpDown numMaxSalary;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResults;
    }
}
