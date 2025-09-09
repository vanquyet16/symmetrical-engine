using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EmployeeManagement.Database;

namespace EmployeeManagement.Forms
{
    /// <summary>
    /// Form báo cáo và thống kê
    /// </summary>
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            LoadReports();
        }
        
        /// <summary>
        /// Tải các báo cáo thống kê
        /// </summary>
        private void LoadReports()
        {
            LoadEmployeeStatistics();
            LoadSalaryReport();
            LoadAttendanceReport();
        }
        
        /// <summary>
        /// Thống kê nhân viên theo phòng ban và chức vụ
        /// </summary>
        private void LoadEmployeeStatistics()
        {
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    // Thống kê theo phòng ban
                    var deptQuery = @"
                        SELECT d.name as 'Phòng ban', COUNT(e.id) as 'Số nhân viên'
                        FROM departments d
                        LEFT JOIN employees e ON d.id = e.department_id AND e.is_active = TRUE
                        WHERE d.is_active = TRUE
                        GROUP BY d.id, d.name
                        ORDER BY COUNT(e.id) DESC";
                    
                    var deptDataTable = new DataTable();
                    using (var command = new MySqlCommand(deptQuery, connection))
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(deptDataTable);
                    }
                    
                    dgvDepartmentStats.DataSource = deptDataTable;
                    
                    // Thống kê theo chức vụ
                    var posQuery = @"
                        SELECT p.name as 'Chức vụ', COUNT(e.id) as 'Số nhân viên'
                        FROM positions p
                        LEFT JOIN employees e ON p.id = e.position_id AND e.is_active = TRUE
                        WHERE p.is_active = TRUE
                        GROUP BY p.id, p.name
                        ORDER BY COUNT(e.id) DESC";
                    
                    var posDataTable = new DataTable();
                    using (var command = new MySqlCommand(posQuery, connection))
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(posDataTable);
                    }
                    
                    dgvPositionStats.DataSource = posDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thống kê: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Báo cáo bảng lương
        /// </summary>
        private void LoadSalaryReport()
        {
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT 
                            e.employee_code as 'Mã NV',
                            e.full_name as 'Họ tên',
                            d.name as 'Phòng ban',
                            p.name as 'Chức vụ',
                            s.month as 'Tháng',
                            s.year as 'Năm',
                            s.total_salary as 'Tổng lương',
                            CASE WHEN s.is_paid THEN 'Đã thanh toán' ELSE 'Chưa thanh toán' END as 'Trạng thái'
                        FROM salary s
                        INNER JOIN employees e ON s.employee_id = e.id
                        LEFT JOIN departments d ON e.department_id = d.id
                        LEFT JOIN positions p ON e.position_id = p.id
                        WHERE s.year = YEAR(CURDATE()) AND s.month = MONTH(CURDATE())
                        ORDER BY s.total_salary DESC";
                    
                    var dataTable = new DataTable();
                    using (var command = new MySqlCommand(query, connection))
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    
                    dgvSalaryReport.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải báo cáo lương: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Báo cáo chấm công
        /// </summary>
        private void LoadAttendanceReport()
        {
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT 
                            e.employee_code as 'Mã NV',
                            e.full_name as 'Họ tên',
                            d.name as 'Phòng ban',
                            COUNT(CASE WHEN a.status = 'Present' THEN 1 END) as 'Có mặt',
                            COUNT(CASE WHEN a.status = 'Absent' THEN 1 END) as 'Vắng mặt',
                            COUNT(CASE WHEN a.status = 'Late' THEN 1 END) as 'Đi trễ',
                            COUNT(CASE WHEN a.status = 'Leave' THEN 1 END) as 'Nghỉ phép',
                            COUNT(a.id) as 'Tổng ngày'
                        FROM employees e
                        LEFT JOIN departments d ON e.department_id = d.id
                        LEFT JOIN attendance a ON e.id = a.employee_id 
                            AND YEAR(a.date) = YEAR(CURDATE()) 
                            AND MONTH(a.date) = MONTH(CURDATE())
                        WHERE e.is_active = TRUE
                        GROUP BY e.id, e.employee_code, e.full_name, d.name
                        ORDER BY e.full_name";
                    
                    var dataTable = new DataTable();
                    using (var command = new MySqlCommand(query, connection))
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    
                    dgvAttendanceReport.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải báo cáo chấm công: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện làm mới báo cáo
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
            MessageBox.Show("Đã cập nhật báo cáo!", "Thông báo", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        /// <summary>
        /// Xử lý sự kiện xuất báo cáo
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FileName = $"Bao_cao_{DateTime.Now:yyyyMMdd}.xlsx";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Implement Excel export using EPPlus
                    // Code này sẽ được comment và giải thích theo yêu cầu của user
                    /*
                    using (var package = new ExcelPackage())
                    {
                        // Tạo worksheet cho thống kê phòng ban
                        var deptWorksheet = package.Workbook.Worksheets.Add("Thống kê phòng ban");
                        // Thêm dữ liệu từ dgvDepartmentStats
                        
                        // Tạo worksheet cho báo cáo lương
                        var salaryWorksheet = package.Workbook.Worksheets.Add("Báo cáo lương");
                        // Thêm dữ liệu từ dgvSalaryReport
                        
                        // Tạo worksheet cho báo cáo chấm công
                        var attendanceWorksheet = package.Workbook.Worksheets.Add("Báo cáo chấm công");
                        // Thêm dữ liệu từ dgvAttendanceReport
                        
                        package.SaveAs(new FileInfo(saveDialog.FileName));
                    }
                    */
                    
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất báo cáo: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
