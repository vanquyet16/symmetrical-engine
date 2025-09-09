# Hệ thống quản lý nhân viên

## Mô tả

Hệ thống quản lý nhân viên được phát triển bằng C# WinForms và MySQL, cung cấp đầy đủ các chức năng quản lý nhân sự cho doanh nghiệp.

## Yêu cầu hệ thống

- .NET 8.0 SDK
- MySQL Server 8.0 trở lên
- Windows 10/11

## Cài đặt

### 1. Cài đặt MySQL

- Tải và cài đặt MySQL Server từ: https://dev.mysql.com/downloads/mysql/
- Tạo user `root` với password (hoặc để trống)
- Đảm bảo MySQL service đang chạy

### 2. Cấu hình kết nối database

Mở file `Database/DatabaseHelper.cs` và cập nhật chuỗi kết nối:

```csharp
private static string connectionString = "Server=localhost;Database=employee_management;Uid=root;Pwd=YOUR_PASSWORD;";
```

### 3. Chạy ứng dụng

```bash
dotnet run
```

## Tài khoản mặc định

- **Username:** admin
- **Password:** admin123
- **Quyền:** Admin (có đầy đủ quyền)

## Chức năng chính

### 1. Đăng nhập & Phân quyền

- Đăng nhập bằng tài khoản Admin/User
- Admin: Thêm, sửa, xóa nhân viên
- User: Chỉ được xem thông tin

### 2. Quản lý nhân viên

- Thêm mới nhân viên
- Sửa thông tin nhân viên
- Xóa nhân viên
- Tìm kiếm theo tên, mã, phòng ban
- Xuất danh sách ra Excel

### 3. Quản lý phòng ban

- Tạo, chỉnh sửa, xóa phòng ban
- Liên kết nhân viên với phòng ban
- Chỉ định trưởng phòng

### 4. Quản lý chức vụ

- Danh mục chức vụ (nhân viên, trưởng phòng, giám đốc...)
- Gán chức vụ cho từng nhân viên

### 5. Quản lý lương

- Nhập hệ số lương, phụ cấp
- Tính lương theo công thức: (lương cơ bản \* hệ số + phụ cấp)

### 6. Chấm công

- Nhập ngày đi làm / nghỉ phép / đi trễ
- Tự động tính số ngày công

### 7. Thống kê & Báo cáo

- Thống kê số lượng nhân viên theo phòng ban, chức vụ
- Báo cáo bảng lương hàng tháng

### 8. Tìm kiếm nâng cao

- Tìm kiếm nhân viên theo nhiều điều kiện (tên + phòng ban + mức lương)

### 9. Quản lý tài khoản người dùng

- Thêm, sửa, xóa tài khoản đăng nhập
- Đổi mật khẩu

### 10. Xuất dữ liệu

- Xuất danh sách nhân viên hoặc bảng lương ra Excel/PDF

### 11. Sao lưu & Phục hồi dữ liệu

- Backup database
- Restore khi cần

## Cấu trúc database

### Bảng users

- id: Khóa chính
- username: Tên đăng nhập
- password: Mật khẩu
- full_name: Họ tên
- role: Vai trò (Admin/User)
- created_date: Ngày tạo
- is_active: Trạng thái hoạt động

### Bảng departments

- id: Khóa chính
- name: Tên phòng ban
- description: Mô tả
- manager_id: ID trưởng phòng
- created_date: Ngày tạo
- is_active: Trạng thái hoạt động

### Bảng positions

- id: Khóa chính
- name: Tên chức vụ
- description: Mô tả
- min_salary: Lương tối thiểu
- max_salary: Lương tối đa
- created_date: Ngày tạo
- is_active: Trạng thái hoạt động

### Bảng employees

- id: Khóa chính
- employee_code: Mã nhân viên
- full_name: Họ tên
- date_of_birth: Ngày sinh
- gender: Giới tính
- address: Địa chỉ
- phone_number: Số điện thoại
- email: Email
- department_id: ID phòng ban
- position_id: ID chức vụ
- start_date: Ngày vào làm
- basic_salary: Lương cơ bản
- salary_coefficient: Hệ số lương
- allowance: Phụ cấp
- is_active: Trạng thái hoạt động
- created_date: Ngày tạo

### Bảng attendance

- id: Khóa chính
- employee_id: ID nhân viên
- date: Ngày
- check_in_time: Giờ vào
- check_out_time: Giờ ra
- status: Trạng thái (Present/Absent/Late/Leave)
- notes: Ghi chú
- created_date: Ngày tạo

### Bảng salary

- id: Khóa chính
- employee_id: ID nhân viên
- month: Tháng
- year: Năm
- basic_salary: Lương cơ bản
- salary_coefficient: Hệ số lương
- allowance: Phụ cấp
- working_days: Số ngày làm việc
- total_days: Tổng số ngày trong tháng
- total_salary: Tổng lương
- created_date: Ngày tạo
- is_paid: Đã thanh toán

## Lưu ý

- Database sẽ được tự động tạo khi chạy ứng dụng lần đầu
- Dữ liệu mẫu sẽ được thêm vào tự động
- Đảm bảo MySQL service đang chạy trước khi khởi động ứng dụng

## Hỗ trợ

Nếu gặp vấn đề, vui lòng kiểm tra:

1. MySQL service có đang chạy không
2. Chuỗi kết nối database có đúng không
3. User MySQL có quyền tạo database không
