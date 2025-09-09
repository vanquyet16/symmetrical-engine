using System;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Model đại diện cho phòng ban
    /// </summary>
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ManagerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        
        // Thuộc tính navigation
        public string ManagerName { get; set; } = string.Empty;
    }
}
