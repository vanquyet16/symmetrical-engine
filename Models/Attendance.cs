using System;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Model đại diện cho chấm công
    /// </summary>
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public string Status { get; set; } = string.Empty; // Present, Absent, Late, Leave
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        
        // Thuộc tính navigation
        public string EmployeeName { get; set; } = string.Empty;
    }
}
