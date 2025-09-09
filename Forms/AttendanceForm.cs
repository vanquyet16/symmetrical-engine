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
    /// Form quản lý chấm công
    /// </summary>
    public partial class AttendanceForm : Form
    {
        private DataTable attendanceDataTable;
        private List<Employee> employees;
        
        public AttendanceForm()
        {
            InitializeComponent();
            InitializeDataTable();
            LoadEmployees();
            LoadAttendance();
        }
        
        /// <summary>
        /// Khởi tạo DataTable cho danh sách chấm công
        /// </summary>
        private void InitializeDataTable()
        {
            attendanceDataTable = new DataTable();
            attendanceDataTable.Columns.Add("ID", typeof(int));
            attendanceDataTable.Columns.Add("Mã NV", typeof(string));
            attendanceDataTable.Columns.Add("Họ tên", typeof(string));
            attendanceDataTable.Columns.Add("Ngày", typeof(DateTime));
            attendanceDataTable.Columns.Add("Giờ vào", typeof(TimeSpan));
            attendanceDataTable.Columns.Add("Giờ ra", typeof(TimeSpan));
            attendanceDataTable.Columns.Add("Trạng thái", typeof(string));
            attendanceDataTable.Columns.Add("Ghi chú", typeof(string));
            attendanceDataTable.Columns.Add("Ngày tạo", typeof(DateTime));
            
            dgvAttendance.DataSource = attendanceDataTable;
        }
        
        /// <summary>
        /// Tải danh sách nhân viên
        /// </summary>
        private void LoadEmployees()
        {
            try
            {
                employees = new List<Employee>();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "SELECT id, employee_code, full_name FROM employees WHERE is_active = TRUE ORDER BY full_name";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = reader.GetInt32("id"),
                                EmployeeCode = reader.GetString("employee_code"),
                                FullName = reader.GetString("full_name")
                            });
                        }
                    }
                }
                
                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "FullName";
                cmbEmployee.ValueMember = "Id";
                cmbEmployee.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách nhân viên: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Tải danh sách chấm công
        /// </summary>
        private void LoadAttendance()
        {
            try
            {
                attendanceDataTable.Clear();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT a.*, e.employee_code, e.full_name
                        FROM attendance a
                        INNER JOIN employees e ON a.employee_id = e.id
                        ORDER BY a.date DESC, e.full_name";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = attendanceDataTable.NewRow();
                            row["ID"] = reader.GetInt32("id");
                            row["Mã NV"] = reader.GetString("employee_code");
                            row["Họ tên"] = reader.GetString("full_name");
                            row["Ngày"] = reader.GetDateTime("date");
                            row["Giờ vào"] = reader.IsDBNull("check_in_time") ? TimeSpan.Zero : reader.GetTimeSpan("check_in_time");
                            row["Giờ ra"] = reader.IsDBNull("check_out_time") ? TimeSpan.Zero : reader.GetTimeSpan("check_out_time");
                            row["Trạng thái"] = reader.GetString("status");
                            row["Ghi chú"] = reader.IsDBNull("notes") ? "" : reader.GetString("notes");
                            row["Ngày tạo"] = reader.GetDateTime("created_date");
                            
                            attendanceDataTable.Rows.Add(row);
                        }
                    }
                }
                
                lblTotalAttendance.Text = $"Tổng số bản ghi chấm công: {attendanceDataTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách chấm công: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện thêm chấm công
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                int employeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
                DateTime date = dtpDate.Value.Date;
                
                // Kiểm tra xem đã có chấm công cho ngày này chưa
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var checkQuery = @"
                        SELECT COUNT(*) FROM attendance 
                        WHERE employee_id = @employee_id AND date = @date";
                    
                    using (var checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@employee_id", employeeId);
                        checkCommand.Parameters.AddWithValue("@date", date);
                        
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Đã có chấm công cho nhân viên này trong ngày này!", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    
                    // Thêm chấm công mới
                    var insertQuery = @"
                        INSERT INTO attendance (employee_id, date, check_in_time, check_out_time, status, notes, created_date)
                        VALUES (@employee_id, @date, @check_in_time, @check_out_time, @status, @notes, NOW())";
                    
                    using (var insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@employee_id", employeeId);
                        insertCommand.Parameters.AddWithValue("@date", date);
                        insertCommand.Parameters.AddWithValue("@check_in_time", dtpCheckIn.Value.TimeOfDay);
                        insertCommand.Parameters.AddWithValue("@check_out_time", dtpCheckOut.Value.TimeOfDay);
                        insertCommand.Parameters.AddWithValue("@status", cmbStatus.Text);
                        insertCommand.Parameters.AddWithValue("@notes", txtNotes.Text.Trim());
                        
                        insertCommand.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Thêm chấm công thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearForm();
                LoadAttendance();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm chấm công: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện sửa chấm công
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi chấm công cần sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                int attendanceId = Convert.ToInt32(dgvAttendance.SelectedRows[0].Cells["ID"].Value);
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        UPDATE attendance 
                        SET check_in_time = @check_in_time, check_out_time = @check_out_time, 
                            status = @status, notes = @notes
                        WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", attendanceId);
                        command.Parameters.AddWithValue("@check_in_time", dtpCheckIn.Value.TimeOfDay);
                        command.Parameters.AddWithValue("@check_out_time", dtpCheckOut.Value.TimeOfDay);
                        command.Parameters.AddWithValue("@status", cmbStatus.Text);
                        command.Parameters.AddWithValue("@notes", txtNotes.Text.Trim());
                        
                        command.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Cập nhật chấm công thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearForm();
                LoadAttendance();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật chấm công: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện xóa chấm công
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi chấm công cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi chấm công này?", "Xác nhận xóa", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    int attendanceId = Convert.ToInt32(dgvAttendance.SelectedRows[0].Cells["ID"].Value);
                    
                    using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                    {
                        connection.Open();
                        
                        var deleteQuery = "DELETE FROM attendance WHERE id = @id";
                        using (var deleteCommand = new MySqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@id", attendanceId);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                    
                    MessageBox.Show("Xóa chấm công thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAttendance();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa chấm công: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện chọn bản ghi chấm công từ danh sách
        /// </summary>
        private void dgvAttendance_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAttendance.SelectedRows.Count > 0)
            {
                var row = dgvAttendance.SelectedRows[0];
                
                // Tìm nhân viên
                string employeeName = row.Cells["Họ tên"].Value.ToString();
                var employee = employees.Find(e => e.FullName == employeeName);
                if (employee != null)
                {
                    cmbEmployee.SelectedValue = employee.Id;
                }
                
                dtpDate.Value = Convert.ToDateTime(row.Cells["Ngày"].Value);
                dtpCheckIn.Value = DateTime.Today.Add((TimeSpan)row.Cells["Giờ vào"].Value);
                dtpCheckOut.Value = DateTime.Today.Add((TimeSpan)row.Cells["Giờ ra"].Value);
                cmbStatus.Text = row.Cells["Trạng thái"].Value.ToString();
                txtNotes.Text = row.Cells["Ghi chú"].Value.ToString();
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện chấm công nhanh
        /// </summary>
        private void btnQuickCheckIn_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Tự động chấm công vào
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddHours(8); // Giả định làm 8 tiếng
            cmbStatus.Text = "Present";
            txtNotes.Text = "Chấm công tự động";
            
            btnAdd_Click(sender, e);
        }
        
        /// <summary>
        /// Xử lý sự kiện chấm công ra
        /// </summary>
        private void btnQuickCheckOut_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi chấm công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Cập nhật giờ ra
            dtpCheckOut.Value = DateTime.Now;
            btnEdit_Click(sender, e);
        }
        
        /// <summary>
        /// Xóa form
        /// </summary>
        private void ClearForm()
        {
            cmbEmployee.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddHours(8);
            cmbStatus.SelectedIndex = 0;
            txtNotes.Clear();
        }
        
        /// <summary>
        /// Xử lý sự kiện làm mới
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadAttendance();
        }
        
        /// <summary>
        /// Xử lý sự kiện tìm kiếm theo ngày
        /// </summary>
        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            try
            {
                attendanceDataTable.Clear();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT a.*, e.employee_code, e.full_name
                        FROM attendance a
                        INNER JOIN employees e ON a.employee_id = e.id
                        WHERE a.date = @date
                        ORDER BY e.full_name";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date", dtpSearchDate.Value.Date);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = attendanceDataTable.NewRow();
                                row["ID"] = reader.GetInt32("id");
                                row["Mã NV"] = reader.GetString("employee_code");
                                row["Họ tên"] = reader.GetString("full_name");
                                row["Ngày"] = reader.GetDateTime("date");
                                row["Giờ vào"] = reader.IsDBNull("check_in_time") ? TimeSpan.Zero : reader.GetTimeSpan("check_in_time");
                                row["Giờ ra"] = reader.IsDBNull("check_out_time") ? TimeSpan.Zero : reader.GetTimeSpan("check_out_time");
                                row["Trạng thái"] = reader.GetString("status");
                                row["Ghi chú"] = reader.IsDBNull("notes") ? "" : reader.GetString("notes");
                                row["Ngày tạo"] = reader.GetDateTime("created_date");
                                
                                attendanceDataTable.Rows.Add(row);
                            }
                        }
                    }
                }
                
                lblTotalAttendance.Text = $"Kết quả tìm kiếm: {attendanceDataTable.Rows.Count} bản ghi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
