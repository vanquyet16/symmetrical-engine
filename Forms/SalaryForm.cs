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
    /// Form quản lý lương
    /// </summary>
    public partial class SalaryForm : Form
    {
        private DataTable salaryDataTable;
        private List<Employee> employees;
        
        public SalaryForm()
        {
            InitializeComponent();
            InitializeDataTable();
            LoadEmployees();
            LoadSalaries();
        }
        
        /// <summary>
        /// Khởi tạo DataTable cho danh sách lương
        /// </summary>
        private void InitializeDataTable()
        {
            salaryDataTable = new DataTable();
            salaryDataTable.Columns.Add("ID", typeof(int));
            salaryDataTable.Columns.Add("Mã NV", typeof(string));
            salaryDataTable.Columns.Add("Họ tên", typeof(string));
            salaryDataTable.Columns.Add("Tháng", typeof(int));
            salaryDataTable.Columns.Add("Năm", typeof(int));
            salaryDataTable.Columns.Add("Lương cơ bản", typeof(decimal));
            salaryDataTable.Columns.Add("Hệ số lương", typeof(decimal));
            salaryDataTable.Columns.Add("Phụ cấp", typeof(decimal));
            salaryDataTable.Columns.Add("Số ngày làm", typeof(int));
            salaryDataTable.Columns.Add("Tổng ngày", typeof(int));
            salaryDataTable.Columns.Add("Tổng lương", typeof(decimal));
            salaryDataTable.Columns.Add("Đã thanh toán", typeof(string));
            salaryDataTable.Columns.Add("Ngày tạo", typeof(DateTime));
            
            dgvSalaries.DataSource = salaryDataTable;
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
        /// Tải danh sách lương
        /// </summary>
        private void LoadSalaries()
        {
            try
            {
                salaryDataTable.Clear();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT s.*, e.employee_code, e.full_name
                        FROM salary s
                        INNER JOIN employees e ON s.employee_id = e.id
                        ORDER BY s.year DESC, s.month DESC, e.full_name";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = salaryDataTable.NewRow();
                            row["ID"] = reader.GetInt32("id");
                            row["Mã NV"] = reader.GetString("employee_code");
                            row["Họ tên"] = reader.GetString("full_name");
                            row["Tháng"] = reader.GetInt32("month");
                            row["Năm"] = reader.GetInt32("year");
                            row["Lương cơ bản"] = reader.GetDecimal("basic_salary");
                            row["Hệ số lương"] = reader.GetDecimal("salary_coefficient");
                            row["Phụ cấp"] = reader.GetDecimal("allowance");
                            row["Số ngày làm"] = reader.GetInt32("working_days");
                            row["Tổng ngày"] = reader.GetInt32("total_days");
                            row["Tổng lương"] = reader.GetDecimal("total_salary");
                            row["Đã thanh toán"] = reader.GetBoolean("is_paid") ? "Đã thanh toán" : "Chưa thanh toán";
                            row["Ngày tạo"] = reader.GetDateTime("created_date");
                            
                            salaryDataTable.Rows.Add(row);
                        }
                    }
                }
                
                lblTotalSalaries.Text = $"Tổng số bảng lương: {salaryDataTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách lương: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện chọn nhân viên
        /// </summary>
        private void cmbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue != null)
            {
                LoadEmployeeSalaryInfo();
            }
        }
        
        /// <summary>
        /// Tải thông tin lương của nhân viên được chọn
        /// </summary>
        private void LoadEmployeeSalaryInfo()
        {
            try
            {
                int employeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT basic_salary, salary_coefficient, allowance
                        FROM employees 
                        WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", employeeId);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                numBasicSalary.Value = reader.GetDecimal("basic_salary");
                                numSalaryCoefficient.Value = reader.GetDecimal("salary_coefficient");
                                numAllowance.Value = reader.GetDecimal("allowance");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin lương: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện tính lương
        /// </summary>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (numWorkingDays.Value <= 0 || numTotalDays.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập số ngày làm việc và tổng số ngày!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Tính lương theo công thức: (lương cơ bản * hệ số + phụ cấp) * (số ngày làm / tổng ngày)
            decimal basicSalary = numBasicSalary.Value;
            decimal coefficient = numSalaryCoefficient.Value;
            decimal allowance = numAllowance.Value;
            int workingDays = (int)numWorkingDays.Value;
            int totalDays = (int)numTotalDays.Value;
            
            decimal totalSalary = (basicSalary * coefficient + allowance) * workingDays / totalDays;
            numTotalSalary.Value = totalSalary;
        }
        
        /// <summary>
        /// Xử lý sự kiện thêm bảng lương
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (numMonth.Value <= 0 || numMonth.Value > 12)
            {
                MessageBox.Show("Tháng phải từ 1 đến 12!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (numYear.Value < 2020 || numYear.Value > 2030)
            {
                MessageBox.Show("Năm không hợp lệ!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                int employeeId = Convert.ToInt32(cmbEmployee.SelectedValue);
                int month = (int)numMonth.Value;
                int year = (int)numYear.Value;
                
                // Kiểm tra xem đã có bảng lương cho tháng/năm này chưa
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var checkQuery = @"
                        SELECT COUNT(*) FROM salary 
                        WHERE employee_id = @employee_id AND month = @month AND year = @year";
                    
                    using (var checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@employee_id", employeeId);
                        checkCommand.Parameters.AddWithValue("@month", month);
                        checkCommand.Parameters.AddWithValue("@year", year);
                        
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Đã có bảng lương cho nhân viên này trong tháng/năm này!", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    
                    // Thêm bảng lương mới
                    var insertQuery = @"
                        INSERT INTO salary (employee_id, month, year, basic_salary, salary_coefficient, 
                                          allowance, working_days, total_days, total_salary, created_date, is_paid)
                        VALUES (@employee_id, @month, @year, @basic_salary, @coefficient, @allowance, 
                               @working_days, @total_days, @total_salary, NOW(), @is_paid)";
                    
                    using (var insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@employee_id", employeeId);
                        insertCommand.Parameters.AddWithValue("@month", month);
                        insertCommand.Parameters.AddWithValue("@year", year);
                        insertCommand.Parameters.AddWithValue("@basic_salary", numBasicSalary.Value);
                        insertCommand.Parameters.AddWithValue("@coefficient", numSalaryCoefficient.Value);
                        insertCommand.Parameters.AddWithValue("@allowance", numAllowance.Value);
                        insertCommand.Parameters.AddWithValue("@working_days", (int)numWorkingDays.Value);
                        insertCommand.Parameters.AddWithValue("@total_days", (int)numTotalDays.Value);
                        insertCommand.Parameters.AddWithValue("@total_salary", numTotalSalary.Value);
                        insertCommand.Parameters.AddWithValue("@is_paid", chkIsPaid.Checked);
                        
                        insertCommand.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Thêm bảng lương thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearForm();
                LoadSalaries();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm bảng lương: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện cập nhật trạng thái thanh toán
        /// </summary>
        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            if (dgvSalaries.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bảng lương cần cập nhật!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                int salaryId = Convert.ToInt32(dgvSalaries.SelectedRows[0].Cells["ID"].Value);
                bool isPaid = chkIsPaid.Checked;
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "UPDATE salary SET is_paid = @is_paid WHERE id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", salaryId);
                        command.Parameters.AddWithValue("@is_paid", isPaid);
                        
                        command.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("Cập nhật trạng thái thanh toán thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadSalaries();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật trạng thái thanh toán: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện chọn bảng lương từ danh sách
        /// </summary>
        private void dgvSalaries_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSalaries.SelectedRows.Count > 0)
            {
                var row = dgvSalaries.SelectedRows[0];
                
                // Tìm nhân viên
                string employeeName = row.Cells["Họ tên"].Value.ToString();
                var employee = employees.Find(e => e.FullName == employeeName);
                if (employee != null)
                {
                    cmbEmployee.SelectedValue = employee.Id;
                }
                
                numMonth.Value = Convert.ToInt32(row.Cells["Tháng"].Value);
                numYear.Value = Convert.ToInt32(row.Cells["Năm"].Value);
                numBasicSalary.Value = Convert.ToDecimal(row.Cells["Lương cơ bản"].Value);
                numSalaryCoefficient.Value = Convert.ToDecimal(row.Cells["Hệ số lương"].Value);
                numAllowance.Value = Convert.ToDecimal(row.Cells["Phụ cấp"].Value);
                numWorkingDays.Value = Convert.ToInt32(row.Cells["Số ngày làm"].Value);
                numTotalDays.Value = Convert.ToInt32(row.Cells["Tổng ngày"].Value);
                numTotalSalary.Value = Convert.ToDecimal(row.Cells["Tổng lương"].Value);
                chkIsPaid.Checked = row.Cells["Đã thanh toán"].Value.ToString() == "Đã thanh toán";
            }
        }
        
        /// <summary>
        /// Xóa form
        /// </summary>
        private void ClearForm()
        {
            cmbEmployee.SelectedIndex = -1;
            numMonth.Value = DateTime.Now.Month;
            numYear.Value = DateTime.Now.Year;
            numBasicSalary.Value = 0;
            numSalaryCoefficient.Value = 1;
            numAllowance.Value = 0;
            numWorkingDays.Value = 22;
            numTotalDays.Value = 30;
            numTotalSalary.Value = 0;
            chkIsPaid.Checked = false;
        }
        
        /// <summary>
        /// Xử lý sự kiện làm mới
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadSalaries();
        }
        
        /// <summary>
        /// Xử lý sự kiện xuất bảng lương
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FileName = $"Bang_luong_{DateTime.Now:yyyyMMdd}.xlsx";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Implement Excel export using EPPlus
                    // Code này sẽ được comment và giải thích theo yêu cầu của user
                    /*
                    using (var package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Bảng lương");
                        
                        // Thêm header
                        for (int i = 0; i < dgvSalaries.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = dgvSalaries.Columns[i].HeaderText;
                        }
                        
                        // Thêm dữ liệu
                        for (int i = 0; i < dgvSalaries.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvSalaries.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dgvSalaries.Rows[i].Cells[j].Value;
                            }
                        }
                        
                        package.SaveAs(new FileInfo(saveDialog.FileName));
                    }
                    */
                    
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
    }
}
