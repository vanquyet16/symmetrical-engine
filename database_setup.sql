-- Script tạo database và bảng cho hệ thống quản lý nhân viên
-- Chạy script này trong MySQL để tạo database và cấu trúc bảng

-- Tạo database
CREATE DATABASE IF NOT EXISTS employee_management;
USE employee_management;

-- Bảng users (tài khoản người dùng)
CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    role ENUM('Admin', 'User') NOT NULL DEFAULT 'User',
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_active BOOLEAN DEFAULT TRUE
);

-- Bảng departments (phòng ban)
CREATE TABLE IF NOT EXISTS departments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    manager_id INT,
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_active BOOLEAN DEFAULT TRUE
);

-- Bảng positions (chức vụ)
CREATE TABLE IF NOT EXISTS positions (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    min_salary DECIMAL(15,2) DEFAULT 0,
    max_salary DECIMAL(15,2) DEFAULT 0,
    created_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_active BOOLEAN DEFAULT TRUE
);

-- Bảng employees (nhân viên)
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
);

-- Bảng attendance (chấm công)
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
);

-- Bảng salary (bảng lương)
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
);

-- Thêm dữ liệu mẫu

-- Thêm tài khoản admin mặc định
INSERT INTO users (username, password, full_name, role) VALUES 
('admin', 'admin123', 'Quản trị viên', 'Admin');

-- Thêm phòng ban mặc định
INSERT INTO departments (name, description) VALUES 
('Phòng Nhân sự', 'Quản lý nhân sự và tuyển dụng'),
('Phòng Kế toán', 'Quản lý tài chính và kế toán'),
('Phòng IT', 'Công nghệ thông tin'),
('Phòng Kinh doanh', 'Kinh doanh và marketing'),
('Phòng Sản xuất', 'Quản lý sản xuất và chất lượng');

-- Thêm chức vụ mặc định
INSERT INTO positions (name, description, min_salary, max_salary) VALUES 
('Nhân viên', 'Nhân viên thông thường', 5000000, 10000000),
('Trưởng phòng', 'Trưởng phòng ban', 15000000, 25000000),
('Giám đốc', 'Giám đốc công ty', 30000000, 50000000),
('Phó giám đốc', 'Phó giám đốc', 20000000, 35000000),
('Chuyên viên', 'Chuyên viên kỹ thuật', 8000000, 15000000);

-- Thêm nhân viên mẫu
INSERT INTO employees (employee_code, full_name, date_of_birth, gender, address, phone_number, email, department_id, position_id, start_date, basic_salary, salary_coefficient, allowance) VALUES 
('NV0001', 'Nguyễn Văn An', '1990-01-15', 'Nam', 'Hà Nội', '0123456789', 'an.nguyen@company.com', 1, 2, '2020-01-01', 15000000, 1.5, 2000000),
('NV0002', 'Trần Thị Bình', '1992-05-20', 'Nữ', 'TP.HCM', '0987654321', 'binh.tran@company.com', 2, 1, '2021-03-15', 8000000, 1.2, 1000000),
('NV0003', 'Lê Văn Cường', '1988-12-10', 'Nam', 'Đà Nẵng', '0369852147', 'cuong.le@company.com', 3, 3, '2019-06-01', 30000000, 2.0, 5000000);

-- Thêm dữ liệu chấm công mẫu
INSERT INTO attendance (employee_id, date, check_in_time, check_out_time, status) VALUES 
(1, '2024-01-01', '08:00:00', '17:00:00', 'Present'),
(1, '2024-01-02', '08:15:00', '17:30:00', 'Late'),
(2, '2024-01-01', '08:00:00', '17:00:00', 'Present'),
(2, '2024-01-02', '08:00:00', '17:00:00', 'Present'),
(3, '2024-01-01', '08:00:00', '17:00:00', 'Present');

-- Thêm dữ liệu lương mẫu
INSERT INTO salary (employee_id, month, year, basic_salary, salary_coefficient, allowance, working_days, total_days, total_salary) VALUES 
(1, 1, 2024, 15000000, 1.5, 2000000, 22, 31, 24500000),
(2, 1, 2024, 8000000, 1.2, 1000000, 22, 31, 10600000),
(3, 1, 2024, 30000000, 2.0, 5000000, 22, 31, 65000000);

-- Tạo index để tối ưu hiệu suất
CREATE INDEX idx_employees_department ON employees(department_id);
CREATE INDEX idx_employees_position ON employees(position_id);
CREATE INDEX idx_attendance_employee_date ON attendance(employee_id, date);
CREATE INDEX idx_salary_employee_month_year ON salary(employee_id, month, year);

-- Hiển thị thông báo hoàn thành
SELECT 'Database và dữ liệu mẫu đã được tạo thành công!' as Message;
