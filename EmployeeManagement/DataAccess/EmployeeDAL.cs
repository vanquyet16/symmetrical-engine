using MySql.Data.MySqlClient;
using EmployeeManagement.Models;
using System.Data;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeDAL : BaseDAL
    {
        public List<Employee> GetAllEmployees()
        {
            string query = @"
                SELECT e.EmployeeId, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.Phone, 
                       e.Address, e.DateOfBirth, e.Gender, e.DepartmentId, d.DepartmentName,
                       e.PositionId, p.PositionName, e.HireDate, e.IsActive, e.CreatedDate, e.UpdatedDate
                FROM Employees e
                LEFT JOIN Departments d ON e.DepartmentId = d.DepartmentId
                LEFT JOIN Positions p ON e.PositionId = p.PositionId
                ORDER BY e.EmployeeCode";

            var dataTable = ExecuteQuery(query);
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

        public Employee? GetEmployeeById(int employeeId)
        {
            string query = @"
                SELECT e.EmployeeId, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.Phone, 
                       e.Address, e.DateOfBirth, e.Gender, e.DepartmentId, d.DepartmentName,
                       e.PositionId, p.PositionName, e.HireDate, e.IsActive, e.CreatedDate, e.UpdatedDate
                FROM Employees e
                LEFT JOIN Departments d ON e.DepartmentId = d.DepartmentId
                LEFT JOIN Positions p ON e.PositionId = p.PositionId
                WHERE e.EmployeeId = @employeeId";

            var parameter = new MySqlParameter("@employeeId", employeeId);
            var dataTable = ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new Employee
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
                };
            }

            return null;
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            string query = @"
                SELECT e.EmployeeId, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.Phone, 
                       e.Address, e.DateOfBirth, e.Gender, e.DepartmentId, d.DepartmentName,
                       e.PositionId, p.PositionName, e.HireDate, e.IsActive, e.CreatedDate, e.UpdatedDate
                FROM Employees e
                LEFT JOIN Departments d ON e.DepartmentId = d.DepartmentId
                LEFT JOIN Positions p ON e.PositionId = p.PositionId
                WHERE e.EmployeeCode LIKE @searchTerm 
                   OR e.FirstName LIKE @searchTerm 
                   OR e.LastName LIKE @searchTerm 
                   OR d.DepartmentName LIKE @searchTerm
                ORDER BY e.EmployeeCode";

            var parameter = new MySqlParameter("@searchTerm", $"%{searchTerm}%");
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

        public bool AddEmployee(Employee employee)
        {
            string query = @"
                INSERT INTO Employees (EmployeeCode, FirstName, LastName, Email, Phone, Address, 
                                     DateOfBirth, Gender, DepartmentId, PositionId, HireDate, IsActive)
                VALUES (@employeeCode, @firstName, @lastName, @email, @phone, @address, 
                        @dateOfBirth, @gender, @departmentId, @positionId, @hireDate, @isActive)";

            var parameters = new MySqlParameter[]
            {
                new("@employeeCode", employee.EmployeeCode),
                new("@firstName", employee.FirstName),
                new("@lastName", employee.LastName),
                new("@email", employee.Email),
                new("@phone", employee.Phone),
                new("@address", employee.Address),
                new("@dateOfBirth", employee.DateOfBirth),
                new("@gender", employee.Gender),
                new("@departmentId", employee.DepartmentId),
                new("@positionId", employee.PositionId),
                new("@hireDate", employee.HireDate),
                new("@isActive", employee.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            string query = @"
                UPDATE Employees 
                SET EmployeeCode = @employeeCode, FirstName = @firstName, LastName = @lastName,
                    Email = @email, Phone = @phone, Address = @address, DateOfBirth = @dateOfBirth,
                    Gender = @gender, DepartmentId = @departmentId, PositionId = @positionId,
                    HireDate = @hireDate, IsActive = @isActive, UpdatedDate = NOW()
                WHERE EmployeeId = @employeeId";

            var parameters = new MySqlParameter[]
            {
                new("@employeeId", employee.EmployeeId),
                new("@employeeCode", employee.EmployeeCode),
                new("@firstName", employee.FirstName),
                new("@lastName", employee.LastName),
                new("@email", employee.Email),
                new("@phone", employee.Phone),
                new("@address", employee.Address),
                new("@dateOfBirth", employee.DateOfBirth),
                new("@gender", employee.Gender),
                new("@departmentId", employee.DepartmentId),
                new("@positionId", employee.PositionId),
                new("@hireDate", employee.HireDate),
                new("@isActive", employee.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteEmployee(int employeeId)
        {
            string query = "DELETE FROM Employees WHERE EmployeeId = @employeeId";
            var parameter = new MySqlParameter("@employeeId", employeeId);
            
            return ExecuteNonQuery(query, parameter) > 0;
        }

        public bool IsEmployeeCodeExists(string employeeCode, int? excludeEmployeeId = null)
        {
            string query = "SELECT COUNT(*) FROM Employees WHERE EmployeeCode = @employeeCode";
            var parameters = new List<MySqlParameter>
            {
                new("@employeeCode", employeeCode)
            };

            if (excludeEmployeeId.HasValue)
            {
                query += " AND EmployeeId != @excludeEmployeeId";
                parameters.Add(new("@excludeEmployeeId", excludeEmployeeId.Value));
            }

            var result = ExecuteScalar(query, parameters.ToArray());
            return Convert.ToInt32(result) > 0;
        }
    }
}
