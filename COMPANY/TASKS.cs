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
        public partial class TASKS : Form
        {
            
            private string connectionString = "server=localhost;database=ManagementData;uid=root;pwd=;";
            private MySqlConnection connection;
            public TASKS()
            {
                InitializeComponent();
                connection = new MySqlConnection(connectionString);
            }

            private void TASKS_Load(object sender, EventArgs e)
            {
                LoadTasks();
                LoadProjects();
            }

            private void LoadTasks()
            {
                try
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    connection.Open();
                    string query = "SELECT TaskID, TaskName, DueDate, ProjectID FROM Task"; 
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; 
                    FormatDataGridView();
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

                private void LoadProjects()
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT ProjectID, ProjectName FROM Project";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        projectBox.DataSource = dataTable;
                        projectBox.DisplayMember = "ProjectName";
                        projectBox.ValueMember = "ProjectID";
                        projectBox.SelectedIndexChanged += projectBox_SelectedIndexChanged; // Attach event handler
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                LoadTasks();
                FormatDataGridView();
            }

            private void tastName_TextChanged(object sender, EventArgs e)
            {

            }

            private void taskDueDate_ValueChanged(object sender, EventArgs e)
            {

            }

        private void addTask_Click(object sender, EventArgs e)
         {
            if (string.IsNullOrWhiteSpace(tastName.Text) || taskDueDate.Value < DateTime.Now || projectBox.SelectedItem == null)
            {
                MessageBox.Show("Task name cannot be empty, due date must be in the future, and a project must be selected.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection.Open();
                string query = "INSERT INTO Task (TaskName, DueDate, ProjectID) VALUES (@TaskName, @DueDate, @ProjectID)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaskName", tastName.Text);
                command.Parameters.AddWithValue("@DueDate", taskDueDate.Value);

                DataRowView selectedRow = (DataRowView)projectBox.SelectedItem;
                int projectId = Convert.ToInt32(selectedRow["ProjectID"]);
                command.Parameters.AddWithValue("@ProjectID", projectId);

                command.ExecuteNonQuery();
                MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTasks(); // Refresh the data grid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

            private void updateTask_Click(object sender, EventArgs e)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a task to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int taskId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TaskID"].Value);
                if (string.IsNullOrWhiteSpace(tastName.Text) || taskDueDate.Value < DateTime.Now)
                {
                    MessageBox.Show("Task name cannot be empty and due date must be in the future.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    connection.Open();
                    string query = "UPDATE Task SET TaskName = @TaskName, DueDate = @DueDate WHERE TaskID = @TaskID";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TaskName", tastName.Text);
                    command.Parameters.AddWithValue("@DueDate", taskDueDate.Value);
                    command.Parameters.AddWithValue("@TaskID", taskId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTasks(); // Refresh the data grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }

            private void deleteTask_Click(object sender, EventArgs e)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a task to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int taskId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["TaskID"].Value);
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Task WHERE TaskID = @TaskID";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TaskID", taskId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Task deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTasks(); // Refresh the data grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            private void project_Click(object sender, EventArgs e)
            {

            }

        private void projectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        }
    }
