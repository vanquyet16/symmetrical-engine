namespace EmployeeManagement.Forms
{
    partial class PositionForm
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
            this.dgvPositions = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.numMaxSalary = new System.Windows.Forms.NumericUpDown();
            this.lblMaxSalary = new System.Windows.Forms.Label();
            this.numMinSalary = new System.Windows.Forms.NumericUpDown();
            this.lblMinSalary = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTotalPositions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSalary)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPositions
            // 
            this.dgvPositions.AllowUserToAddRows = false;
            this.dgvPositions.AllowUserToDeleteRows = false;
            this.dgvPositions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPositions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPositions.Location = new System.Drawing.Point(0, 200);
            this.dgvPositions.Name = "dgvPositions";
            this.dgvPositions.ReadOnly = true;
            this.dgvPositions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPositions.Size = new System.Drawing.Size(800, 400);
            this.dgvPositions.TabIndex = 0;
            this.dgvPositions.SelectionChanged += new System.EventHandler(this.dgvPositions_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkIsActive);
            this.panel1.Controls.Add(this.numMaxSalary);
            this.panel1.Controls.Add(this.lblMaxSalary);
            this.panel1.Controls.Add(this.numMinSalary);
            this.panel1.Controls.Add(this.lblMinSalary);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 200);
            this.panel1.TabIndex = 1;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkIsActive.Location = new System.Drawing.Point(20, 150);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(100, 21);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Đang hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // numMaxSalary
            // 
            this.numMaxSalary.DecimalPlaces = 0;
            this.numMaxSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMaxSalary.Location = new System.Drawing.Point(450, 110);
            this.numMaxSalary.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numMaxSalary.Name = "numMaxSalary";
            this.numMaxSalary.Size = new System.Drawing.Size(150, 23);
            this.numMaxSalary.TabIndex = 7;
            this.numMaxSalary.ThousandsSeparator = true;
            // 
            // lblMaxSalary
            // 
            this.lblMaxSalary.AutoSize = true;
            this.lblMaxSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMaxSalary.Location = new System.Drawing.Point(350, 113);
            this.lblMaxSalary.Name = "lblMaxSalary";
            this.lblMaxSalary.Size = new System.Drawing.Size(100, 17);
            this.lblMaxSalary.TabIndex = 6;
            this.lblMaxSalary.Text = "Lương tối đa:";
            // 
            // numMinSalary
            // 
            this.numMinSalary.DecimalPlaces = 0;
            this.numMinSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMinSalary.Location = new System.Drawing.Point(130, 110);
            this.numMinSalary.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numMinSalary.Name = "numMinSalary";
            this.numMinSalary.Size = new System.Drawing.Size(150, 23);
            this.numMinSalary.TabIndex = 5;
            this.numMinSalary.ThousandsSeparator = true;
            // 
            // lblMinSalary
            // 
            this.lblMinSalary.AutoSize = true;
            this.lblMinSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMinSalary.Location = new System.Drawing.Point(20, 113);
            this.lblMinSalary.Name = "lblMinSalary";
            this.lblMinSalary.Size = new System.Drawing.Size(110, 17);
            this.lblMinSalary.TabIndex = 4;
            this.lblMinSalary.Text = "Lương tối thiểu:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescription.Location = new System.Drawing.Point(130, 70);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(400, 30);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescription.Location = new System.Drawing.Point(20, 73);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(50, 17);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Mô tả:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtName.Location = new System.Drawing.Point(130, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 23);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(20, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên chức vụ:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.lblTotalPositions);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 550);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 50);
            this.panel2.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(600, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(510, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Orange;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(420, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(330, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTotalPositions
            // 
            this.lblTotalPositions.AutoSize = true;
            this.lblTotalPositions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalPositions.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTotalPositions.Location = new System.Drawing.Point(20, 15);
            this.lblTotalPositions.Name = "lblTotalPositions";
            this.lblTotalPositions.Size = new System.Drawing.Size(120, 17);
            this.lblTotalPositions.TabIndex = 0;
            this.lblTotalPositions.Text = "Tổng số chức vụ: 0";
            // 
            // PositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvPositions);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "PositionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý chức vụ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPositions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSalary)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
        }

        //endregion

        private System.Windows.Forms.DataGridView dgvPositions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblMinSalary;
        private System.Windows.Forms.NumericUpDown numMinSalary;
        private System.Windows.Forms.Label lblMaxSalary;
        private System.Windows.Forms.NumericUpDown numMaxSalary;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalPositions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
    }
}
