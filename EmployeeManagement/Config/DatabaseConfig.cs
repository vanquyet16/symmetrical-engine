using MySql.Data.MySqlClient;
using System.Configuration;

namespace EmployeeManagement.Config
{
    public static class DatabaseConfig
    {
        private static string _connectionString = string.Empty;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = GetConnectionString();
                }
                return _connectionString;
            }
        }

        private static string GetConnectionString()
        {
            // Cấu hình kết nối MySQL
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Database = "EmployeeManagement",
                UserID = "root",
                Password = "", // Thay đổi mật khẩu theo cài đặt MySQL của bạn
                Port = 3306,
                CharacterSet = "utf8mb4",
                SslMode = MySqlSslMode.None,
                AllowUserVariables = true,
                AllowLoadLocalInfile = true
            };

            return builder.ConnectionString;
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
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
    }
}
