# Hệ thống quản lý nhân viên

## Mô tả

Hệ thống quản lý nhân viên được phát triển bằng C# WinForms và MySQL, cung cấp đầy đủ các chức năng quản lý nhân sự cho doanh nghiệp.

## Tính năng chính

### 1. Đăng nhập & phân quyền

- Đăng nhập bằng tài khoản (Admin / User)
- Phân quyền: Admin được thêm, sửa, xóa nhân viên; User chỉ được xem
- Đổi mật khẩu

### 2. Quản lý nhân viên

- Thêm mới nhân viên
- Sửa thông tin nhân viên
- Xóa nhân viên
- Tìm kiếm nhân viên theo tên, mã, phòng ban

### 3. Quản lý phòng ban

- Tạo, chỉnh sửa, xóa phòng ban
- Liên kết nhân viên với phòng ban
- Xem danh sách nhân viên theo phòng ban

### 4. Quản lý chức vụ

- Danh mục chức vụ (nhân viên, trưởng phòng, giám đốc...)
- Gán chức vụ cho từng nhân viên
- Xem danh sách nhân viên theo chức vụ

### 5. Quản lý lương

- Nhập hệ số lương, phụ cấp
- Tính lương theo công thức: (lương cơ bản _ hệ số + phụ cấp) _ (số ngày công / 22) + lương làm thêm giờ
- Quản lý bảng lương hàng tháng
- Duyệt bảng lương

## Cấu trúc database

Database được thiết kế với đầy đủ 11 yêu cầu:

1. **UserRoles** - Bảng quyền người dùng
2. **Users** - Bảng người dùng đăng nhập
3. **Departments** - Bảng phòng ban
4. **Positions** - Bảng chức vụ
5. **Employees** - Bảng nhân viên
6. **SalaryCoefficients** - Bảng hệ số lương
7. **Attendance** - Bảng chấm công
8. **LeaveRequests** - Bảng nghỉ phép
9. **Payrolls** - Bảng bảng lương
10. **DataBackups** - Bảng sao lưu dữ liệu
11. **AuditLogs** - Bảng lịch sử thay đổi

## Cài đặt và chạy

### Yêu cầu hệ thống

- .NET 6.0 hoặc cao hơn
- MySQL Server 8.0 hoặc cao hơn
- Visual Studio 2022 hoặc VS Code

### Cài đặt

1. **Clone repository:**

```bash
git clone <repository-url>
cd kiemtracuoimonlltq
```

2. **Cài đặt MySQL:**

- Cài đặt MySQL Server
- Tạo database mới
- Chạy script `Database/CreateDatabase.sql` để tạo cấu trúc database

3. **Cấu hình kết nối:**

- Mở file `EmployeeManagement/Config/DatabaseConfig.cs`
- Cập nhật thông tin kết nối MySQL:

```csharp
Server = "localhost",
Database = "EmployeeManagement",
UserID = "root",
Password = "your_password",
Port = 3306
```

4. **Build và chạy:**

```bash
dotnet build
dotnet run
```

### Tài khoản mặc định

- **Admin:** username: `admin`, password: `admin123`
- **HR:** username: `hr`, password: `hr123`
- **Manager:** username: `manager`, password: `manager123`

## Cấu trúc project

```
EmployeeManagement/
├── Config/
│   └── DatabaseConfig.cs          # Cấu hình kết nối database
├── DataAccess/
│   ├── BaseDAL.cs                 # Base class cho Data Access Layer
│   ├── UserDAL.cs                 # Xử lý dữ liệu người dùng
│   ├── EmployeeDAL.cs             # Xử lý dữ liệu nhân viên
│   ├── DepartmentDAL.cs           # Xử lý dữ liệu phòng ban
│   ├── PositionDAL.cs             # Xử lý dữ liệu chức vụ
│   └── SalaryDAL.cs               # Xử lý dữ liệu lương
├── Forms/
│   ├── LoginForm.cs               # Form đăng nhập
│   ├── MainForm.cs                # Form chính
│   ├── EmployeeManagementForm.cs  # Form quản lý nhân viên
│   ├── DepartmentManagementForm.cs # Form quản lý phòng ban
│   ├── PositionManagementForm.cs  # Form quản lý chức vụ
│   ├── SalaryManagementForm.cs    # Form quản lý lương
│   └── ChangePasswordForm.cs      # Form đổi mật khẩu
├── Models/
│   ├── User.cs                    # Model người dùng
│   ├── Employee.cs                # Model nhân viên
│   └── Salary.cs                  # Model lương
├── Utils/
│   └── CurrentUser.cs             # Quản lý user hiện tại
└── Program.cs                     # Entry point
```

## Tính năng mở rộng (có thể phát triển thêm)

6. **Chấm công** - Nhập ngày đi làm / nghỉ phép / đi trễ
7. **Thống kê & báo cáo** - Thống kê số lượng nhân viên theo phòng ban, chức vụ
8. **Tìm kiếm nâng cao** - Tìm kiếm nhân viên theo nhiều điều kiện
9. **Quản lý tài khoản người dùng** - Thêm, sửa, xóa tài khoản đăng nhập
10. **Xuất dữ liệu** - Xuất danh sách nhân viên hoặc bảng lương ra Excel/PDF
11. **Sao lưu & phục hồi dữ liệu** - Backup và restore database

## Lưu ý

- Database đã được thiết kế đầy đủ cho tất cả 11 yêu cầu
- Hiện tại đã implement đầy đủ 5 tính năng đầu tiên
- Các tính năng còn lại có thể được phát triển dựa trên cấu trúc database và code hiện có
- Hệ thống có phân quyền rõ ràng giữa Admin, HR, Manager và Employee
# Employee Management System
