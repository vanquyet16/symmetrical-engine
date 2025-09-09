using EmployeeManagement.Models;

namespace EmployeeManagement.Utils
{
    public static class CurrentUser
    {
        public static User? User { get; set; }

        public static bool IsAdmin => User?.RoleName == "Admin";
        public static bool IsHR => User?.RoleName == "HR";
        public static bool IsManager => User?.RoleName == "Manager";
        public static bool IsEmployee => User?.RoleName == "Employee";

        public static bool CanManageEmployees => IsAdmin || IsHR;
        public static bool CanManageDepartments => IsAdmin || IsHR;
        public static bool CanManagePositions => IsAdmin || IsHR;
        public static bool CanManageSalary => IsAdmin || IsHR;
        public static bool CanViewReports => IsAdmin || IsHR || IsManager;
    }
}
