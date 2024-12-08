using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace COMPANY
{
    public partial class LOGIN : Form
    {
        private string connectionString = "server=localhost;database=ManagementData;uid=root;pwd=;"; 
        public LOGIN()
        {
            //Initializes a new instance of the LOGIN form.
            InitializeComponent();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void usernametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordtxt_TextChanged(object sender, EventArgs e)
        {

        }

        // Handles the click event of the login button. Validates user credentials 
        // and opens the appropriate form based on user type (Employee or Admin).
        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = usernametxt.Text;
            string password = passwordtxt.Text;

            // Validate as Employee
            if (ValidateUser(username, password, out int employeeID, "Employee"))
            {
                // Open the EMPLOYEE form and pass the EmployeeID
                EMPLOYEE employeeForm = new EMPLOYEE(employeeID);
                employeeForm.Show();
                this.Hide(); // Hide the login form
            }
            // Validate as Admin
            else if (ValidateUser(username, password, out int adminID, "Users"))
            {
                // Open the ADMIN form
                ADMIN adminForm = new ADMIN();
                adminForm.Show();
                this.Hide(); // Hide the login form
            }
            // Invalid credentials
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUser(string username, string password, out int userID, string table)
        {
            userID = 0; // Default value if user is not found

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();// Open the database connection
                    // Prepare the SQL query based on the user type
                    string query = table == "Employee"
                        ? $"SELECT EmployeeID FROM {table} WHERE FirstName = @Username AND EmployeeID = @Password"
                        : $"SELECT userID FROM {table} WHERE username = @Username AND pass = @Password";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (var reader = command.ExecuteReader())
                        {
                            // Check if the user exists
                            if (reader.Read())
                            {
                                userID = table == "Employee"
                                    ? reader.GetInt32("EmployeeID")
                                    : reader.GetInt32("userID"); // Fetch the appropriate ID
                                return true; // User validated
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Show an error message if there is a database error
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false; // User not found
        }

        //Handles the CheckedChanged event of the show password checkbox. 
        //Toggles the visibility of the password text in the password field.
        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            passwordtxt.UseSystemPasswordChar = !showPass.Checked;
        }
    }
}
