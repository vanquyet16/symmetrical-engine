using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EmployeeManagement.Database;
using EmployeeManagement.Models;

namespace EmployeeManagement.Forms
{
    /// <summary>
    /// Form quản lý chức vụ
    /// </summary>
    public partial class PositionForm : Form
    {
        private DataTable positionDataTable;
        
        public PositionForm()
        {
            InitializeComponent();
            InitializeDataTable();
            LoadPositions();
        }
        
        /// <summary>
        /// Khởi tạo DataTable cho danh sách chức vụ
        /// </summary>
        private void InitializeDataTable()
        {
            positionDataTable = new DataTable();
            positionDataTable.Columns.Add("ID", typeof(int));
            positionDataTable.Columns.Add("Tên chức vụ", typeof(string));
            positionDataTable.Columns.Add("Mô tả", typeof(string));
            positionDataTable.Columns.Add("Lương tối thiểu", typeof(decimal));
            positionDataTable.Columns.Add("Lương tối đa", typeof(decimal));
            positionDataTable.Columns.Add("Ngày tạo", typeof(DateTime));
            positionDataTable.Columns.Add("Trạng thái", typeof(string));
            
            dgvPositions.DataSource = positionDataTable;
        }
        
        /// <summary>
        /// Tải danh sách chức vụ
        /// </summary>
        private void LoadPositions()
        {
            try
            {
                positionDataTable.Clear();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "SELECT * FROM positions ORDER BY created_date DESC";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = positionDataTable.NewRow();
                            row["ID"] = reader.GetInt32("id");
                            row["Tên chức vụ"] = reader.GetString("name");
                            row["Mô tả"] = reader.IsDBNull("description") ? "" : reader.GetString("description");
                            row["Lương tối thiểu"] = reader.GetDecimal("min_salary");
                            row["Lương tối đa"] = reader.GetDecimal("max_salary");
                            row["Ngày tạo"] = reader.GetDateTime("created_date");
                            row["Trạng thái"] = reader.GetBoolean("is_active") ? "Hoạt động" : "Không hoạt động";
                            
                            positionDataTable.Rows.Add(row);
                        }
                    }
                }
                
                lblTotalPositions.Text = $"Tổng số chức vụ: {positionDataTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách chức vụ: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện thêm chức vụ
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chức vụ!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            
            if (numMinSalary.Value >= numMaxSalary.Value)
            {
                MessageBox.Show("Lương tối thiểu phải nhỏ hơn lương tối đa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMinSalary.Focus();
                return;
            }
            
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        INSERT INTO positions (name, description, min_salary, max_salary, created_date, is_active)
                        VALUES (@name, @description, @min_salary, @max_salary, NOW(), @active)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        command.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                        command.Parameters.AddWithValue("@min_salary", numMinSalary.Value);
                        command.Parameters.AddWithValue("@max_salary", numMaxSalary.Value);
                        command.Parameters.AddWithValue("@active", chkIsActive.Checked);
                        
                        command.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Thêm chức vụ thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearForm();
                LoadPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm chức vụ: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện sửa chức vụ
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chức vụ!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            
            if (numMinSalary.Value >= numMaxSalary.Value)
            {
                MessageBox.Show("Lương tối thiểu phải nhỏ hơn lương tối đa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMinSalary.Focus();
                return;
            }
            
            try
            {
                int positionId = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["ID"].Value);
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        UPDATE positions 
                        SET name = @name, description = @description, min_salary = @min_salary, 
                            max_salary = @max_salary, is_active = @active
                        WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", positionId);
                        command.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        command.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                        command.Parameters.AddWithValue("@min_salary", numMinSalary.Value);
                        command.Parameters.AddWithValue("@max_salary", numMaxSalary.Value);
                        command.Parameters.AddWithValue("@active", chkIsActive.Checked);
                        
                        command.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Cập nhật chức vụ thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearForm();
                LoadPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật chức vụ: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện xóa chức vụ
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa chức vụ này?", "Xác nhận xóa", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    int positionId = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["ID"].Value);
                    
                    using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                    {
                        connection.Open();
                        
                        // Kiểm tra xem chức vụ có nhân viên không
                        var checkQuery = "SELECT COUNT(*) FROM employees WHERE position_id = @id";
                        using (var checkCommand = new MySqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@id", positionId);
                            int employeeCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                            
                            if (employeeCount > 0)
                            {
                                MessageBox.Show("Không thể xóa chức vụ này vì còn nhân viên!", 
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        
                        // Xóa chức vụ
                        var deleteQuery = "DELETE FROM positions WHERE id = @id";
                        using (var deleteCommand = new MySqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@id", positionId);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                    
                    MessageBox.Show("Xóa chức vụ thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPositions();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa chức vụ: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện chọn chức vụ từ danh sách
        /// </summary>
        private void dgvPositions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count > 0)
            {
                var row = dgvPositions.SelectedRows[0];
                txtName.Text = row.Cells["Tên chức vụ"].Value.ToString();
                txtDescription.Text = row.Cells["Mô tả"].Value.ToString();
                numMinSalary.Value = Convert.ToDecimal(row.Cells["Lương tối thiểu"].Value);
                numMaxSalary.Value = Convert.ToDecimal(row.Cells["Lương tối đa"].Value);
                chkIsActive.Checked = row.Cells["Trạng thái"].Value.ToString() == "Hoạt động";
            }
        }
        
        /// <summary>
        /// Xóa form
        /// </summary>
        private void ClearForm()
        {
            txtName.Clear();
            txtDescription.Clear();
            numMinSalary.Value = 0;
            numMaxSalary.Value = 0;
            chkIsActive.Checked = true;
        }
        
        /// <summary>
        /// Xử lý sự kiện làm mới
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadPositions();
        }
    }
}
