using MySql.Data.MySqlClient;
using EmployeeManagement.Models;
using System.Data;

namespace EmployeeManagement.DataAccess
{
    public class PositionDAL : BaseDAL
    {
        public List<Position> GetAllPositions()
        {
            string query = @"
                SELECT PositionId, PositionName, Description, BaseSalary, IsActive, CreatedDate
                FROM Positions
                ORDER BY PositionName";

            var dataTable = ExecuteQuery(query);
            var positions = new List<Position>();

            foreach (DataRow row in dataTable.Rows)
            {
                positions.Add(new Position
                {
                    PositionId = Convert.ToInt32(row["PositionId"]),
                    PositionName = row["PositionName"].ToString() ?? "",
                    Description = row["Description"].ToString() ?? "",
                    BaseSalary = Convert.ToDecimal(row["BaseSalary"]),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                });
            }

            return positions;
        }

        public Position? GetPositionById(int positionId)
        {
            string query = @"
                SELECT PositionId, PositionName, Description, BaseSalary, IsActive, CreatedDate
                FROM Positions
                WHERE PositionId = @positionId";

            var parameter = new MySqlParameter("@positionId", positionId);
            var dataTable = ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new Position
                {
                    PositionId = Convert.ToInt32(row["PositionId"]),
                    PositionName = row["PositionName"].ToString() ?? "",
                    Description = row["Description"].ToString() ?? "",
                    BaseSalary = Convert.ToDecimal(row["BaseSalary"]),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                };
            }

            return null;
        }

        public bool AddPosition(Position position)
        {
            string query = @"
                INSERT INTO Positions (PositionName, Description, BaseSalary, IsActive)
                VALUES (@positionName, @description, @baseSalary, @isActive)";

            var parameters = new MySqlParameter[]
            {
                new("@positionName", position.PositionName),
                new("@description", position.Description),
                new("@baseSalary", position.BaseSalary),
                new("@isActive", position.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdatePosition(Position position)
        {
            string query = @"
                UPDATE Positions 
                SET PositionName = @positionName, Description = @description, 
                    BaseSalary = @baseSalary, IsActive = @isActive
                WHERE PositionId = @positionId";

            var parameters = new MySqlParameter[]
            {
                new("@positionId", position.PositionId),
                new("@positionName", position.PositionName),
                new("@description", position.Description),
                new("@baseSalary", position.BaseSalary),
                new("@isActive", position.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeletePosition(int positionId)
        {
            // Kiểm tra xem có nhân viên nào có chức vụ này không
            string checkQuery = "SELECT COUNT(*) FROM Employees WHERE PositionId = @positionId";
            var checkParameter = new MySqlParameter("@positionId", positionId);
            var count = Convert.ToInt32(ExecuteScalar(checkQuery, checkParameter));

            if (count > 0)
            {
                return false; // Không thể xóa chức vụ có nhân viên
            }

            string query = "DELETE FROM Positions WHERE PositionId = @positionId";
            var parameter = new MySqlParameter("@positionId", positionId);
            
            return ExecuteNonQuery(query, parameter) > 0;
        }

        public bool IsPositionNameExists(string positionName, int? excludePositionId = null)
        {
            string query = "SELECT COUNT(*) FROM Positions WHERE PositionName = @positionName";
            var parameters = new List<MySqlParameter>
            {
                new("@positionName", positionName)
            };

            if (excludePositionId.HasValue)
            {
                query += " AND PositionId != @excludePositionId";
                parameters.Add(new("@excludePositionId", excludePositionId.Value));
            }

            var result = ExecuteScalar(query, parameters.ToArray());
            return Convert.ToInt32(result) > 0;
        }

        public List<Employee> GetEmployeesByPosition(int positionId)
        {
            string query = @"
                SELECT e.EmployeeId, e.EmployeeCode, e.FirstName, e.LastName, e.Email, e.Phone, 
                       e.Address, e.DateOfBirth, e.Gender, e.DepartmentId, d.DepartmentName,
                       e.PositionId, p.PositionName, e.HireDate, e.IsActive, e.CreatedDate, e.UpdatedDate
                FROM Employees e
                LEFT JOIN Departments d ON e.DepartmentId = d.DepartmentId
                LEFT JOIN Positions p ON e.PositionId = p.PositionId
                WHERE e.PositionId = @positionId AND e.IsActive = 1
                ORDER BY e.EmployeeCode";

            var parameter = new MySqlParameter("@positionId", positionId);
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
