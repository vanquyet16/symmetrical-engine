using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using EmployeeManagement.Utils;

namespace EmployeeManagement.Forms
{
    public partial class SalaryManagementForm : Form
    {
        private SalaryDAL salaryDAL;
        private EmployeeDAL employeeDAL;
        private List<Employee> employees;
        private List<Payroll> payrolls;

        public SalaryManagementForm()
        {
            InitializeComponent();
            salaryDAL = new SalaryDAL();
            employeeDAL = new EmployeeDAL();
            LoadData();
            SetupPermissions();
        }

        private void LoadData()
        {
            try
            {
                employees = employeeDAL.GetAllEmployees();
                LoadEmployeeComboBox();
                LoadPayrolls();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployeeComboBox()
        {
            cmbEmployee.DataSource = employees.Where(e => e.IsActive).ToList();
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "EmployeeId";
            cmbEmployee.SelectedIndex = -1;
        }

        private void LoadPayrolls()
        {
            try
            {
                if (cmbEmployee.SelectedValue != null)
                {
                    int employeeId = (int)cmbEmployee.SelectedValue;
                    DateTime startDate = dtpStartDate.Value.Date;
                    DateTime endDate = dtpEndDate.Value.Date;
                    
                    payrolls = salaryDAL.GetPayrollsByEmployee(employeeId, startDate, endDate);
                    dgvPayrolls.DataSource = payrolls;
                    dgvPayrolls.Columns["PayrollId"].Visible = false;
                    dgvPayrolls.Columns["EmployeeId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải bảng lương: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupPermissions()
        {
            bool canEdit = CurrentUser.CanManageSalary;
            btnAddCoefficient.Enabled = canEdit;
            btnCalculateSalary.Enabled = canEdit;
            btnSavePayroll.Enabled = canEdit;
            btnApprovePayroll.Enabled = canEdit;
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue != null)
            {
                LoadCurrentCoefficient();
                LoadPayrolls();
            }
        }

        private void LoadCurrentCoefficient()
        {
            if (cmbEmployee.SelectedValue != null)
            {
                try
                {
                    int employeeId = (int)cmbEmployee.SelectedValue;
                    var coefficient = salaryDAL.GetCurrentSalaryCoefficient(employeeId);
                    
                    if (coefficient != null)
                    {
                        numCoefficient.Value = coefficient.Coefficient;
                        numAllowance.Value = coefficient.Allowance;
                        dtpEffectiveDate.Value = coefficient.EffectiveDate;
                    }
                    else
                    {
                        numCoefficient.Value = 1.0m;
                        numAllowance.Value = 0;
                        dtpEffectiveDate.Value = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tải hệ số lương: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddCoefficient_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateCoefficientForm())
            {
                try
                {
                    var coefficient = new SalaryCoefficient
                    {
                        EmployeeId = (int)cmbEmployee.SelectedValue,
                        Coefficient = numCoefficient.Value,
                        Allowance = numAllowance.Value,
                        EffectiveDate = dtpEffectiveDate.Value.Date,
                        IsActive = true
                    };

                    bool success = salaryDAL.AddSalaryCoefficient(coefficient);
                    if (success)
                    {
                        MessageBox.Show("Thêm hệ số lương thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCurrentCoefficient();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thêm hệ số lương!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCalculateSalary_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidatePayrollForm())
            {
                try
                {
                    int employeeId = (int)cmbEmployee.SelectedValue;
                    DateTime startDate = dtpPayPeriodStart.Value.Date;
                    DateTime endDate = dtpPayPeriodEnd.Value.Date;
                    int workDays = (int)numWorkDays.Value;
                    decimal overtimeHours = numOvertimeHours.Value;

                    decimal calculatedSalary = salaryDAL.CalculateSalary(employeeId, startDate, endDate, workDays, overtimeHours);
                    
                    // Hiển thị kết quả tính lương
                    var coefficient = salaryDAL.GetCurrentSalaryCoefficient(employeeId);
                    if (coefficient != null)
                    {
                        lblCalculatedSalary.Text = $"Lương tính được: {calculatedSalary:N0} VNĐ";
                        lblCalculatedSalary.Visible = true;
                        
                        // Tự động điền vào form bảng lương
                        numBasicSalary.Value = calculatedSalary;
                        numCoefficientPayroll.Value = coefficient.Coefficient;
                        numAllowancePayroll.Value = coefficient.Allowance;
                        numWorkDaysPayroll.Value = workDays;
                        numOvertimeHoursPayroll.Value = overtimeHours;
                        numGrossSalary.Value = calculatedSalary;
                        numNetSalary.Value = calculatedSalary; // Chưa trừ thuế và bảo hiểm
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tính lương: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSavePayroll_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidatePayrollForm())
            {
                try
                {
                    var payroll = new Payroll
                    {
                        EmployeeId = (int)cmbEmployee.SelectedValue,
                        PayPeriodStart = dtpPayPeriodStart.Value.Date,
                        PayPeriodEnd = dtpPayPeriodEnd.Value.Date,
                        BasicSalary = numBasicSalary.Value,
                        Coefficient = numCoefficientPayroll.Value,
                        Allowance = numAllowancePayroll.Value,
                        WorkDays = (int)numWorkDaysPayroll.Value,
                        OvertimeHours = numOvertimeHoursPayroll.Value,
                        OvertimePay = numOvertimePay.Value,
                        GrossSalary = numGrossSalary.Value,
                        Tax = numTax.Value,
                        Insurance = numInsurance.Value,
                        NetSalary = numNetSalary.Value,
                        Status = "Draft"
                    };

                    bool success = salaryDAL.AddPayroll(payroll);
                    if (success)
                    {
                        MessageBox.Show("Lưu bảng lương thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPayrolls();
                        ClearPayrollForm();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi lưu bảng lương!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnApprovePayroll_Click(object sender, EventArgs e)
        {
            if (dgvPayrolls.SelectedRows.Count > 0)
            {
                var selectedPayroll = (Payroll)dgvPayrolls.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Bạn có chắc chắn muốn duyệt bảng lương của {selectedPayroll.EmployeeName}?", 
                    "Xác nhận duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = salaryDAL.UpdatePayrollStatus(selectedPayroll.PayrollId, "Approved");
                        if (success)
                        {
                            MessageBox.Show("Duyệt bảng lương thành công!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadPayrolls();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi duyệt bảng lương!", "Lỗi", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bảng lương cần duyệt!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPayrolls();
        }

        private bool ValidateCoefficientForm()
        {
            if (numCoefficient.Value <= 0)
            {
                MessageBox.Show("Hệ số lương phải lớn hơn 0!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCoefficient.Focus();
                return false;
            }

            if (numAllowance.Value < 0)
            {
                MessageBox.Show("Phụ cấp không được âm!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAllowance.Focus();
                return false;
            }

            return true;
        }

        private bool ValidatePayrollForm()
        {
            if (dtpPayPeriodStart.Value >= dtpPayPeriodEnd.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpPayPeriodStart.Focus();
                return false;
            }

            if (numWorkDays.Value <= 0)
            {
                MessageBox.Show("Số ngày công phải lớn hơn 0!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numWorkDays.Focus();
                return false;
            }

            if (numBasicSalary.Value <= 0)
            {
                MessageBox.Show("Lương cơ bản phải lớn hơn 0!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numBasicSalary.Focus();
                return false;
            }

            return true;
        }

        private void ClearPayrollForm()
        {
            numBasicSalary.Value = 0;
            numCoefficientPayroll.Value = 1;
            numAllowancePayroll.Value = 0;
            numWorkDaysPayroll.Value = 0;
            numOvertimeHoursPayroll.Value = 0;
            numOvertimePay.Value = 0;
            numGrossSalary.Value = 0;
            numTax.Value = 0;
            numInsurance.Value = 0;
            numNetSalary.Value = 0;
            lblCalculatedSalary.Visible = false;
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            LoadPayrolls();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            LoadPayrolls();
        }
    }
}
