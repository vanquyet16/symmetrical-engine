using EmployeeManagement.Config;
using EmployeeManagement.Utils;

namespace EmployeeManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static void Main()
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
    }
}