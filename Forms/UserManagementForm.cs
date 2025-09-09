using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EmployeeManagement.Database;

namespace EmployeeManagement.Forms
{
    /// <summary>
    /// Form quản lý tài khoản người dùng
    /// </summary>
    public partial class UserManagementForm : Form
    {
        private DataTable userDataTable;
        
        public UserManagementForm()
        {
            InitializeComponent();
            InitializeDataTable();
            LoadUsers();
        }
        
        private void InitializeDataTable()
        {
            userDataTable = new DataTable();
            userDataTable.Columns.Add("ID", typeof(int));
            userDataTable.Columns.Add("Username", typeof(string));
            userDataTable.Columns.Add("Full Name", typeof(string));
            userDataTable.Columns.Add("Role", typeof(string));
            userDataTable.Columns.Add("Created Date", typeof(DateTime));
            userDataTable.Columns.Add("Status", typeof(string));
            
            dgvUsers.DataSource = userDataTable;
        }
        
        private void LoadUsers()
        {
            try
            {
                userDataTable.Clear();
                
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "SELECT * FROM users ORDER BY created_date DESC";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var row = userDataTable.NewRow();
                            row["ID"] = reader.GetInt32("id");
                            row["Username"] = reader.GetString("username");
                            row["Full Name"] = reader.GetString("full_name");
                            row["Role"] = reader.GetString("role");
                            row["Created Date"] = reader.GetDateTime("created_date");
                            row["Status"] = reader.GetBoolean("is_active") ? "Active" : "Inactive";
                            
                            userDataTable.Rows.Add(row);
                        }
                    }
                }
                
                lblTotalUsers.Text = $"Total Users: {userDataTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter username and password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    connection.Open();
                    
                    var query = "INSERT INTO users (username, password, full_name, role, created_date, is_active) VALUES (@username, @password, @full_name, @role, NOW(), @active)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                        command.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                        command.Parameters.AddWithValue("@full_name", txtFullName.Text.Trim());
                        command.Parameters.AddWithValue("@role", cmbRole.Text);
                        command.Parameters.AddWithValue("@active", chkIsActive.Checked);
                        
                        command.ExecuteNonQuery();
                    }
                }
                
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
                    
                    using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
                    {
                        connection.Open();
                        
                        var query = "DELETE FROM users WHERE id = @id";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", userId);
                            command.ExecuteNonQuery();
                        }
                    }
                    
                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            cmbRole.SelectedIndex = 0;
            chkIsActive.Checked = true;
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadUsers();
        }
    }
}
