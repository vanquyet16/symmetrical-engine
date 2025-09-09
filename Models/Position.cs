using System;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Model đại diện cho chức vụ
    /// </summary>
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
