using System;
using System.Windows.Forms;
using EmployeeManagement.Forms;
using EmployeeManagement.Utils;

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
            try
            {
                // Bật bắt lỗi toàn cục để không crash im lặng
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += (s, e) =>
                {
                    Logger.Log(e.Exception, "UI ThreadException");
                    MessageBox.Show("Unhandled UI exception: " + e.Exception, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
                AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                {
                    var ex = e.ExceptionObject as Exception;
                    if (ex != null) Logger.Log(ex, "Domain UnhandledException");
                    MessageBox.Show("Unhandled domain exception: " + (ex?.ToString() ?? e.ExceptionObject.ToString()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                // Khởi tạo form đăng nhập
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "Startup error");
                MessageBox.Show("Startup error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
