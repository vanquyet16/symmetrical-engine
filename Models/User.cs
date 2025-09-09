using System;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Model đại diện cho tài khoản người dùng
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // Admin hoặc User
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
