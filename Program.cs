using System;
using System.Windows.Forms;
using EmployeeManagement.Forms;

namespace EmployeeManagement
{
    internal static class Program
    {
        /// <summary>
        /// Ứng dụng chính của chương trình quản lý nhân viên
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Khởi tạo form đăng nhập
            Application.Run(new LoginForm());
        }
    }
}
