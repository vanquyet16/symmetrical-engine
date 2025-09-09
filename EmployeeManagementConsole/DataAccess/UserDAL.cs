using MySql.Data.MySqlClient;
using EmployeeManagement.Models;
using System.Data;

namespace EmployeeManagement.DataAccess
{
    public class UserDAL : BaseDAL
    {
        public User? Login(string username, string password)
        {
            string query = @"
                SELECT u.UserId, u.Username, u.Password, u.RoleId, r.RoleName, 
                       u.IsActive, u.CreatedDate, u.LastLogin
                FROM Users u
                INNER JOIN UserRoles r ON u.RoleId = r.RoleId
                WHERE u.Username = @username AND u.Password = @password AND u.IsActive = 1";

            var parameters = new MySqlParameter[]
            {
                new("@username", username),
                new("@password", password)
            };

            var dataTable = ExecuteQuery(query, parameters);
            
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"].ToString() ?? "",
                    Password = row["Password"].ToString() ?? "",
                    RoleId = Convert.ToInt32(row["RoleId"]),
                    RoleName = row["RoleName"].ToString() ?? "",
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    LastLogin = row["LastLogin"] == DBNull.Value ? null : Convert.ToDateTime(row["LastLogin"])
                };
            }

            return null;
        }

        public bool UpdateLastLogin(int userId)
        {
            string query = "UPDATE Users SET LastLogin = NOW() WHERE UserId = @userId";
            var parameter = new MySqlParameter("@userId", userId);
            
            return ExecuteNonQuery(query, parameter) > 0;
        }

        public List<UserRole> GetAllRoles()
        {
            string query = "SELECT RoleId, RoleName, Description, CreatedDate FROM UserRoles ORDER BY RoleName";
            var dataTable = ExecuteQuery(query);
            var roles = new List<UserRole>();

            foreach (DataRow row in dataTable.Rows)
            {
                roles.Add(new UserRole
                {
                    RoleId = Convert.ToInt32(row["RoleId"]),
                    RoleName = row["RoleName"].ToString() ?? "",
                    Description = row["Description"].ToString() ?? "",
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                });
            }

            return roles;
        }

        public List<User> GetAllUsers()
        {
            string query = @"
                SELECT u.UserId, u.Username, u.Password, u.RoleId, r.RoleName, 
                       u.IsActive, u.CreatedDate, u.LastLogin
                FROM Users u
                INNER JOIN UserRoles r ON u.RoleId = r.RoleId
                ORDER BY u.Username";

            var dataTable = ExecuteQuery(query);
            var users = new List<User>();

            foreach (DataRow row in dataTable.Rows)
            {
                users.Add(new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"].ToString() ?? "",
                    Password = row["Password"].ToString() ?? "",
                    RoleId = Convert.ToInt32(row["RoleId"]),
                    RoleName = row["RoleName"].ToString() ?? "",
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    LastLogin = row["LastLogin"] == DBNull.Value ? null : Convert.ToDateTime(row["LastLogin"])
                });
            }

            return users;
        }

        public bool AddUser(User user)
        {
            string query = @"
                INSERT INTO Users (Username, Password, RoleId, IsActive)
                VALUES (@username, @password, @roleId, @isActive)";

            var parameters = new MySqlParameter[]
            {
                new("@username", user.Username),
                new("@password", user.Password),
                new("@roleId", user.RoleId),
                new("@isActive", user.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateUser(User user)
        {
            string query = @"
                UPDATE Users 
                SET Username = @username, Password = @password, RoleId = @roleId, IsActive = @isActive
                WHERE UserId = @userId";

            var parameters = new MySqlParameter[]
            {
                new("@userId", user.UserId),
                new("@username", user.Username),
                new("@password", user.Password),
                new("@roleId", user.RoleId),
                new("@isActive", user.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserId = @userId";
            var parameter = new MySqlParameter("@userId", userId);
            
            return ExecuteNonQuery(query, parameter) > 0;
        }

        public bool ChangePassword(int userId, string newPassword)
        {
            string query = "UPDATE Users SET Password = @password WHERE UserId = @userId";
            var parameters = new MySqlParameter[]
            {
                new("@password", newPassword),
                new("@userId", userId)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
