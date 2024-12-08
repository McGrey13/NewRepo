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
        //Represents the ADMIN form, which provides administrative functions such as managing employees,
        // departments, projects, tasks, and performing backup and restore operations.
        public partial class ADMIN : Form
        {
            public ADMIN()
            {
                // Initializes a new instance of the ADMIN form.
                InitializeComponent();
            }

            // Handles the click event for the "Employee" button. 
            // Opens the ALL_EMPLOYEE form to manage all employees.
            private void empbtn_Click(object sender, EventArgs e)
            {
                ALL_EMPLOYEE allEmployeesForm = new ALL_EMPLOYEE();
                allEmployeesForm.Show();
            }

            // Handles the click event for the "Department" button. 
            // Opens the DEPARTMENT form to manage departments.
            private void departmentbtn_Click(object sender, EventArgs e)
            {
                DEPARTMENT department = new DEPARTMENT();
                department.Show();
            }

            // Handles the click event for the "Project" button. 
            // Opens the PROJECTS form to manage projects.
            private void projectbtn_Click(object sender, EventArgs e)
            {
                PROJECTS PROJECTS = new PROJECTS();
                PROJECTS.Show();
            }

            // Handles the click event for the "Task" button. 
            // Opens the TASKS form to manage tasks.
            private void taskbtn_Click(object sender, EventArgs e)
            {
                TASKS TASKS = new TASKS();
                 TASKS.Show();
            }
            // Handles the click event for the "Log Out" button. 
            // Logs out the user and redirects back to the LOGIN form.
            private void logOut_Click(object sender, EventArgs e)
            {
                LOGIN loginForm = new LOGIN();
                loginForm.Show();

                this.Close();
            }
            // Handles the click event for the "Backup and Restore" button. 
            // Opens the BackupAndRestore form to manage backup and recovery operations.
            private void backupAndRestore_Click(object sender, EventArgs e)
            {
                BackupAndRestore backupandrestore = new BackupAndRestore();
                backupandrestore.Show();    
            }
    }
    }
