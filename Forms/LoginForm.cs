using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EmployeeManagement.Database;
using EmployeeManagement.Models;

namespace EmployeeManagement.Forms
{
    /// <summary>
    /// Form đăng nhập hệ thống
    /// </summary>
    public partial class LoginForm : Form
    {
        public static User? CurrentUser { get; private set; }
        
        public static void Logout()
        {
            CurrentUser = null;
        }
        
        public LoginForm()
        {
            InitializeComponent();
            InitializeDatabase();
        }
        
        /// <summary>
        /// Khởi tạo database khi form load
        /// </summary>
        private void InitializeDatabase()
        {
            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo database: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện đăng nhập
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                var user = AuthenticateUser(username, password);
                if (user != null)
                {
                    CurrentUser = user;
                    this.Hide();
                    
                    // Mở form chính dựa trên quyền của user
                    var mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Xác thực thông tin đăng nhập
        /// </summary>
        private User? AuthenticateUser(string username, string password)
        {
            using (var connection = new MySqlConnection(DatabaseHelper.GetConnectionString()))
            {
                connection.Open();
                
                var query = @"
                    SELECT id, username, password, full_name, role, created_date, is_active 
                    FROM users 
                    WHERE username = @username AND password = @password AND is_active = TRUE";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32("id"),
                                Username = reader.GetString("username"),
                                Password = reader.GetString("password"),
                                FullName = reader.GetString("full_name"),
                                Role = reader.GetString("role"),
                                CreatedDate = reader.GetDateTime("created_date"),
                                IsActive = reader.GetBoolean("is_active")
                            };
                        }
                    }
                }
            }
            
            return null;
        }
        
        /// <summary>
        /// Xử lý sự kiện thoát
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        /// <summary>
        /// Xử lý phím Enter trong textbox
        /// </summary>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
        
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}
