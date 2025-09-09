using MySql.Data.MySqlClient;
using EmployeeManagement.Models;
using System.Data;

namespace EmployeeManagement.DataAccess
{
    public class DepartmentDAL : BaseDAL
    {
        public List<Department> GetAllDepartments()
        {
            string query = @"
                SELECT d.DepartmentId, d.DepartmentName, d.Description, d.ManagerId, 
                       CONCAT(e.FirstName, ' ', e.LastName) as ManagerName,
                       d.IsActive, d.CreatedDate, d.UpdatedDate
                FROM Departments d
                LEFT JOIN Employees e ON d.ManagerId = e.EmployeeId
                ORDER BY d.DepartmentName";

            var dataTable = ExecuteQuery(query);
            var departments = new List<Department>();

            foreach (DataRow row in dataTable.Rows)
            {
                departments.Add(new Department
                {
                    DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                    DepartmentName = row["DepartmentName"].ToString() ?? "",
                    Description = row["Description"].ToString() ?? "",
                    ManagerId = row["ManagerId"] == DBNull.Value ? null : Convert.ToInt32(row["ManagerId"]),
                    ManagerName = row["ManagerName"].ToString() ?? "",
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return departments;
        }

        public Department? GetDepartmentById(int departmentId)
        {
            string query = @"
                SELECT d.DepartmentId, d.DepartmentName, d.Description, d.ManagerId, 
                       CONCAT(e.FirstName, ' ', e.LastName) as ManagerName,
                       d.IsActive, d.CreatedDate, d.UpdatedDate
                FROM Departments d
                LEFT JOIN Employees e ON d.ManagerId = e.EmployeeId
                WHERE d.DepartmentId = @departmentId";

            var parameter = new MySqlParameter("@departmentId", departmentId);
            var dataTable = ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new Department
                {
                    DepartmentId = Convert.ToInt32(row["DepartmentId"]),
                    DepartmentName = row["DepartmentName"].ToString() ?? "",
                    Description = row["Description"].ToString() ?? "",
                    ManagerId = row["ManagerId"] == DBNull.Value ? null : Convert.ToInt32(row["ManagerId"]),
                    ManagerName = row["ManagerName"].ToString() ?? "",
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                };
            }

            return null;
        }

        public bool AddDepartment(Department department)
        {
            string query = @"
                INSERT INTO Departments (DepartmentName, Description, ManagerId, IsActive)
                VALUES (@departmentName, @description, @managerId, @isActive)";

            var parameters = new MySqlParameter[]
            {
                new("@departmentName", department.DepartmentName),
                new("@description", department.Description),
                new("@managerId", department.ManagerId),
                new("@isActive", department.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateDepartment(Department department)
        {
            string query = @"
                UPDATE Departments 
                SET DepartmentName = @departmentName, Description = @description, 
                    ManagerId = @managerId, IsActive = @isActive, UpdatedDate = NOW()
                WHERE DepartmentId = @departmentId";

            var parameters = new MySqlParameter[]
            {
                new("@departmentId", department.DepartmentId),
                new("@departmentName", department.DepartmentName),
                new("@description", department.Description),
                new("@managerId", department.ManagerId),
                new("@isActive", department.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteDepartment(int departmentId)
        {
            // Kiểm tra xem có nhân viên nào thuộc phòng ban này không
            string checkQuery = "SELECT COUNT(*) FROM Employees WHERE DepartmentId = @departmentId";
            var checkParameter = new MySqlParameter("@departmentId", departmentId);
            var count = Convert.ToInt32(ExecuteScalar(checkQuery, checkParameter));

            if (count > 0)
            {
                return false; // Không thể xóa phòng ban có nhân viên
            }

            string query = "DELETE FROM Departments WHERE DepartmentId = @departmentId";
            var parameter = new MySqlParameter("@departmentId", departmentId);
            
            return ExecuteNonQuery(query, parameter) > 0;
        }

        public bool IsDepartmentNameExists(string departmentName, int? excludeDepartmentId = null)
        {
            string query = "SELECT COUNT(*) FROM Departments WHERE DepartmentName = @departmentName";
            var parameters = new List<MySqlParameter>
            {
                new("@departmentName", departmentName)
            };

            if (excludeDepartmentId.HasValue)
            {
                query += " AND DepartmentId != @excludeDepartmentId";
                parameters.Add(new("@excludeDepartmentId", excludeDepartmentId.Value));
            }

            var result = ExecuteScalar(query, parameters.ToArray());
            return Convert.ToInt32(result) > 0;
        }

        public List<Employee> GetEmployeesByDepartment(int departmentId)
        {
            string query = @"
                SELECT e.EmployeeId, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.Phone, 
                       e.Address, e.DateOfBirth, e.Gender, e.DepartmentId, d.DepartmentName,
                       e.PositionId, p.PositionName, e.HireDate, e.IsActive, e.CreatedDate, e.UpdatedDate
                FROM Employees e
                LEFT JOIN Departments d ON e.DepartmentId = d.DepartmentId
                LEFT JOIN Positions p ON e.PositionId = p.PositionId
                WHERE e.DepartmentId = @departmentId AND e.IsActive = 1
                ORDER BY e.EmployeeCode";

            var parameter = new MySqlParameter("@departmentId", departmentId);
            var dataTable = ExecuteQuery(query, parameter);
            var employees = new List<Employee>();

            foreach (DataRow row in dataTable.Rows)
            {
                employees.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                    EmployeeCode = row["EmployeeCode"].ToString() ?? "",
                    FirstName = row["FirstName"].ToString() ?? "",
                    LastName = row["LastName"].ToString() ?? "",
                    Email = row["Email"].ToString() ?? "",
                    Phone = row["Phone"].ToString() ?? "",
                    Address = row["Address"].ToString() ?? "",
                    DateOfBirth = row["DateOfBirth"] == DBNull.Value ? null : Convert.ToDateTime(row["DateOfBirth"]),
                    Gender = row["Gender"].ToString() ?? "Male",
                    DepartmentId = row["DepartmentId"] == DBNull.Value ? null : Convert.ToInt32(row["DepartmentId"]),
                    DepartmentName = row["DepartmentName"].ToString() ?? "",
                    PositionId = row["PositionId"] == DBNull.Value ? null : Convert.ToInt32(row["PositionId"]),
                    PositionName = row["PositionName"].ToString() ?? "",
                    HireDate = Convert.ToDateTime(row["HireDate"]),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                });
            }

            return employees;
        }
    }
}
