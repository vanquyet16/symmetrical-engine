using System;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Model đại diện cho nhân viên
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal SalaryCoefficient { get; set; }
        public decimal Allowance { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        
        // Thuộc tính navigation
        public string DepartmentName { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
    }
}
