using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EmployeeManagement.Database;
using EmployeeManagement.Models;

namespace EmployeeManagement.Forms
{
    /// <summary>
    /// Form thêm/sửa thông tin nhân viên
    /// </summary>
    public partial class EmployeeForm : Form
    {
        private int? employeeId;
        private bool isEditMode;
        private List<Department> departments;
        private List<Position> positions;
        
        public EmployeeForm(int? id = null)
        {
            InitializeComponent();
            employeeId = id;
            isEditMode = id.HasValue;
            
            if (isEditMode)
            {
                this.Text = "Sửa thông tin nhân viên";
                btnSave.Text = "Cập nhật";
            }
            else
            {
                this.Text = "Thêm nhân viên mới";
                btnSave.Text = "Lưu";
            }
            
            LoadDepartments();
            LoadPositions();
            
            if (isEditMode)
            {
                LoadEmployeeData();
            }
        }
        
        /// <summary>
        /// Tải danh sách phòng ban
        /// </summary>
        private void LoadDepartments()
        {
            try
            {
                departments = new List<Department>();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "SELECT id, name FROM departments WHERE is_active = TRUE ORDER BY name";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name")
                            });
                        }
                    }
                }
                
                cmbDepartment.DataSource = departments;
                cmbDepartment.DisplayMember = "Name";
                cmbDepartment.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách phòng ban: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Tải danh sách chức vụ
        /// </summary>
        private void LoadPositions()
        {
            try
            {
                positions = new List<Position>();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "SELECT id, name FROM positions WHERE is_active = TRUE ORDER BY name";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            positions.Add(new Position
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name")
                            });
                        }
                    }
                }
                
                cmbPosition.DataSource = positions;
                cmbPosition.DisplayMember = "Name";
                cmbPosition.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách chức vụ: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Tải dữ liệu nhân viên để sửa
        /// </summary>
        private void LoadEmployeeData()
        {
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT e.*, d.name as department_name, p.name as position_name
                        FROM employees e
                        LEFT JOIN departments d ON e.department_id = d.id
                        LEFT JOIN positions p ON e.position_id = p.id
                        WHERE e.id = @id";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", employeeId);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtEmployeeCode.Text = reader.GetString("employee_code");
                                txtFullName.Text = reader.GetString("full_name");
                                dtpDateOfBirth.Value = reader.GetDateTime("date_of_birth");
                                cmbGender.Text = reader.GetString("gender");
                                // Load nullable string fields with safe casting using column index
                                try
                                {
                                    txtAddress.Text = reader.IsDBNull(4) ? "" : reader.GetString(4); // address column
                                }
                                catch { txtAddress.Text = ""; }
                                
                                try
                                {
                                    txtPhoneNumber.Text = reader.IsDBNull(5) ? "" : reader.GetString(5); // phone_number column
                                }
                                catch { txtPhoneNumber.Text = ""; }
                                
                                try
                                {
                                    txtEmail.Text = reader.IsDBNull(6) ? "" : reader.GetString(6); // email column
                                }
                                catch { txtEmail.Text = ""; }
                                
                                // Load department and position with safe casting using column index
                                try
                                {
                                    if (!reader.IsDBNull(7)) // department_id column
                                    {
                                        var deptId = reader.GetInt32(7);
                                        cmbDepartment.SelectedValue = deptId;
                                    }
                                }
                                catch { /* Ignore department loading error */ }
                                
                                try
                                {
                                    if (!reader.IsDBNull(8)) // position_id column
                                    {
                                        var posId = reader.GetInt32(8);
                                        cmbPosition.SelectedValue = posId;
                                    }
                                }
                                catch { /* Ignore position loading error */ }
                                dtpStartDate.Value = reader.GetDateTime("start_date");
                                numBasicSalary.Value = reader.GetDecimal("basic_salary");
                                numSalaryCoefficient.Value = reader.GetDecimal("salary_coefficient");
                                numAllowance.Value = reader.GetDecimal("allowance");
                                chkIsActive.Checked = reader.GetBoolean("is_active");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu nhân viên: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện lưu thông tin nhân viên
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;
            
            try
            {
                if (isEditMode)
                {
                    UpdateEmployee();
                }
                else
                {
                    AddEmployee();
                }
                
                MessageBox.Show(isEditMode ? "Cập nhật thông tin nhân viên thành công!" : "Thêm nhân viên mới thành công!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu thông tin nhân viên: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Thêm nhân viên mới
        /// </summary>
        private void AddEmployee()
        {
            using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
            {
                connection.Open();
                
                var query = @"
                    INSERT INTO employees (employee_code, full_name, date_of_birth, gender, address, 
                                         phone_number, email, department_id, position_id, start_date, 
                                         basic_salary, salary_coefficient, allowance, is_active, created_date)
                    VALUES (@code, @name, @dob, @gender, @address, @phone, @email, @dept_id, 
                           @pos_id, @start_date, @basic_salary, @coefficient, @allowance, @active, NOW())";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@code", txtEmployeeCode.Text.Trim());
                    command.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                    command.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value.Date);
                    command.Parameters.AddWithValue("@gender", cmbGender.Text);
                    command.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    command.Parameters.AddWithValue("@phone", txtPhoneNumber.Text.Trim());
                    command.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    command.Parameters.AddWithValue("@dept_id", cmbDepartment.SelectedValue);
                    command.Parameters.AddWithValue("@pos_id", cmbPosition.SelectedValue);
                    command.Parameters.AddWithValue("@start_date", dtpStartDate.Value.Date);
                    command.Parameters.AddWithValue("@basic_salary", numBasicSalary.Value);
                    command.Parameters.AddWithValue("@coefficient", numSalaryCoefficient.Value);
                    command.Parameters.AddWithValue("@allowance", numAllowance.Value);
                    command.Parameters.AddWithValue("@active", chkIsActive.Checked);
                    
                    command.ExecuteNonQuery();
                }
            }
        }
        
        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        private void UpdateEmployee()
        {
            using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
            {
                connection.Open();
                
                var query = @"
                    UPDATE employees 
                    SET employee_code = @code, full_name = @name, date_of_birth = @dob, 
                        gender = @gender, address = @address, phone_number = @phone, 
                        email = @email, department_id = @dept_id, position_id = @pos_id, 
                        start_date = @start_date, basic_salary = @basic_salary, 
                        salary_coefficient = @coefficient, allowance = @allowance, 
                        is_active = @active
                    WHERE id = @id";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", employeeId);
                    command.Parameters.AddWithValue("@code", txtEmployeeCode.Text.Trim());
                    command.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                    command.Parameters.AddWithValue("@dob", dtpDateOfBirth.Value.Date);
                    command.Parameters.AddWithValue("@gender", cmbGender.Text);
                    command.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    command.Parameters.AddWithValue("@phone", txtPhoneNumber.Text.Trim());
                    command.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    command.Parameters.AddWithValue("@dept_id", cmbDepartment.SelectedValue);
                    command.Parameters.AddWithValue("@pos_id", cmbPosition.SelectedValue);
                    command.Parameters.AddWithValue("@start_date", dtpStartDate.Value.Date);
                    command.Parameters.AddWithValue("@basic_salary", numBasicSalary.Value);
                    command.Parameters.AddWithValue("@coefficient", numSalaryCoefficient.Value);
                    command.Parameters.AddWithValue("@allowance", numAllowance.Value);
                    command.Parameters.AddWithValue("@active", chkIsActive.Checked);
                    
                    command.ExecuteNonQuery();
                }
            }
        }
        
        /// <summary>
        /// Kiểm tra dữ liệu đầu vào
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }
            
            if (cmbDepartment.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phòng ban!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return false;
            }
            
            if (cmbPosition.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPosition.Focus();
                return false;
            }
            
            // Kiểm tra email hợp lệ
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            
            return true;
        }
        
        /// <summary>
        /// Kiểm tra email hợp lệ
        /// </summary>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện hủy
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Tự động tạo mã nhân viên
        /// </summary>
        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "SELECT COUNT(*) FROM employees";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        txtEmployeeCode.Text = $"NV{(count + 1):D4}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tạo mã nhân viên: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
