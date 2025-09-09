using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace EmployeeManagement.Database
{
    /// <summary>
    /// Class hỗ trợ kết nối và thao tác với database MySQL
    /// </summary>
    public class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=employee_management;Uid=root;Pwd=;";
        
        /// <summary>
        /// Lấy chuỗi kết nối database
        /// </summary>
        public static string GetConnectionString()
        {
            return connectionString;
        }
        
        /// <summary>
        /// Thiết lập chuỗi kết nối database
        /// </summary>
        /// <param name="server">127.0.0.1</param>
        /// <param name="database">employee_management</param>
        /// <param name="username">root</param>
        /// <param name="password"></param>
        public static void SetConnectionString(string server, string database, string username, string password)
        {
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }
        
        /// <summary>
        /// Kiểm tra kết nối database
        /// </summary>
        /// <returns>True nếu kết nối thành công</returns>
        public static bool TestConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Tạo database và các bảng nếu chưa tồn tại
        /// </summary>
        public static void InitializeDatabase()
        {
            try
            {
                // Kết nối tới MySQL server (không chỉ định database)
                var serverConnectionString = "Server=localhost;Uid=root;Pwd=;";
                
                using (var connection = new MySqlConnection(serverConnectionString))
                {
                    connection.Open();
                    
                    // Tạo database nếu chưa tồn tại
                    var createDbCommand = new MySqlCommand("CREATE DATABASE IF NOT EXISTS employee_management", connection);
                    createDbCommand.ExecuteNonQuery();
                }
                
                // Kết nối tới database vừa tạo
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // Tạo các bảng
                    CreateTables(connection);
                    InsertDefaultData(connection);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khởi tạo database: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Tạo các bảng trong database
        /// </summary>
        private static void CreateTables(MySqlConnection connection)
        {
            // Bảng Users
            var createUsersTable = @"
                CREATE TABLE IF NOT EXISTS users (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    username VARCHAR(50) UNIQUE NOT NULL,
                    password VARCHAR(255) NOT NULL,
                    full_name VARCHAR(100) NOT NULL,
                    role ENUM('Admin', 'User') NOT NULL DEFAULT 'User',
                    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                    is_active BOOLEAN DEFAULT TRUE
                )";
            
            // Bảng Departments
            var createDepartmentsTable = @"
                CREATE TABLE IF NOT EXISTS departments (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(100) NOT NULL,
                    description TEXT,
                    manager_id INT,
                    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                    is_active BOOLEAN DEFAULT TRUE
                )";
            
            // Bảng Positions
            var createPositionsTable = @"
                CREATE TABLE IF NOT EXISTS positions (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(100) NOT NULL,
                    description TEXT,
                    min_salary DECIMAL(15,2) DEFAULT 0,
                    max_salary DECIMAL(15,2) DEFAULT 0,
                    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                    is_active BOOLEAN DEFAULT TRUE
                )";
            
            // Bảng Employees
            var createEmployeesTable = @"
                CREATE TABLE IF NOT EXISTS employees (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    employee_code VARCHAR(20) UNIQUE NOT NULL,
                    full_name VARCHAR(100) NOT NULL,
                    date_of_birth DATE NOT NULL,
                    gender ENUM('Nam', 'Nữ') NOT NULL,
                    address TEXT,
                    phone_number VARCHAR(20),
                    email VARCHAR(100),
                    department_id INT,
                    position_id INT,
                    start_date DATE NOT NULL,
                    basic_salary DECIMAL(15,2) DEFAULT 0,
                    salary_coefficient DECIMAL(5,2) DEFAULT 1.0,
                    allowance DECIMAL(15,2) DEFAULT 0,
                    is_active BOOLEAN DEFAULT TRUE,
                    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (department_id) REFERENCES departments(id),
                    FOREIGN KEY (position_id) REFERENCES positions(id)
                )";
            
            // Bảng Attendance
            var createAttendanceTable = @"
                CREATE TABLE IF NOT EXISTS attendance (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    employee_id INT NOT NULL,
                    date DATE NOT NULL,
                    check_in_time TIME,
                    check_out_time TIME,
                    status ENUM('Present', 'Absent', 'Late', 'Leave') DEFAULT 'Present',
                    notes TEXT,
                    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (employee_id) REFERENCES employees(id),
                    UNIQUE KEY unique_employee_date (employee_id, date)
                )";
            
            // Bảng Salary
            var createSalaryTable = @"
                CREATE TABLE IF NOT EXISTS salary (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    employee_id INT NOT NULL,
                    month INT NOT NULL,
                    year INT NOT NULL,
                    basic_salary DECIMAL(15,2) NOT NULL,
                    salary_coefficient DECIMAL(5,2) NOT NULL,
                    allowance DECIMAL(15,2) NOT NULL,
                    working_days INT NOT NULL,
                    total_days INT NOT NULL,
                    total_salary DECIMAL(15,2) NOT NULL,
                    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
                    is_paid BOOLEAN DEFAULT FALSE,
                    FOREIGN KEY (employee_id) REFERENCES employees(id),
                    UNIQUE KEY unique_employee_month_year (employee_id, month, year)
                )";
            
            // Thực thi các lệnh tạo bảng
            var commands = new[] { createUsersTable, createDepartmentsTable, createPositionsTable, 
                                 createEmployeesTable, createAttendanceTable, createSalaryTable };
            
            foreach (var command in commands)
            {
                var cmd = new MySqlCommand(command, connection);
                cmd.ExecuteNonQuery();
            }
        }
        
        /// <summary>
        /// Thêm dữ liệu mặc định
        /// </summary>
        private static void InsertDefaultData(MySqlConnection connection)
        {
            // Kiểm tra xem đã có dữ liệu chưa
            var checkUsers = new MySqlCommand("SELECT COUNT(*) FROM users", connection);
            var userCount = Convert.ToInt32(checkUsers.ExecuteScalar());
            
            if (userCount == 0)
            {
                // Thêm tài khoản admin mặc định
                var insertAdmin = @"
                    INSERT INTO users (username, password, full_name, role) 
                    VALUES ('admin', 'admin123', 'Quản trị viên', 'Admin')";
                
                var cmd = new MySqlCommand(insertAdmin, connection);
                cmd.ExecuteNonQuery();
            }
            
            // Kiểm tra và thêm phòng ban mặc định
            var checkDepartments = new MySqlCommand("SELECT COUNT(*) FROM departments", connection);
            var deptCount = Convert.ToInt32(checkDepartments.ExecuteScalar());
            
            if (deptCount == 0)
            {
                var insertDepartments = @"
                    INSERT INTO departments (name, description) VALUES 
                    ('Phòng Nhân sự', 'Quản lý nhân sự và tuyển dụng'),
                    ('Phòng Kế toán', 'Quản lý tài chính và kế toán'),
                    ('Phòng IT', 'Công nghệ thông tin'),
                    ('Phòng Kinh doanh', 'Kinh doanh và marketing')";
                
                var cmd = new MySqlCommand(insertDepartments, connection);
                cmd.ExecuteNonQuery();
            }
            
            // Kiểm tra và thêm chức vụ mặc định
            var checkPositions = new MySqlCommand("SELECT COUNT(*) FROM positions", connection);
            var posCount = Convert.ToInt32(checkPositions.ExecuteScalar());
            
            if (posCount == 0)
            {
                var insertPositions = @"
                    INSERT INTO positions (name, description, min_salary, max_salary) VALUES 
                    ('Nhân viên', 'Nhân viên thông thường', 5000000, 10000000),
                    ('Trưởng phòng', 'Trưởng phòng ban', 15000000, 25000000),
                    ('Giám đốc', 'Giám đốc công ty', 30000000, 50000000),
                    ('Phó giám đốc', 'Phó giám đốc', 20000000, 35000000)";
                
                var cmd = new MySqlCommand(insertPositions, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
