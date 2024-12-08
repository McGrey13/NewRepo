using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace COMPANY
{
    public partial class ALL_EMPLOYEE : Form
    {
        private string connectionString = "server=localhost;database=ManagementData;uid=root;pwd=;";
        private MySqlConnection connection;
        public ALL_EMPLOYEE()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void ALL_EMPLOYEE_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadDepartments(); 
            LoadProjects();  
            LoadTasks();
        }

        private void LoadEmployees()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();
                string query = @"
             SELECT 
                e.EmployeeID, 
                e.FirstName, 
                e.LastName, 
                d.DepartmentName, 
                t.TaskName, 
                p.ProjectName 
            FROM 
                Employee e
            LEFT JOIN 
                Department d ON e.DepartmentID = d.DepartmentID
            LEFT JOIN 
                Task t ON e.EmployeeID = t.AssignedTo
            LEFT JOIN 
                Project p ON t.ProjectID = p.ProjectID";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadDepartments()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();
                string query = "SELECT DepartmentID, DepartmentName FROM Department";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                deptBox.DataSource = dataTable;
                deptBox.DisplayMember = "DepartmentName";
                deptBox.ValueMember = "DepartmentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadProjects()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();
                string query = "SELECT ProjectID, ProjectName FROM Project";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                projectBox.DataSource = dataTable;
                projectBox.DisplayMember = "ProjectName"; 
                projectBox.ValueMember = "ProjectID"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private void LoadTasks()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close(); 

                connection.Open();
                string query = "SELECT TaskID, TaskName                                                                                                                                                                                                  FROM Task";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                taskBox.DataSource = dataTable;
                taskBox.DisplayMember = "TaskName"; 
                taskBox.ValueMember = "TaskID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void addEmp_Click(object sender, EventArgs e)
        {
            // Validate input fields before adding
            if (string.IsNullOrWhiteSpace(empIdtxt.Text) || string.IsNullOrWhiteSpace(fntxt.Text) ||
                string.IsNullOrWhiteSpace(lntxt.Text) || deptBox.SelectedValue == null ||
                projectBox.SelectedValue == null || taskBox.SelectedValue == null)
            {
                MessageBox.Show("All fields must be filled to add an employee, including Department, Project, and Task.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(empIdtxt.Text, out int employeeId))
            {
                MessageBox.Show("Employee ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int departmentId = Convert.ToInt32(deptBox.SelectedValue);
            int projectId = Convert.ToInt32(projectBox.SelectedValue);
            int taskId = Convert.ToInt32(taskBox.SelectedValue);

            try
            {
                connection.Open();
                string query = @"
            INSERT INTO Employee (EmployeeID, FirstName, LastName, DepartmentID) 
            VALUES (@EmployeeID, @FirstName, @LastName, @DepartmentID);
            
            UPDATE Task 
            SET AssignedTo = @EmployeeID 
            WHERE TaskID = @TaskID";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@EmployeeID", employeeId);
                command.Parameters.AddWithValue("@FirstName", fntxt.Text);
                command.Parameters.AddWithValue("@LastName", lntxt.Text);
                command.Parameters.AddWithValue("@DepartmentID", departmentId);
                command.Parameters.AddWithValue("@TaskID", taskId);

                command.ExecuteNonQuery();
                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadEmployees(); // Refresh the DataGridView
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void empIdtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void fntxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void lntxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void deptBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void projectBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void taskBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            int employeeID = Convert.ToInt32(selectedRow.Cells["EmployeeID"].Value);
            string employeeName = $"{selectedRow.Cells["FirstName"].Value} {selectedRow.Cells["LastName"].Value}";

            // Confirmation before deletion
            var confirmResult = MessageBox.Show($"Are you sure you want to delete employee {employeeName} (ID: {employeeID})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    // First, delete associated tasks
                    string deleteTasksQuery = "DELETE FROM Task WHERE AssignedTo = @EmployeeID";
                    MySqlCommand deleteTasksCommand = new MySqlCommand(deleteTasksQuery, connection);
                    deleteTasksCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                    deleteTasksCommand.ExecuteNonQuery();

                    // Then, delete the employee
                    string deleteEmployeeQuery = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                    MySqlCommand deleteEmployeeCommand = new MySqlCommand(deleteEmployeeQuery, connection);
                    deleteEmployeeCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                    deleteEmployeeCommand.ExecuteNonQuery();

                    MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployees(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void updateEmp_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=localhost;port=3306;database=ManagementData;uid=root;pwd=;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if an employee is selected
                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Please select an employee from the table to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Get the selected EmployeeID
                    int employeeId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);

                    // Ensure all fields are filled
                    if (string.IsNullOrWhiteSpace(fntxt.Text) || string.IsNullOrWhiteSpace(lntxt.Text) || deptBox.SelectedValue == null)
                    {
                        MessageBox.Show("First Name, Last Name, and Department must be filled.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Convert SelectedValue to int safely
                    if (!int.TryParse(deptBox.SelectedValue.ToString(), out int departmentId))
                    {
                        MessageBox.Show("Invalid Department ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Begin a transaction for atomicity
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Update Employee details
                            string updateEmployeeQuery = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, DepartmentID = @DepartmentID WHERE EmployeeID = @EmployeeID";
                            using (MySqlCommand updateEmployeeCmd = new MySqlCommand(updateEmployeeQuery, connection, transaction))
                            {
                                updateEmployeeCmd.Parameters.AddWithValue("@FirstName", fntxt.Text.Trim());
                                updateEmployeeCmd.Parameters.AddWithValue("@LastName", lntxt.Text.Trim());
                                updateEmployeeCmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                                updateEmployeeCmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                                int rowsAffected = updateEmployeeCmd.ExecuteNonQuery();
                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show("No employee was updated. Check if the EmployeeID exists.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show($"{rowsAffected} employee(s) updated successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            // Commit the transaction
                            transaction.Commit();
                            LoadEmployees();
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of an error
                            transaction.Rollback();
                            MessageBox.Show($"An error occurred while updating: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchEmp_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            // Check if the searchEmp textbox contains a valid integer
            if (string.IsNullOrWhiteSpace(searchEmp.Text) || !int.TryParse(searchEmp.Text, out int employeeId))
            {
                MessageBox.Show("Please enter a valid Employee ID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();
                string query = @"
            SELECT 
                e.EmployeeID, 
                e.FirstName, 
                e.LastName, 
                d.DepartmentName, 
                p.ProjectName, 
                t.TaskName 
            FROM 
                Employee e
            LEFT JOIN 
                Department d ON e.DepartmentID = d.DepartmentID
            LEFT JOIN 
                Task t ON e.EmployeeID = t.AssignedTo
            LEFT JOIN 
                Project p ON t.ProjectID = p.ProjectID
            WHERE 
                e.EmployeeID = @EmployeeID";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void ClearInputFields()
        {
            empIdtxt.Clear();
            fntxt.Clear();
            lntxt.Clear();
            deptBox.SelectedIndex = -1; // Deselect the department
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(empIdtxt.Text) || string.IsNullOrWhiteSpace(fntxt.Text) ||
                string.IsNullOrWhiteSpace(lntxt.Text) || string.IsNullOrWhiteSpace(deptBox.Text))
            {
                MessageBox.Show("All fields must be filled to proceed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(empIdtxt.Text, out _) || !int.TryParse(deptBox.Text, out _))
            {
                MessageBox.Show("Employee ID and Department ID must be valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;                                                                                                                            
        }

        private void FormatDataGridView()
        {
            try
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // ... (other DataGridView settings) ...

                if (dataGridView1.Columns.Contains("ProjectName"))
                {
                    dataGridView1.Columns["ProjectName"].HeaderText = "Project Name";
                }

                if (dataGridView1.Columns.Contains("TaskName"))
                {
                    dataGridView1.Columns["TaskName"].HeaderText = "Task Name";
                }

                // Check for and set headers for other columns if needed
                if (dataGridView1.Columns.Contains("DepartmentName"))
                {
                    dataGridView1.Columns["DepartmentName"].HeaderText = "Department";
                }

                if (dataGridView1.Columns.Contains("EmployeeID"))
                {
                    dataGridView1.Columns["EmployeeID"].HeaderText = "Employee ID";
                }

                if (dataGridView1.Columns.Contains("FirstName"))
                {
                    dataGridView1.Columns["FirstName"].HeaderText = "First Name";
                }

                if (dataGridView1.Columns.Contains("LastName"))
                {
                    dataGridView1.Columns["LastName"].HeaderText = "Last Name";
                }

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Error accessing DataGridView column: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log the error for further investigation (optional)
                // Example: 
                // Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FormatDataGridView();
            LoadEmployees();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            FormatDataGridView();
            LoadEmployees();

            // Ensure the clicked cell is not a header
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                var selectedRow = dataGridView1.Rows[e.RowIndex];

                // Select the row and highlight it
                selectedRow.Selected = true;

                // Store the EmployeeID for further actions
                int employeeID = Convert.ToInt32(selectedRow.Cells["EmployeeID"].Value);
                string firstName = selectedRow.Cells["FirstName"].Value.ToString();
                string lastName = selectedRow.Cells["LastName"].Value.ToString();

                // You can store these in class-level variables if needed
                // selectedEmployeeID = employeeID;

                // Display the selected Employee ID and Name for debugging
                MessageBox.Show($"Selected Employee ID: {employeeID}, Name: {firstName} {lastName}", "Selected Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
    }
}
