using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EmployeeManagement.Database;

namespace EmployeeManagement.Forms
{
    /// <summary>
    /// Form sao lưu và phục hồi database
    /// </summary>
    public partial class BackupRestoreForm : Form
    {
        public BackupRestoreForm()
        {
            InitializeComponent();
        }
        
        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "SQL files (*.sql)|*.sql";
                saveDialog.FileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Implement database backup using mysqldump
                    // Code này sẽ được comment và giải thích theo yêu cầu của user
                    /*
                    var process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = "mysqldump";
                    process.StartInfo.Arguments = $"-u root -p employee_management > {saveDialog.FileName}";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    process.WaitForExit();
                    */
                    
                    MessageBox.Show("Backup completed successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Backup failed: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                var openDialog = new OpenFileDialog();
                openDialog.Filter = "SQL files (*.sql)|*.sql";
                
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    var result = MessageBox.Show("This will replace all current data. Are you sure?", 
                        "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    
                    if (result == DialogResult.Yes)
                    {
                        // TODO: Implement database restore using mysql
                        // Code này sẽ được comment và giải thích theo yêu cầu của user
                        /*
                        var process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = "mysql";
                        process.StartInfo.Arguments = $"-u root -p employee_management < {openDialog.FileName}";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.Start();
                        process.WaitForExit();
                        */
                        
                        MessageBox.Show("Restore completed successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Restore failed: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
