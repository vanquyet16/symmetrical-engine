using System;
using System.IO;

namespace EmployeeManagement.Utils
{
    public static class Logger
    {
        private static readonly object Sync = new object();

        private static string GetLogFilePath()
        {
            var baseDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var appDir = Path.Combine(baseDir, "EmployeeManagement");
            Directory.CreateDirectory(appDir);
            return Path.Combine(appDir, "logs.txt");
        }

        public static void Log(string message)
        {
            try
            {
                var path = GetLogFilePath();
                var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
                lock (Sync)
                {
                    File.AppendAllText(path, line + Environment.NewLine);
                }
            }
            catch
            {
                // Swallow logging errors silently
            }
        }

        public static void Log(Exception ex, string? context = null)
        {
            var prefix = string.IsNullOrWhiteSpace(context) ? "" : ($"{context}: ");
            Log(prefix + ex.ToString());
        }
    }
}


