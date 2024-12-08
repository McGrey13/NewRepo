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
                {
                    connection.Close();
                }

                connection.Open();
                string query = @"
        SELECT e.EmployeeID, e.FirstName, e.LastName, 
               d.DepartmentName, p.ProjectName, t.TaskName
        FROM Employee e
        LEFT JOIN Department d ON e.DepartmentID = d.DepartmentID
        LEFT JOIN Task t ON t.AssignedTo = e.EmployeeID
        LEFT JOIN Project p ON t.ProjectID = p.ProjectID
        ORDER BY e.EmployeeID;";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // Refresh DataGridView
                FormatDataGridView(); // Ensure headers are formatted
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
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
                string query = "SELECT TaskID, TaskName FROM Task";
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
            if (!ValidateInputs())
            {
                return;
            }

            string firstName = fntxt.Text;
            string lastName = lntxt.Text;
            string departmentName = deptBox.Text;

            try
            {
                connection.Open();

                // Insert into Department table if it doesn't exist
                string insertDepartmentQuery = @"
            INSERT IGNORE INTO Department (DepartmentName)
            VALUES (@DepartmentName)";

                using (MySqlCommand insertDepartmentCommand = new MySqlCommand(insertDepartmentQuery, connection))
                {
                    insertDepartmentCommand.Parameters.AddWithValue("@DepartmentName", departmentName);
                    insertDepartmentCommand.ExecuteNonQuery();
                }

                // Get DepartmentID
                int departmentID = GetDepartmentID(departmentName);

                // Insert into Employee table
                string insertEmployeeQuery = @"
            INSERT INTO Employee (FirstName, LastName, DepartmentID)
            VALUES (@FirstName, @LastName, @DepartmentID)";

                using (MySqlCommand insertEmployeeCommand = new MySqlCommand(insertEmployeeQuery, connection))
                {
                    insertEmployeeCommand.Parameters.AddWithValue("@FirstName", firstName);
                    insertEmployeeCommand.Parameters.AddWithValue("@LastName", lastName);
                    insertEmployeeCommand.Parameters.AddWithValue("@DepartmentID", departmentID);
                    insertEmployeeCommand.ExecuteNonQuery();
                }

                // Get the auto-generated EmployeeID
                int employeeID = GetLastInsertedEmployeeID();

                // Insert into Project table if it doesn't exist
                string projectName = projectBox.Text;
                string insertProjectQuery = @"
            INSERT IGNORE INTO Project (ProjectName, StartDate)
            VALUES (@ProjectName, CURRENT_DATE())";

                using (MySqlCommand insertProjectCommand = new MySqlCommand(insertProjectQuery, connection))
                {
                    insertProjectCommand.Parameters.AddWithValue("@ProjectName", projectName);
                    insertProjectCommand.ExecuteNonQuery();
                }

                // Get ProjectID
                int projectID = GetProjectID(projectName);

                // Insert into Task table if it doesn't exist
                string taskName = taskBox.Text;
                string insertTaskQuery = @"
            INSERT IGNORE INTO Task (TaskName, ProjectID)
            VALUES (@TaskName, @ProjectID)";

                using (MySqlCommand insertTaskCommand = new MySqlCommand(insertTaskQuery, connection))
                {
                    insertTaskCommand.Parameters.AddWithValue("@TaskName", taskName);
                    insertTaskCommand.Parameters.AddWithValue("@ProjectID", projectID);
                    insertTaskCommand.ExecuteNonQuery();
                }

                // Get TaskID
                int taskID = GetTaskID(taskName);

                // Update Task with AssignedTo
                string updateTaskQuery = @"
            UPDATE Task 
            SET AssignedTo = @EmployeeID
            WHERE TaskID = @TaskID";

                using (MySqlCommand updateTaskCommand = new MySqlCommand(updateTaskQuery, connection))
                {
                    updateTaskCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                    updateTaskCommand.Parameters.AddWithValue("@TaskID", taskID);
                    updateTaskCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Employee and Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees(); // Refresh the DataGridView
                ClearInputFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee and task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private int GetDepartmentID(string departmentName)
{
    string getDepartmentIDQuery = @"
        SELECT DepartmentID 
        FROM Department 
        WHERE DepartmentName = @DepartmentName";

    using (MySqlCommand command = new MySqlCommand(getDepartmentIDQuery, connection))
    {
        command.Parameters.AddWithValue("@DepartmentName", departmentName);
        object result = command.ExecuteScalar();
        return result == DBNull.Value ? -1 : Convert.ToInt32(result);
    }
}

private int GetProjectID(string projectName)
{
    string getProjectIDQuery = @"
        SELECT ProjectID 
        FROM Project 
        WHERE ProjectName = @ProjectName";

    using (MySqlCommand command = new MySqlCommand(getProjectIDQuery, connection))
    {
        command.Parameters.AddWithValue("@ProjectName", projectName);
        object result = command.ExecuteScalar();
        return result == DBNull.Value ? -1 : Convert.ToInt32(result);
    }
}

private int GetTaskID(string taskName)
{
    string getTaskIDQuery = @"
        SELECT TaskID 
        FROM Task 
        WHERE TaskName = @TaskName";

    using (MySqlCommand command = new MySqlCommand(getTaskIDQuery, connection))
    {
        command.Parameters.AddWithValue("@TaskName", taskName);
        object result = command.ExecuteScalar();
        return result == DBNull.Value ? -1 : Convert.ToInt32(result);
    }
}

private int GetLastInsertedEmployeeID()
{
    string getLastIDQuery = "SELECT LAST_INSERT_ID();";
    using (MySqlCommand command = new MySqlCommand(getLastIDQuery, connection))
    {
        return Convert.ToInt32(command.ExecuteScalar());
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
            // Check if an employee is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected employee ID from the DataGridView
            var selectedRow = dataGridView1.SelectedRows[0];
            int employeeId = Convert.ToInt32(selectedRow.Cells["EmployeeID"].Value);

            // Validate input fields
            if (string.IsNullOrWhiteSpace(fntxt.Text) ||
                string.IsNullOrWhiteSpace(lntxt.Text) ||
                deptBox.SelectedValue == null)
            {
                MessageBox.Show("All fields must be filled to update the employee.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int departmentId = Convert.ToInt32(deptBox.SelectedValue);

            try
            {
                connection.Open();

                // Update employee data
                string updateEmployeeQuery = @"
            UPDATE Employee 
            SET FirstName = @FirstName, LastName = @LastName, DepartmentID = @DepartmentID 
            WHERE EmployeeID = @EmployeeID";

                using (MySqlCommand updateCommand = new MySqlCommand(updateEmployeeQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                    updateCommand.Parameters.AddWithValue("@FirstName", fntxt.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@LastName", lntxt.Text.Trim());
                    updateCommand.Parameters.AddWithValue("@DepartmentID", departmentId);
                    updateCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEmployees(); // Refresh the DataGridView
                ClearInputFields(); // Clear input fields after updating
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
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
            if (string.IsNullOrWhiteSpace(fntxt.Text) ||
                string.IsNullOrWhiteSpace(lntxt.Text) ||
                deptBox.SelectedIndex == -1)
            {
                MessageBox.Show("All fields must be filled to proceed.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(empIdtxt.Text, out int employeeID))
            {
                MessageBox.Show("Employee ID must be a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (deptBox.SelectedValue == null)
            {
                MessageBox.Show("Please select a Department.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void FormatDataGridView()
        {
            try
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dataGridView1.Columns.Contains("ProjectName"))
                {
                    dataGridView1.Columns["ProjectName"].HeaderText = "Project Name";
                }

                if (dataGridView1.Columns.Contains("TaskName"))
                {
                    dataGridView1.Columns["TaskName"].HeaderText = "Task Name";
                }

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
          
        }
    
    }
}
