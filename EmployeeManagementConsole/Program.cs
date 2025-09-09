using EmployeeManagement.Config;
using EmployeeManagement.Utils;
using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;

namespace EmployeeManagementConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== HỆ THỐNG QUẢN LÝ NHÂN VIÊN ===");
            Console.WriteLine("Đang khởi tạo database...");

            try
            {
                // Tự động tạo database và bảng nếu chưa tồn tại
                DatabaseInitializer.InitializeDatabase();
                Console.WriteLine("✅ Database đã được khởi tạo thành công!");
                
                // Kiểm tra kết nối database
                if (DatabaseConfig.TestConnection())
                {
                    Console.WriteLine("✅ Kết nối database thành công!");
                    
                    // Test các chức năng cơ bản
                    TestBasicFunctions();
                    
                    Console.WriteLine("\n🎉 Hệ thống đã sẵn sàng!");
                    Console.WriteLine("\n📋 Tài khoản mặc định:");
                    Console.WriteLine("   Admin: admin / admin123");
                    Console.WriteLine("   HR: hr / hr123");
                    Console.WriteLine("   Manager: manager / manager123");
                    Console.WriteLine("\n💡 Để chạy giao diện WinForms, hãy sử dụng Windows hoặc Visual Studio trên Windows.");
                }
                else
                {
                    Console.WriteLine("❌ Không thể kết nối đến database!");
                    Console.WriteLine("Vui lòng kiểm tra:");
                    Console.WriteLine("1. MySQL đã được cài đặt và đang chạy");
                    Console.WriteLine("2. Cấu hình kết nối trong DatabaseConfig.cs");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi khởi tạo ứng dụng: {ex.Message}");
                Console.WriteLine("\n🔧 Hướng dẫn khắc phục:");
                Console.WriteLine("1. Cài đặt MySQL: brew install mysql");
                Console.WriteLine("2. Khởi động MySQL: brew services start mysql");
                Console.WriteLine("3. Kiểm tra cấu hình trong DatabaseConfig.cs");
            }

            Console.WriteLine("\nNhấn Enter để thoát...");
            Console.ReadLine();
        }

        static void TestBasicFunctions()
        {
            try
            {
                Console.WriteLine("\n🔍 Đang test các chức năng cơ bản...");
                
                // Test UserDAL
                var userDAL = new UserDAL();
                var users = userDAL.GetAllUsers();
                Console.WriteLine($"✅ Tìm thấy {users.Count} người dùng trong hệ thống");
                
                // Test DepartmentDAL
                var departmentDAL = new DepartmentDAL();
                var departments = departmentDAL.GetAllDepartments();
                Console.WriteLine($"✅ Tìm thấy {departments.Count} phòng ban");
                
                // Test PositionDAL
                var positionDAL = new PositionDAL();
                var positions = positionDAL.GetAllPositions();
                Console.WriteLine($"✅ Tìm thấy {positions.Count} chức vụ");
                
                // Test EmployeeDAL
                var employeeDAL = new EmployeeDAL();
                var employees = employeeDAL.GetAllEmployees();
                Console.WriteLine($"✅ Tìm thấy {employees.Count} nhân viên");
                
                Console.WriteLine("\n📊 Thống kê hệ thống:");
                Console.WriteLine($"   - Người dùng: {users.Count}");
                Console.WriteLine($"   - Phòng ban: {departments.Count}");
                Console.WriteLine($"   - Chức vụ: {positions.Count}");
                Console.WriteLine($"   - Nhân viên: {employees.Count}");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi test chức năng: {ex.Message}");
            }
        }
    }
}