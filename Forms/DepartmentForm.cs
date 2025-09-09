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
    /// Form quản lý phòng ban
    /// </summary>
    public partial class DepartmentForm : Form
    {
        private DataTable departmentDataTable;
        private List<Employee> employees;
        
        public DepartmentForm()
        {
            InitializeComponent();
            InitializeDataTable();
            LoadEmployees();
            LoadDepartments();
        }
        
        /// <summary>
        /// Khởi tạo DataTable cho danh sách phòng ban
        /// </summary>
        private void InitializeDataTable()
        {
            departmentDataTable = new DataTable();
            departmentDataTable.Columns.Add("ID", typeof(int));
            departmentDataTable.Columns.Add("Tên phòng ban", typeof(string));
            departmentDataTable.Columns.Add("Mô tả", typeof(string));
            departmentDataTable.Columns.Add("Trưởng phòng", typeof(string));
            departmentDataTable.Columns.Add("Ngày tạo", typeof(DateTime));
            departmentDataTable.Columns.Add("Trạng thái", typeof(string));
            
            dgvDepartments.DataSource = departmentDataTable;
        }
        
        /// <summary>
        /// Tải danh sách nhân viên để chọn trưởng phòng
        /// </summary>
        private void LoadEmployees()
        {
            try
            {
                employees = new List<Employee>();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "SELECT id, full_name FROM employees WHERE is_active = TRUE ORDER BY full_name";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = reader.GetInt32("id"),
                                FullName = reader.GetString("full_name")
                            });
                        }
                    }
                }
                
                cmbManager.DataSource = employees;
                cmbManager.DisplayMember = "FullName";
                cmbManager.ValueMember = "Id";
                cmbManager.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách nhân viên: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Tải danh sách phòng ban
        /// </summary>
        private void LoadDepartments()
        {
            try
            {
                departmentDataTable.Clear();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT d.*, e.full_name as manager_name
                        FROM departments d
                        LEFT JOIN employees e ON d.manager_id = e.id
                        ORDER BY d.created_date DESC";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = departmentDataTable.NewRow();
                            row["ID"] = reader.GetInt32("id");
                            row["Tên phòng ban"] = reader.GetString("name");
                            row["Mô tả"] = reader.IsDBNull("description") ? "" : reader.GetString("description");
                            row["Trưởng phòng"] = reader.IsDBNull("manager_name") ? "" : reader.GetString("manager_name");
                            row["Ngày tạo"] = reader.GetDateTime("created_date");
                            row["Trạng thái"] = reader.GetBoolean("is_active") ? "Hoạt động" : "Không hoạt động";
                            
                            departmentDataTable.Rows.Add(row);
                        }
                    }
                }
                
                lblTotalDepartments.Text = $"Tổng số phòng ban: {departmentDataTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách phòng ban: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện thêm phòng ban
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng ban!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        INSERT INTO departments (name, description, manager_id, created_date, is_active)
                        VALUES (@name, @description, @manager_id, NOW(), @active)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        command.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                        command.Parameters.AddWithValue("@manager_id", cmbManager.SelectedValue ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@active", chkIsActive.Checked);
                        
                        command.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Thêm phòng ban thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearForm();
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm phòng ban: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện sửa phòng ban
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng ban!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            
            try
            {
                int departmentId = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells["ID"].Value);
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        UPDATE departments 
                        SET name = @name, description = @description, manager_id = @manager_id, is_active = @active
                        WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", departmentId);
                        command.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        command.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                        command.Parameters.AddWithValue("@manager_id", cmbManager.SelectedValue ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@active", chkIsActive.Checked);
                        
                        command.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Cập nhật phòng ban thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearForm();
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật phòng ban: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện xóa phòng ban
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng ban này?", "Xác nhận xóa", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    int departmentId = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells["ID"].Value);
                    
                    using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                    {
                        connection.Open();
                        
                        // Kiểm tra xem phòng ban có nhân viên không
                        var checkQuery = "SELECT COUNT(*) FROM employees WHERE department_id = @id";
                        using (var checkCommand = new MySqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@id", departmentId);
                            int employeeCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                            
                            if (employeeCount > 0)
                            {
                                MessageBox.Show("Không thể xóa phòng ban này vì còn nhân viên!", 
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        
                        // Xóa phòng ban
                        var deleteQuery = "DELETE FROM departments WHERE id = @id";
                        using (var deleteCommand = new MySqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@id", departmentId);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                    
                    MessageBox.Show("Xóa phòng ban thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDepartments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa phòng ban: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện chọn phòng ban từ danh sách
        /// </summary>
        private void dgvDepartments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count > 0)
            {
                var row = dgvDepartments.SelectedRows[0];
                txtName.Text = row.Cells["Tên phòng ban"].Value.ToString();
                txtDescription.Text = row.Cells["Mô tả"].Value.ToString();
                chkIsActive.Checked = row.Cells["Trạng thái"].Value.ToString() == "Hoạt động";
                
                // Tìm trưởng phòng
                string managerName = row.Cells["Trưởng phòng"].Value.ToString();
                if (!string.IsNullOrEmpty(managerName))
                {
                    var manager = employees.Find(e => e.FullName == managerName);
                    if (manager != null)
                    {
                        cmbManager.SelectedValue = manager.Id;
                    }
                }
                else
                {
                    cmbManager.SelectedIndex = -1;
                }
            }
        }
        
        /// <summary>
        /// Xóa form
        /// </summary>
        private void ClearForm()
        {
            txtName.Clear();
            txtDescription.Clear();
            cmbManager.SelectedIndex = -1;
            chkIsActive.Checked = true;
        }
        
        /// <summary>
        /// Xử lý sự kiện làm mới
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDepartments();
        }
    }
}
