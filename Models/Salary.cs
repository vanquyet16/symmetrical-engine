using System;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Model đại diện cho bảng lương
    /// </summary>
    public class Salary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal SalaryCoefficient { get; set; }
        public decimal Allowance { get; set; }
        public int WorkingDays { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalSalary { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPaid { get; set; }
        
        // Thuộc tính navigation
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
    }
}
