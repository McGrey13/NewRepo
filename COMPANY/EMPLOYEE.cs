using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPANY
{
    //Represents the EMPLOYEE form, where logged-in employees can view their information,
    /// including department and project details, loaded from the ManagementData database.
    public partial class EMPLOYEE : Form
    {
        private string connectionString = "server=localhost;database=ManagementData;uid=root;pwd=;";
        private int LoggedInEmployeeID;

        //Initializes a new instance of the EMPLOYEE form and sets the logged-in employee's ID.
        public EMPLOYEE(int employeeID)//The ID of the employee who logged in.
        {
            InitializeComponent();
            LoggedInEmployeeID = employeeID; // Populate the form with employee data on load
        }

        // Loads the logged-in employee's information from the database, including their name,
        // department, tasks, and projects, and displays the data in a DataGridView.
        private void EMPLOYEE_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        private void LoadEmployeeData()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to fetch employee's data with related department and project details
                    string query = @"
                SELECT 
                    CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, 
                    d.DepartmentName, 
                    t.TaskName, 
                    t.DueDate AS TaskDueDate, 
                    p.ProjectName, 
                    p.StartDate AS ProjectStartDate, 
                    p.EndDate AS ProjectEndDate
                FROM 
                    Employee e
                LEFT JOIN 
                    Department d ON e.DepartmentID = d.DepartmentID
                LEFT JOIN 
                    Task t ON t.AssignedTo = e.EmployeeID
                LEFT JOIN 
                    Project p ON t.ProjectID = p.ProjectID
                WHERE 
                    e.EmployeeID = @EmployeeID"; // Filter by logged-in employee ID

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Add employee ID as a parameter to the query
                        command.Parameters.AddWithValue("@EmployeeID", LoggedInEmployeeID); // Add the employee ID parameter

                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table); // Fill the DataTable with query results

                            if (table.Rows.Count == 0)
                            {
                                // Inform the user if no data is found for the employee
                                MessageBox.Show("No data found for this employee.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                dataGridView1.DataSource = table;

                                // Update column headers for better readability
                                dataGridView1.Columns["EmployeeName"].HeaderText = "Employee Name";
                                dataGridView1.Columns["DepartmentName"].HeaderText = "Department";
                                dataGridView1.Columns["TaskName"].HeaderText = "Task";
                                dataGridView1.Columns["TaskDueDate"].HeaderText = "Task Due Date";
                                dataGridView1.Columns["ProjectName"].HeaderText = "Project";
                                dataGridView1.Columns["ProjectStartDate"].HeaderText = "Project Start Date";
                                dataGridView1.Columns["ProjectEndDate"].HeaderText = "Project End Date";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message in case of a database error
                MessageBox.Show($"Error loading employee data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Handles the CellContentClick event for the DataGridView.
        // Can be used for handling clicks on individual cells.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Event handler for DataGridView cell clicks, can be customized as needed
        }

        // Handles the click event of the Log Out button. 
        // Redirects the user back to the LOGIN form and closes the EMPLOYEE form.
        private void logOut_Click(object sender, EventArgs e)
        {
            LOGIN loginForm = new LOGIN();
            loginForm.Show();

            this.Close();
        }
    }
}
