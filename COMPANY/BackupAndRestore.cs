using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPANY
{
    public partial class BackupAndRestore : Form
    {
        public BackupAndRestore()
        {
            InitializeComponent();
        }

        private void BackupAndRestore_Load(object sender, EventArgs e)
        {

        }

        //Triggered when the "Restore" button is clicked.
        //Prompts the user to select a database backup file and restores the database from it.
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {   // Configure file dialog to filter for SQL files
                ofd.Filter = "SQL Files (.sql)|*.sql"; // Ensure the filter is correct
                ofd.Title = "Select Database Backup"; // Call restore method

            if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = ofd.FileName; // Get selected file path
                    RestoreDatabase(backupFilePath); // Call restore method
                }
            }
        }

        // Triggered when the "Backup" button is clicked.
        private void backUp_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "SQL Files (.sql)|*.sql"; // Ensure the filter is correct
                sfd.Title = "Save Database Backup";
                sfd.FileName = "ManagementData_backup.sql"; // Default file name

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string backupFilePath = sfd.FileName;// Get file path
                    BackupDatabase(backupFilePath); // Call backup method
                }
            }
        }
        // Creates a backup of the ManagementData database and saves it to the specified file path.
        private void BackupDatabase(string backupFilePath)
        {
            try
            {
                string mysqldumpPath = @"C:\xampp\mysql\bin\mysqldump.exe"; // Path to mysqldump

                // Check if the mysqldump executable exists
                if (!System.IO.File.Exists(mysqldumpPath))
                {
                    MessageBox.Show("MySQL dump executable not found at the specified path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Build the command with arguments (removed --skip-column-statistics)
                string arguments = $@"--user=root --password= --host=localhost ManagementData --result-file=""{backupFilePath}"" --no-tablespaces";


                // Configure process to execute mysqldump
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = mysqldumpPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process())
                {   
                    process.StartInfo = psi;
                    process.Start();

                    // Read output and error
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();
                    // Show appropriate message based on success or error
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Error during backup: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Backup completed successfully!\nOutput: " + output, "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {   // Handle exceptions during backup
                MessageBox.Show($"Error during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Restores the ManagementData database from the specified backup file.
        private void RestoreDatabase(string backupFilePath)
        {
            try
            {
                string mysqlPath = @"C:\xampp\mysql\bin\mysql.exe"; // Updated path to mysql

                // Verify if mysql exists
                if (!System.IO.File.Exists(mysqlPath))
                {
                    MessageBox.Show("MySQL executable not found at the specified path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Adjust the command for restoration
                string command = $@"--user=root --password= --host=localhost ManagementData < ""{backupFilePath}""";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = mysqlPath,
                    Arguments = command,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                // Configure process to execute mysql
                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                    // Write command to the input stream if required
                    using (var writer = process.StandardInput)
                    {
                        if (writer.BaseStream.CanWrite)
                        {
                            writer.WriteLine(command);
                        }
                    }
                    // Capture output and error streams
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();
                    // Show appropriate message based on success or error
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Error during restore: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Database restored successfully!", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            catch (Exception ex)
            {    // Handle exceptions during restore
                MessageBox.Show($"Error during restore: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
    

