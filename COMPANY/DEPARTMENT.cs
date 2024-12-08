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
using MySqlConnector;

namespace COMPANY
{
    // Represents the DEPARTMENT form, allowing users to manage departments by adding, updating, 
    // and deleting department information stored in the database.
    public partial class DEPARTMENT : Form
    {
        // Connection string to connect to the MySQL database
        private string connectionString = "server=localhost;database=ManagementData;uid=root;pwd=;";
        private MySqlConnection connection;

        //Initializes a new instance of the DEPARTMENT form.
        public DEPARTMENT()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);// Initialize database connection
        }

        // Event triggered when the DEPARTMENT form loads. 
 
        private void DEPARTMENT_Load(object sender, EventArgs e)
        {
            LoadDepartments();// Load department data
        }

        // Loads all departments from the database into the DataGridView.
        private void LoadDepartments()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();

            try
            {
                connection.Open();  
                string query = "SELECT DepartmentID, DepartmentName FROM Department"; // Query to retrieve departments
                using (var adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Fill the DataTable with query results
                    dataGridView1.DataSource = dataTable; // Bind the DataTable to the DataGridView
                }

                FormatDataGridView(); // for Formatting DataGridView
            }
            catch (Exception ex)
            {
                // Display an error message if fails
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close(); //Ensure the connection is closed after the operation
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        //Adds a new department to the database.
        private void addDepartment_Click(object sender, EventArgs e)
        {
            // Show a warning if the department name is empty
            if (string.IsNullOrWhiteSpace(departmentName.Text))
            {
                MessageBox.Show("Department name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close(); // Close Database Connection

                connection.Open(); // Open Database Connection
                string query = "INSERT INTO Department (DepartmentName) VALUES (@DepartmentName)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DepartmentName", departmentName.Text);
                    command.ExecuteNonQuery(); 
                }
                // Notify user of successful operation and reload departments
                MessageBox.Show("Department added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDepartments();
            }
            catch (Exception ex)
            {
                // Display an error message if adding the department fails
                MessageBox.Show($"Error adding department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        // Updates the selected department in the database.
        private void updateDepartment_Click(object sender, EventArgs e)
        {   //Warning if the Department is Empty
            if (dataGridView1.SelectedRows.Count == 0)
            {
                // Show a warning if no department is selected
                MessageBox.Show("Please select a department to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int departmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DepartmentID"].Value);
            if (string.IsNullOrWhiteSpace(departmentName.Text))
            {
                // Show a warning if the department name is empty
                MessageBox.Show("Department name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

                connection.Open(); // Open database connection
                string query = "UPDATE Department SET DepartmentName = @DepartmentName WHERE DepartmentID = @DepartmentID";
                using (var command = new MySqlCommand(query, connection))
                {
                    // Add parameters for department name and ID
                    command.Parameters.AddWithValue("@DepartmentName", departmentName.Text);
                    command.Parameters.AddWithValue("@DepartmentID", departmentId);
                    command.ExecuteNonQuery(); // Execute the update query
                }
                // Notify user of successful operation and reload departments
                MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDepartments(); 
            }
            catch (Exception ex)
            {   // Display an error message if adding the department fails
                MessageBox.Show($"Error updating department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close(); 
            }
        }

        //Deletes the Selected Department
        private void deleteDepartment_Click(object sender, EventArgs e)
        {
            //Warning if the Department is Empty
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a department to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int departmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DepartmentID"].Value);
            try
            {
                
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close(); // Close Database Connection

                connection.Open(); // Open Database Connection
                string query = "DELETE FROM Department WHERE DepartmentID = @DepartmentID";
                using (var command = new MySqlCommand(query, connection))
                {   
                    command.Parameters.AddWithValue("@DepartmentID", departmentId);
                    command.ExecuteNonQuery(); 
                }
                // Notify user of successful operation and reload departments
                MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDepartments(); 
            }
            catch (Exception ex)
            {   // Display an error message if adding the department fails
                MessageBox.Show($"Error deleting department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close(); 
            }
        }
        private void FormatDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        private void departmentName_TextChanged_1(object sender, EventArgs e)
        {
            LoadDepartments();
            FormatDataGridView();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
