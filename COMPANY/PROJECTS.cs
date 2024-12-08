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
    public partial class PROJECTS : Form
    {
        private string connectionString = "server=localhost;database=ManagementData;uid=root;pwd=;";
        private MySqlConnection connection;
        public PROJECTS()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void LoadProjects()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT ProjectID, ProjectName, StartDate, EndDate FROM Project"; // Adjust the table name and columns as per your DB schema
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // Bind data to DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void PROJECTS_Load(object sender, EventArgs e)
        {
                LoadProjects();
        }
    
            private void addProject_Click(object sender, EventArgs e)
        {
            string projectNameValue = projectName.Text;
            DateTime startDateValue = startDate.Value;
            DateTime endDateValue = endDate.Value;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(projectNameValue))
            {
                MessageBox.Show("Project name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "INSERT INTO Project (ProjectName, StartDate, EndDate) VALUES (@ProjectName, @StartDate, @EndDate)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProjectName", projectNameValue);
                    command.Parameters.AddWithValue("@StartDate", startDateValue);
                    command.Parameters.AddWithValue("@EndDate", endDateValue);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Project added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProjects(); // Refresh the data grid
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"MySQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        

        private void updateProject_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a project to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int projectId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProjectID"].Value);
            if (string.IsNullOrWhiteSpace(projectName.Text) || startDate.Value > endDate.Value)
            {
                MessageBox.Show("Project name cannot be empty and end date must be after start date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "UPDATE Project SET ProjectName = @ProjectName, StartDate = @StartDate, EndDate = @EndDate WHERE ProjectID = @ProjectID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProjectName", projectName.Text);
                command.Parameters.AddWithValue("@StartDate", startDate.Value);
                command.Parameters.AddWithValue("@EndDate", endDate.Value);
                command.Parameters.AddWithValue("@ProjectID", projectId);
                command.ExecuteNonQuery();
                MessageBox.Show("Project updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProjects(); // Refresh the data grid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void deleteProject_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a project to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int projectId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProjectID"].Value);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "DELETE FROM Project WHERE ProjectID = @ProjectID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProjectID", projectId);
                command.ExecuteNonQuery();
                MessageBox.Show("Project deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProjects(); // Refresh the data grid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void projectName_TextChanged(object sender, EventArgs e)
        {

        }
        private void FormatDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }
    }
}
