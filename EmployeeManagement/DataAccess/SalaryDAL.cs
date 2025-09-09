using MySql.Data.MySqlClient;
using EmployeeManagement.Models;
using System.Data;

namespace EmployeeManagement.DataAccess
{
    public class SalaryDAL : BaseDAL
    {
        public List<SalaryCoefficient> GetSalaryCoefficientsByEmployee(int employeeId)
        {
            string query = @"
                SELECT sc.CoefficientId, sc.EmployeeId, CONCAT(e.FirstName, ' ', e.LastName) as EmployeeName,
                       sc.Coefficient, sc.Allowance, sc.EffectiveDate, sc.EndDate, sc.IsActive, sc.CreatedDate
                FROM SalaryCoefficients sc
                INNER JOIN Employees e ON sc.EmployeeId = e.EmployeeId
                WHERE sc.EmployeeId = @employeeId
                ORDER BY sc.EffectiveDate DESC";

            var parameter = new MySqlParameter("@employeeId", employeeId);
            var dataTable = ExecuteQuery(query, parameter);
            var coefficients = new List<SalaryCoefficient>();

            foreach (DataRow row in dataTable.Rows)
            {
                coefficients.Add(new SalaryCoefficient
                {
                    CoefficientId = Convert.ToInt32(row["CoefficientId"]),
                    EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                    EmployeeName = row["EmployeeName"].ToString() ?? "",
                    Coefficient = Convert.ToDecimal(row["Coefficient"]),
                    Allowance = Convert.ToDecimal(row["Allowance"]),
                    EffectiveDate = Convert.ToDateTime(row["EffectiveDate"]),
                    EndDate = row["EndDate"] == DBNull.Value ? null : Convert.ToDateTime(row["EndDate"]),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                });
            }

            return coefficients;
        }

        public SalaryCoefficient? GetCurrentSalaryCoefficient(int employeeId)
        {
            string query = @"
                SELECT sc.CoefficientId, sc.EmployeeId, CONCAT(e.FirstName, ' ', e.LastName) as EmployeeName,
                       sc.Coefficient, sc.Allowance, sc.EffectiveDate, sc.EndDate, sc.IsActive, sc.CreatedDate
                FROM SalaryCoefficients sc
                INNER JOIN Employees e ON sc.EmployeeId = e.EmployeeId
                WHERE sc.EmployeeId = @employeeId AND sc.IsActive = 1
                ORDER BY sc.EffectiveDate DESC
                LIMIT 1";

            var parameter = new MySqlParameter("@employeeId", employeeId);
            var dataTable = ExecuteQuery(query, parameter);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new SalaryCoefficient
                {
                    CoefficientId = Convert.ToInt32(row["CoefficientId"]),
                    EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                    EmployeeName = row["EmployeeName"].ToString() ?? "",
                    Coefficient = Convert.ToDecimal(row["Coefficient"]),
                    Allowance = Convert.ToDecimal(row["Allowance"]),
                    EffectiveDate = Convert.ToDateTime(row["EffectiveDate"]),
                    EndDate = row["EndDate"] == DBNull.Value ? null : Convert.ToDateTime(row["EndDate"]),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                };
            }

            return null;
        }

        public bool AddSalaryCoefficient(SalaryCoefficient coefficient)
        {
            // Vô hiệu hóa hệ số cũ
            string deactivateQuery = @"
                UPDATE SalaryCoefficients 
                SET IsActive = 0, EndDate = @effectiveDate
                WHERE EmployeeId = @employeeId AND IsActive = 1";

            var deactivateParameters = new MySqlParameter[]
            {
                new("@employeeId", coefficient.EmployeeId),
                new("@effectiveDate", coefficient.EffectiveDate.AddDays(-1))
            };

            ExecuteNonQuery(deactivateQuery, deactivateParameters);

            // Thêm hệ số mới
            string query = @"
                INSERT INTO SalaryCoefficients (EmployeeId, Coefficient, Allowance, EffectiveDate, IsActive)
                VALUES (@employeeId, @coefficient, @allowance, @effectiveDate, @isActive)";

            var parameters = new MySqlParameter[]
            {
                new("@employeeId", coefficient.EmployeeId),
                new("@coefficient", coefficient.Coefficient),
                new("@allowance", coefficient.Allowance),
                new("@effectiveDate", coefficient.EffectiveDate),
                new("@isActive", coefficient.IsActive)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public List<Payroll> GetPayrollsByEmployee(int employeeId, DateTime? startDate = null, DateTime? endDate = null)
        {
            string query = @"
                SELECT p.PayrollId, p.EmployeeId, CONCAT(e.FirstName, ' ', e.LastName) as EmployeeName,
                       e.EmployeeCode, p.PayPeriodStart, p.PayPeriodEnd, p.BasicSalary, p.Coefficient,
                       p.Allowance, p.WorkDays, p.OvertimeHours, p.OvertimePay, p.GrossSalary,
                       p.Tax, p.Insurance, p.NetSalary, p.Status, p.CreatedDate, p.ApprovedDate
                FROM Payrolls p
                INNER JOIN Employees e ON p.EmployeeId = e.EmployeeId
                WHERE p.EmployeeId = @employeeId";

            var parameters = new List<MySqlParameter>
            {
                new("@employeeId", employeeId)
            };

            if (startDate.HasValue)
            {
                query += " AND p.PayPeriodStart >= @startDate";
                parameters.Add(new("@startDate", startDate.Value));
            }

            if (endDate.HasValue)
            {
                query += " AND p.PayPeriodEnd <= @endDate";
                parameters.Add(new("@endDate", endDate.Value));
            }

            query += " ORDER BY p.PayPeriodStart DESC";

            var dataTable = ExecuteQuery(query, parameters.ToArray());
            var payrolls = new List<Payroll>();

            foreach (DataRow row in dataTable.Rows)
            {
                payrolls.Add(new Payroll
                {
                    PayrollId = Convert.ToInt32(row["PayrollId"]),
                    EmployeeId = Convert.ToInt32(row["EmployeeId"]),
                    EmployeeName = row["EmployeeName"].ToString() ?? "",
                    EmployeeCode = row["EmployeeCode"].ToString() ?? "",
                    PayPeriodStart = Convert.ToDateTime(row["PayPeriodStart"]),
                    PayPeriodEnd = Convert.ToDateTime(row["PayPeriodEnd"]),
                    BasicSalary = Convert.ToDecimal(row["BasicSalary"]),
                    Coefficient = Convert.ToDecimal(row["Coefficient"]),
                    Allowance = Convert.ToDecimal(row["Allowance"]),
                    WorkDays = Convert.ToInt32(row["WorkDays"]),
                    OvertimeHours = Convert.ToDecimal(row["OvertimeHours"]),
                    OvertimePay = Convert.ToDecimal(row["OvertimePay"]),
                    GrossSalary = Convert.ToDecimal(row["GrossSalary"]),
                    Tax = Convert.ToDecimal(row["Tax"]),
                    Insurance = Convert.ToDecimal(row["Insurance"]),
                    NetSalary = Convert.ToDecimal(row["NetSalary"]),
                    Status = row["Status"].ToString() ?? "Draft",
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    ApprovedDate = row["ApprovedDate"] == DBNull.Value ? null : Convert.ToDateTime(row["ApprovedDate"])
                });
            }

            return payrolls;
        }

        public bool AddPayroll(Payroll payroll)
        {
            string query = @"
                INSERT INTO Payrolls (EmployeeId, PayPeriodStart, PayPeriodEnd, BasicSalary, Coefficient,
                                    Allowance, WorkDays, OvertimeHours, OvertimePay, GrossSalary,
                                    Tax, Insurance, NetSalary, Status)
                VALUES (@employeeId, @payPeriodStart, @payPeriodEnd, @basicSalary, @coefficient,
                        @allowance, @workDays, @overtimeHours, @overtimePay, @grossSalary,
                        @tax, @insurance, @netSalary, @status)";

            var parameters = new MySqlParameter[]
            {
                new("@employeeId", payroll.EmployeeId),
                new("@payPeriodStart", payroll.PayPeriodStart),
                new("@payPeriodEnd", payroll.PayPeriodEnd),
                new("@basicSalary", payroll.BasicSalary),
                new("@coefficient", payroll.Coefficient),
                new("@allowance", payroll.Allowance),
                new("@workDays", payroll.WorkDays),
                new("@overtimeHours", payroll.OvertimeHours),
                new("@overtimePay", payroll.OvertimePay),
                new("@grossSalary", payroll.GrossSalary),
                new("@tax", payroll.Tax),
                new("@insurance", payroll.Insurance),
                new("@netSalary", payroll.NetSalary),
                new("@status", payroll.Status)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdatePayrollStatus(int payrollId, string status)
        {
            string query = @"
                UPDATE Payrolls 
                SET Status = @status, ApprovedDate = CASE WHEN @status = 'Approved' THEN NOW() ELSE ApprovedDate END
                WHERE PayrollId = @payrollId";

            var parameters = new MySqlParameter[]
            {
                new("@payrollId", payrollId),
                new("@status", status)
            };

            return ExecuteNonQuery(query, parameters) > 0;
        }

        public decimal CalculateSalary(int employeeId, DateTime startDate, DateTime endDate, int workDays, decimal overtimeHours = 0)
        {
            var coefficient = GetCurrentSalaryCoefficient(employeeId);
            if (coefficient == null) return 0;

            // Lấy lương cơ bản từ chức vụ
            string query = @"
                SELECT p.BaseSalary 
                FROM Employees e
                INNER JOIN Positions p ON e.PositionId = p.PositionId
                WHERE e.EmployeeId = @employeeId";

            var parameter = new MySqlParameter("@employeeId", employeeId);
            var baseSalary = Convert.ToDecimal(ExecuteScalar(query, parameter));

            // Tính lương: (Lương cơ bản * Hệ số + Phụ cấp) * (Số ngày công / 22) + Lương làm thêm giờ
            var dailySalary = (baseSalary * coefficient.Coefficient + coefficient.Allowance) / 22;
            var monthlySalary = dailySalary * workDays;
            var overtimePay = overtimeHours * (dailySalary / 8) * 1.5m; // Làm thêm giờ được tính 1.5 lần

            return monthlySalary + overtimePay;
        }
    }
}
