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
    /// Form hiển thị danh sách nhân viên
    /// </summary>
    public partial class EmployeeListForm : Form
    {
        private DataTable employeeDataTable;
        
        public EmployeeListForm()
        {
            InitializeComponent();
            InitializeDataTable();
            LoadEmployees();
        }
        
        /// <summary>
        /// Khởi tạo DataTable cho danh sách nhân viên
        /// </summary>
        private void InitializeDataTable()
        {
            employeeDataTable = new DataTable();
            employeeDataTable.Columns.Add("ID", typeof(int));
            employeeDataTable.Columns.Add("Mã NV", typeof(string));
            employeeDataTable.Columns.Add("Họ tên", typeof(string));
            employeeDataTable.Columns.Add("Ngày sinh", typeof(DateTime));
            employeeDataTable.Columns.Add("Giới tính", typeof(string));
            employeeDataTable.Columns.Add("Địa chỉ", typeof(string));
            employeeDataTable.Columns.Add("SĐT", typeof(string));
            employeeDataTable.Columns.Add("Email", typeof(string));
            employeeDataTable.Columns.Add("Phòng ban", typeof(string));
            employeeDataTable.Columns.Add("Chức vụ", typeof(string));
            employeeDataTable.Columns.Add("Ngày vào làm", typeof(DateTime));
            employeeDataTable.Columns.Add("Lương cơ bản", typeof(decimal));
            employeeDataTable.Columns.Add("Hệ số lương", typeof(decimal));
            employeeDataTable.Columns.Add("Phụ cấp", typeof(decimal));
            employeeDataTable.Columns.Add("Trạng thái", typeof(string));
            
            dgvEmployees.DataSource = employeeDataTable;
        }
        
        /// <summary>
        /// Tải danh sách nhân viên từ database
        /// </summary>
        private void LoadEmployees()
        {
            try
            {
                employeeDataTable.Clear();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT e.*, d.name as department_name, p.name as position_name
                        FROM employees e
                        LEFT JOIN departments d ON e.department_id = d.id
                        LEFT JOIN positions p ON e.position_id = p.id
                        ORDER BY e.created_date DESC";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = employeeDataTable.NewRow();
                            row["ID"] = reader.GetInt32("id");
                            row["Mã NV"] = reader.GetString("employee_code");
                            row["Họ tên"] = reader.GetString("full_name");
                            row["Ngày sinh"] = reader.GetDateTime("date_of_birth");
                            row["Giới tính"] = reader.GetString("gender");
                            row["Địa chỉ"] = reader.IsDBNull("address") ? "" : reader.GetString("address");
                            row["SĐT"] = reader.IsDBNull("phone_number") ? "" : reader.GetString("phone_number");
                            row["Email"] = reader.IsDBNull("email") ? "" : reader.GetString("email");
                            row["Phòng ban"] = reader.IsDBNull("department_name") ? "" : reader.GetString("department_name");
                            row["Chức vụ"] = reader.IsDBNull("position_name") ? "" : reader.GetString("position_name");
                            row["Ngày vào làm"] = reader.GetDateTime("start_date");
                            row["Lương cơ bản"] = reader.GetDecimal("basic_salary");
                            row["Hệ số lương"] = reader.GetDecimal("salary_coefficient");
                            row["Phụ cấp"] = reader.GetDecimal("allowance");
                            row["Trạng thái"] = reader.GetBoolean("is_active") ? "Hoạt động" : "Không hoạt động";
                            
                            employeeDataTable.Rows.Add(row);
                        }
                    }
                }
                
                lblTotalEmployees.Text = $"Tổng số nhân viên: {employeeDataTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách nhân viên: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện tìm kiếm nhân viên
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            
            if (string.IsNullOrEmpty(searchText))
            {
                LoadEmployees();
                return;
            }
            
            try
            {
                employeeDataTable.Clear();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT e.*, d.name as department_name, p.name as position_name
                        FROM employees e
                        LEFT JOIN departments d ON e.department_id = d.id
                        LEFT JOIN positions p ON e.position_id = p.id
                        WHERE LOWER(e.employee_code) LIKE @search 
                           OR LOWER(e.full_name) LIKE @search
                           OR LOWER(d.name) LIKE @search
                        ORDER BY e.created_date DESC";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@search", $"%{searchText}%");
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = employeeDataTable.NewRow();
                                row["ID"] = reader.GetInt32("id");
                                row["Mã NV"] = reader.GetString("employee_code");
                                row["Họ tên"] = reader.GetString("full_name");
                                row["Ngày sinh"] = reader.GetDateTime("date_of_birth");
                                row["Giới tính"] = reader.GetString("gender");
                                row["Địa chỉ"] = reader.IsDBNull("address") ? "" : reader.GetString("address");
                                row["SĐT"] = reader.IsDBNull("phone_number") ? "" : reader.GetString("phone_number");
                                row["Email"] = reader.IsDBNull("email") ? "" : reader.GetString("email");
                                row["Phòng ban"] = reader.IsDBNull("department_name") ? "" : reader.GetString("department_name");
                                row["Chức vụ"] = reader.IsDBNull("position_name") ? "" : reader.GetString("position_name");
                                row["Ngày vào làm"] = reader.GetDateTime("start_date");
                                row["Lương cơ bản"] = reader.GetDecimal("basic_salary");
                                row["Hệ số lương"] = reader.GetDecimal("salary_coefficient");
                                row["Phụ cấp"] = reader.GetDecimal("allowance");
                                row["Trạng thái"] = reader.GetBoolean("is_active") ? "Hoạt động" : "Không hoạt động";
                                
                                employeeDataTable.Rows.Add(row);
                            }
                        }
                    }
                }
                
                lblTotalEmployees.Text = $"Kết quả tìm kiếm: {employeeDataTable.Rows.Count} nhân viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm nhân viên: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện làm mới danh sách
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadEmployees();
        }
        
        /// <summary>
        /// Xử lý sự kiện thêm nhân viên mới
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (LoginForm.CurrentUser?.Role != "Admin")
            {
                MessageBox.Show("Bạn không có quyền thêm nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var form = new EmployeeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện sửa nhân viên
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (LoginForm.CurrentUser?.Role != "Admin")
            {
                MessageBox.Show("Bạn không có quyền sửa thông tin nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["ID"].Value);
            var form = new EmployeeForm(employeeId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện xóa nhân viên
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (LoginForm.CurrentUser?.Role != "Admin")
            {
                MessageBox.Show("Bạn không có quyền xóa nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["ID"].Value);
                    
                    using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                    {
                        connection.Open();
                        
                        // Kiểm tra xem nhân viên có dữ liệu liên quan không
                        var checkQuery = "SELECT COUNT(*) FROM attendance WHERE employee_id = @id";
                        using (var checkCommand = new MySqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@id", employeeId);
                            int attendanceCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                            
                            if (attendanceCount > 0)
                            {
                                MessageBox.Show("Không thể xóa nhân viên này vì có dữ liệu chấm công liên quan!", 
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        
                        // Xóa nhân viên
                        var deleteQuery = "DELETE FROM employees WHERE id = @id";
                        using (var deleteCommand = new MySqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@id", employeeId);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                    
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployees();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa nhân viên: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện xuất Excel
        /// </summary>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FileName = $"Danh_sach_nhan_vien_{DateTime.Now:yyyyMMdd}.xlsx";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(saveDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xuất dữ liệu ra file Excel
        /// </summary>
        private void ExportToExcel(string fileName)
        {
            // TODO: Implement Excel export using EPPlus
            // Code này sẽ được comment và giải thích theo yêu cầu của user
            /*
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách nhân viên");
                
                // Thêm header
                for (int i = 0; i < dgvEmployees.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dgvEmployees.Columns[i].HeaderText;
                }
                
                // Thêm dữ liệu
                for (int i = 0; i < dgvEmployees.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvEmployees.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgvEmployees.Rows[i].Cells[j].Value;
                    }
                }
                
                package.SaveAs(new FileInfo(fileName));
            }
            */
        }
    }
}
