-- Script tạo database cho hệ thống quản lý nhân viên
-- Tạo database
CREATE DATABASE IF NOT EXISTS EmployeeManagement;
USE EmployeeManagement;

-- Bảng quyền người dùng
CREATE TABLE UserRoles (
    RoleId INT PRIMARY KEY AUTO_INCREMENT,
    RoleName VARCHAR(50) NOT NULL UNIQUE,
    Description TEXT,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Bảng người dùng đăng nhập
CREATE TABLE Users (
    UserId INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    RoleId INT NOT NULL,
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    LastLogin DATETIME,
    FOREIGN KEY (RoleId) REFERENCES UserRoles(RoleId)
);

-- Bảng phòng ban
CREATE TABLE Departments (
    DepartmentId INT PRIMARY KEY AUTO_INCREMENT,
    DepartmentName VARCHAR(100) NOT NULL,
    Description TEXT,
    ManagerId INT,
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Bảng chức vụ
CREATE TABLE Positions (
    PositionId INT PRIMARY KEY AUTO_INCREMENT,
    PositionName VARCHAR(100) NOT NULL,
    Description TEXT,
    BaseSalary DECIMAL(15,2) DEFAULT 0,
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Bảng nhân viên
CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY AUTO_INCREMENT,
    EmployeeCode VARCHAR(20) NOT NULL UNIQUE,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100),
    Phone VARCHAR(20),
    Address TEXT,
    DateOfBirth DATE,
    Gender ENUM('Male', 'Female', 'Other') DEFAULT 'Male',
    DepartmentId INT,
    PositionId INT,
    HireDate DATE NOT NULL,
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId),
    FOREIGN KEY (PositionId) REFERENCES Positions(PositionId)
);

-- Bảng hệ số lương
CREATE TABLE SalaryCoefficients (
    CoefficientId INT PRIMARY KEY AUTO_INCREMENT,
    EmployeeId INT NOT NULL,
    Coefficient DECIMAL(5,2) DEFAULT 1.0,
    Allowance DECIMAL(15,2) DEFAULT 0,
    EffectiveDate DATE NOT NULL,
    EndDate DATE,
    IsActive BOOLEAN DEFAULT TRUE,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- Bảng chấm công
CREATE TABLE Attendance (
    AttendanceId INT PRIMARY KEY AUTO_INCREMENT,
    EmployeeId INT NOT NULL,
    WorkDate DATE NOT NULL,
    CheckInTime TIME,
    CheckOutTime TIME,
    WorkHours DECIMAL(4,2) DEFAULT 0,
    OvertimeHours DECIMAL(4,2) DEFAULT 0,
    Status ENUM('Present', 'Absent', 'Late', 'Leave') DEFAULT 'Present',
    Notes TEXT,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    UNIQUE KEY unique_employee_date (EmployeeId, WorkDate)
);

-- Bảng nghỉ phép
CREATE TABLE LeaveRequests (
    LeaveId INT PRIMARY KEY AUTO_INCREMENT,
    EmployeeId INT NOT NULL,
    LeaveType ENUM('Annual', 'Sick', 'Personal', 'Maternity', 'Paternity') NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Days INT NOT NULL,
    Reason TEXT,
    Status ENUM('Pending', 'Approved', 'Rejected') DEFAULT 'Pending',
    ApprovedBy INT,
    ApprovedDate DATETIME,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    FOREIGN KEY (ApprovedBy) REFERENCES Employees(EmployeeId)
);

-- Bảng bảng lương
CREATE TABLE Payrolls (
    PayrollId INT PRIMARY KEY AUTO_INCREMENT,
    EmployeeId INT NOT NULL,
    PayPeriodStart DATE NOT NULL,
    PayPeriodEnd DATE NOT NULL,
    BasicSalary DECIMAL(15,2) NOT NULL,
    Coefficient DECIMAL(5,2) NOT NULL,
    Allowance DECIMAL(15,2) DEFAULT 0,
    WorkDays INT NOT NULL,
    OvertimeHours DECIMAL(4,2) DEFAULT 0,
    OvertimePay DECIMAL(15,2) DEFAULT 0,
    GrossSalary DECIMAL(15,2) NOT NULL,
    Tax DECIMAL(15,2) DEFAULT 0,
    Insurance DECIMAL(15,2) DEFAULT 0,
    NetSalary DECIMAL(15,2) NOT NULL,
    Status ENUM('Draft', 'Approved', 'Paid') DEFAULT 'Draft',
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    ApprovedDate DATETIME,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);

-- Bảng sao lưu dữ liệu
CREATE TABLE DataBackups (
    BackupId INT PRIMARY KEY AUTO_INCREMENT,
    BackupName VARCHAR(100) NOT NULL,
    BackupPath VARCHAR(500) NOT NULL,
    BackupSize BIGINT,
    BackupDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    CreatedBy INT,
    Description TEXT,
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserId)
);

-- Bảng lịch sử thay đổi
CREATE TABLE AuditLogs (
    LogId INT PRIMARY KEY AUTO_INCREMENT,
    TableName VARCHAR(50) NOT NULL,
    RecordId INT NOT NULL,
    Action ENUM('INSERT', 'UPDATE', 'DELETE') NOT NULL,
    OldValues JSON,
    NewValues JSON,
    ChangedBy INT,
    ChangedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ChangedBy) REFERENCES Users(UserId)
);

-- Thêm foreign key cho Departments.ManagerId sau khi tạo bảng Employees
ALTER TABLE Departments ADD FOREIGN KEY (ManagerId) REFERENCES Employees(EmployeeId);

-- Insert dữ liệu mẫu
INSERT INTO UserRoles (RoleName, Description) VALUES 
('Admin', 'Quản trị viên hệ thống'),
('HR', 'Nhân viên nhân sự'),
('Manager', 'Quản lý'),
('Employee', 'Nhân viên');

INSERT INTO Users (Username, Password, RoleId) VALUES 
('admin', 'admin123', 1),
('hr', 'hr123', 2),
('manager', 'manager123', 3);

INSERT INTO Departments (DepartmentName, Description) VALUES 
('IT', 'Phòng Công nghệ thông tin'),
('HR', 'Phòng Nhân sự'),
('Finance', 'Phòng Tài chính'),
('Marketing', 'Phòng Marketing'),
('Sales', 'Phòng Kinh doanh');

INSERT INTO Positions (PositionName, Description, BaseSalary) VALUES 
('Nhân viên', 'Nhân viên thông thường', 5000000),
('Trưởng phòng', 'Trưởng phòng ban', 10000000),
('Phó giám đốc', 'Phó giám đốc', 15000000),
('Giám đốc', 'Giám đốc', 20000000),
('Nhân viên IT', 'Nhân viên công nghệ thông tin', 8000000);

-- Tạo indexes để tối ưu hiệu suất
CREATE INDEX idx_employees_department ON Employees(DepartmentId);
CREATE INDEX idx_employees_position ON Employees(PositionId);
CREATE INDEX idx_employees_code ON Employees(EmployeeCode);
CREATE INDEX idx_attendance_employee_date ON Attendance(EmployeeId, WorkDate);
CREATE INDEX idx_payrolls_employee_period ON Payrolls(EmployeeId, PayPeriodStart, PayPeriodEnd);
CREATE INDEX idx_salary_coefficients_employee ON SalaryCoefficients(EmployeeId);
