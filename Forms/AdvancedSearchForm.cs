using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EmployeeManagement.Database;

namespace EmployeeManagement.Forms
{
    /// <summary>
    /// Form tìm kiếm nâng cao
    /// </summary>
    public partial class AdvancedSearchForm : Form
    {
        private DataTable searchResults;
        
        public AdvancedSearchForm()
        {
            InitializeComponent();
            InitializeDataTable();
            LoadDepartments();
            LoadPositions();
        }
        
        private void InitializeDataTable()
        {
            searchResults = new DataTable();
            searchResults.Columns.Add("Mã NV", typeof(string));
            searchResults.Columns.Add("Họ tên", typeof(string));
            searchResults.Columns.Add("Phòng ban", typeof(string));
            searchResults.Columns.Add("Chức vụ", typeof(string));
            searchResults.Columns.Add("Lương cơ bản", typeof(decimal));
            searchResults.Columns.Add("Ngày vào làm", typeof(DateTime));
            
            dgvResults.DataSource = searchResults;
        }
        
        private void LoadDepartments()
        {
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    var query = "SELECT id, name FROM departments WHERE is_active = TRUE ORDER BY name";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        cmbDepartment.Items.Add("Tất cả");
                        while (reader.Read())
                        {
                            cmbDepartment.Items.Add(reader.GetString("name"));
                        }
                    }
                }
                cmbDepartment.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải phòng ban: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadPositions()
        {
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    var query = "SELECT id, name FROM positions WHERE is_active = TRUE ORDER BY name";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        cmbPosition.Items.Add("Tất cả");
                        while (reader.Read())
                        {
                            cmbPosition.Items.Add(reader.GetString("name"));
                        }
                    }
                }
                cmbPosition.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chức vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchResults.Clear();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = @"
                        SELECT e.employee_code, e.full_name, d.name as dept_name, p.name as pos_name, 
                               e.basic_salary, e.start_date
                        FROM employees e
                        LEFT JOIN departments d ON e.department_id = d.id
                        LEFT JOIN positions p ON e.position_id = p.id
                        WHERE e.is_active = TRUE";
                    
                    if (!string.IsNullOrWhiteSpace(txtName.Text))
                    {
                        query += " AND e.full_name LIKE @name";
                    }
                    
                    if (cmbDepartment.SelectedIndex > 0)
                    {
                        query += " AND d.name = @department";
                    }
                    
                    if (cmbPosition.SelectedIndex > 0)
                    {
                        query += " AND p.name = @position";
                    }
                    
                    if (numMinSalary.Value > 0)
                    {
                        query += " AND e.basic_salary >= @min_salary";
                    }
                    
                    if (numMaxSalary.Value > 0)
                    {
                        query += " AND e.basic_salary <= @max_salary";
                    }
                    
                    query += " ORDER BY e.full_name";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(txtName.Text))
                            command.Parameters.AddWithValue("@name", $"%{txtName.Text}%");
                        if (cmbDepartment.SelectedIndex > 0)
                            command.Parameters.AddWithValue("@department", cmbDepartment.Text);
                        if (cmbPosition.SelectedIndex > 0)
                            command.Parameters.AddWithValue("@position", cmbPosition.Text);
                        if (numMinSalary.Value > 0)
                            command.Parameters.AddWithValue("@min_salary", numMinSalary.Value);
                        if (numMaxSalary.Value > 0)
                            command.Parameters.AddWithValue("@max_salary", numMaxSalary.Value);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = searchResults.NewRow();
                                row["Mã NV"] = reader.GetString("employee_code");
                                row["Họ tên"] = reader.GetString("full_name");
                                row["Phòng ban"] = reader.IsDBNull("dept_name") ? "" : reader.GetString("dept_name");
                                row["Chức vụ"] = reader.IsDBNull("pos_name") ? "" : reader.GetString("pos_name");
                                row["Lương cơ bản"] = reader.GetDecimal("basic_salary");
                                row["Ngày vào làm"] = reader.GetDateTime("start_date");
                                searchResults.Rows.Add(row);
                            }
                        }
                    }
                }
                
                lblResults.Text = $"Kết quả tìm kiếm: {searchResults.Rows.Count} nhân viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            cmbDepartment.SelectedIndex = 0;
            cmbPosition.SelectedIndex = 0;
            numMinSalary.Value = 0;
            numMaxSalary.Value = 0;
            searchResults.Clear();
            lblResults.Text = "Kết quả tìm kiếm: 0 nhân viên";
        }
    }
}
