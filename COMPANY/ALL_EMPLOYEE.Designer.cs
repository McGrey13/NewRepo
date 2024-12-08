namespace COMPANY
{
    partial class ALL_EMPLOYEE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ALL_EMPLOYEE));
            this.delbtn = new System.Windows.Forms.Button();
            this.updateEmp = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchEmp = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Label();
            this.addEmp = new System.Windows.Forms.Button();
            this.taskBox = new System.Windows.Forms.ComboBox();
            this.projectBox = new System.Windows.Forms.ComboBox();
            this.deptBox = new System.Windows.Forms.ComboBox();
            this.task = new System.Windows.Forms.Label();
            this.project = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.Label();
            this.lntxt = new System.Windows.Forms.TextBox();
            this.fntxt = new System.Windows.Forms.TextBox();
            this.empIdtxt = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.Label();
            this.fname = new System.Windows.Forms.Label();
            this.empId = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // delbtn
            // 
            this.delbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.delbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delbtn.Location = new System.Drawing.Point(689, 171);
            this.delbtn.Margin = new System.Windows.Forms.Padding(2);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(150, 28);
            this.delbtn.TabIndex = 37;
            this.delbtn.Text = "DELETE EMPLOYEE";
            this.delbtn.UseVisualStyleBackColor = false;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // updateEmp
            // 
            this.updateEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.updateEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateEmp.Location = new System.Drawing.Point(473, 172);
            this.updateEmp.Margin = new System.Windows.Forms.Padding(2);
            this.updateEmp.Name = "updateEmp";
            this.updateEmp.Size = new System.Drawing.Size(153, 28);
            this.updateEmp.TabIndex = 36;
            this.updateEmp.Text = "UPDATE EMPLOYEE";
            this.updateEmp.UseVisualStyleBackColor = false;
            this.updateEmp.Click += new System.EventHandler(this.updateEmp_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(398, 237);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(82, 24);
            this.searchBtn.TabIndex = 35;
            this.searchBtn.Text = "SEARCH";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchEmp
            // 
            this.searchEmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchEmp.Location = new System.Drawing.Point(249, 237);
            this.searchEmp.Margin = new System.Windows.Forms.Padding(2);
            this.searchEmp.Name = "searchEmp";
            this.searchEmp.Size = new System.Drawing.Size(118, 24);
            this.searchEmp.TabIndex = 34;
            this.searchEmp.Text = "Employee Id";
            this.searchEmp.TextChanged += new System.EventHandler(this.searchEmp_TextChanged);
            // 
            // search
            // 
            this.search.AutoSize = true;
            this.search.BackColor = System.Drawing.Color.Transparent;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(67, 240);
            this.search.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(194, 20);
            this.search.TabIndex = 33;
            this.search.Text = "SEARCH EMPLOYEE :";
            // 
            // addEmp
            // 
            this.addEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.addEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addEmp.Location = new System.Drawing.Point(267, 171);
            this.addEmp.Margin = new System.Windows.Forms.Padding(2);
            this.addEmp.Name = "addEmp";
            this.addEmp.Size = new System.Drawing.Size(125, 28);
            this.addEmp.TabIndex = 32;
            this.addEmp.Text = "ADD EMPLOYEE";
            this.addEmp.UseVisualStyleBackColor = false;
            this.addEmp.Click += new System.EventHandler(this.addEmp_Click);
            // 
            // taskBox
            // 
            this.taskBox.FormattingEnabled = true;
            this.taskBox.Location = new System.Drawing.Point(667, 124);
            this.taskBox.Margin = new System.Windows.Forms.Padding(2);
            this.taskBox.Name = "taskBox";
            this.taskBox.Size = new System.Drawing.Size(148, 21);
            this.taskBox.TabIndex = 31;
            this.taskBox.SelectedIndexChanged += new System.EventHandler(this.taskBox_SelectedIndexChanged);
            // 
            // projectBox
            // 
            this.projectBox.FormattingEnabled = true;
            this.projectBox.Location = new System.Drawing.Point(678, 82);
            this.projectBox.Margin = new System.Windows.Forms.Padding(2);
            this.projectBox.Name = "projectBox";
            this.projectBox.Size = new System.Drawing.Size(148, 21);
            this.projectBox.TabIndex = 30;
            this.projectBox.SelectedIndexChanged += new System.EventHandler(this.projectBox_SelectedIndexChanged);
            // 
            // deptBox
            // 
            this.deptBox.FormattingEnabled = true;
            this.deptBox.Location = new System.Drawing.Point(702, 46);
            this.deptBox.Margin = new System.Windows.Forms.Padding(2);
            this.deptBox.Name = "deptBox";
            this.deptBox.Size = new System.Drawing.Size(148, 21);
            this.deptBox.TabIndex = 29;
            this.deptBox.SelectedIndexChanged += new System.EventHandler(this.deptBox_SelectedIndexChanged);
            // 
            // task
            // 
            this.task.AutoSize = true;
            this.task.BackColor = System.Drawing.Color.Transparent;
            this.task.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.task.Location = new System.Drawing.Point(579, 124);
            this.task.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.task.Name = "task";
            this.task.Size = new System.Drawing.Size(64, 20);
            this.task.TabIndex = 28;
            this.task.Text = "TASK: ";
            // 
            // project
            // 
            this.project.AutoSize = true;
            this.project.BackColor = System.Drawing.Color.Transparent;
            this.project.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.project.Location = new System.Drawing.Point(579, 84);
            this.project.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.project.Name = "project";
            this.project.Size = new System.Drawing.Size(99, 20);
            this.project.TabIndex = 27;
            this.project.Text = "PROJECT: ";
            // 
            // department
            // 
            this.department.AutoSize = true;
            this.department.BackColor = System.Drawing.Color.Transparent;
            this.department.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department.Location = new System.Drawing.Point(579, 47);
            this.department.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(128, 20);
            this.department.TabIndex = 26;
            this.department.Text = "DEPARMENT: ";
            // 
            // lntxt
            // 
            this.lntxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lntxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lntxt.Location = new System.Drawing.Point(339, 120);
            this.lntxt.Margin = new System.Windows.Forms.Padding(2);
            this.lntxt.Name = "lntxt";
            this.lntxt.Size = new System.Drawing.Size(181, 24);
            this.lntxt.TabIndex = 25;
            this.lntxt.TextChanged += new System.EventHandler(this.lntxt_TextChanged);
            // 
            // fntxt
            // 
            this.fntxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fntxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fntxt.Location = new System.Drawing.Point(339, 78);
            this.fntxt.Margin = new System.Windows.Forms.Padding(2);
            this.fntxt.Name = "fntxt";
            this.fntxt.Size = new System.Drawing.Size(181, 24);
            this.fntxt.TabIndex = 24;
            this.fntxt.TextChanged += new System.EventHandler(this.fntxt_TextChanged);
            // 
            // empIdtxt
            // 
            this.empIdtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.empIdtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empIdtxt.Location = new System.Drawing.Point(339, 39);
            this.empIdtxt.Margin = new System.Windows.Forms.Padding(2);
            this.empIdtxt.Name = "empIdtxt";
            this.empIdtxt.Size = new System.Drawing.Size(118, 24);
            this.empIdtxt.TabIndex = 23;
            this.empIdtxt.TextChanged += new System.EventHandler(this.empIdtxt_TextChanged);
            // 
            // lname
            // 
            this.lname.AutoSize = true;
            this.lname.BackColor = System.Drawing.Color.Transparent;
            this.lname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname.Location = new System.Drawing.Point(208, 122);
            this.lname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(123, 20);
            this.lname.TabIndex = 22;
            this.lname.Text = "LAST NAME : ";
            // 
            // fname
            // 
            this.fname.AutoSize = true;
            this.fname.BackColor = System.Drawing.Color.Transparent;
            this.fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname.Location = new System.Drawing.Point(208, 78);
            this.fname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(131, 20);
            this.fname.TabIndex = 21;
            this.fname.Text = "FIRST NAME : ";
            // 
            // empId
            // 
            this.empId.AutoSize = true;
            this.empId.BackColor = System.Drawing.Color.Transparent;
            this.empId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empId.Location = new System.Drawing.Point(208, 43);
            this.empId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.empId.Name = "empId";
            this.empId.Size = new System.Drawing.Size(139, 20);
            this.empId.TabIndex = 20;
            this.empId.Text = "EMPLOYEE ID: ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 263);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(904, 326);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // ALL_EMPLOYEE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(951, 619);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.delbtn);
            this.Controls.Add(this.updateEmp);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchEmp);
            this.Controls.Add(this.search);
            this.Controls.Add(this.addEmp);
            this.Controls.Add(this.taskBox);
            this.Controls.Add(this.projectBox);
            this.Controls.Add(this.deptBox);
            this.Controls.Add(this.task);
            this.Controls.Add(this.project);
            this.Controls.Add(this.department);
            this.Controls.Add(this.lntxt);
            this.Controls.Add(this.fntxt);
            this.Controls.Add(this.empIdtxt);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.empId);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ALL_EMPLOYEE";
            this.Text = "ALL_EMPLOYEE";
            this.Load += new System.EventHandler(this.ALL_EMPLOYEE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Button updateEmp;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox searchEmp;
        private System.Windows.Forms.Label search;
        private System.Windows.Forms.Button addEmp;
        private System.Windows.Forms.ComboBox taskBox;
        private System.Windows.Forms.ComboBox projectBox;
        private System.Windows.Forms.ComboBox deptBox;
        private System.Windows.Forms.Label task;
        private System.Windows.Forms.Label project;
        private System.Windows.Forms.Label department;
        private System.Windows.Forms.TextBox lntxt;
        private System.Windows.Forms.TextBox fntxt;
        private System.Windows.Forms.TextBox empIdtxt;
        private System.Windows.Forms.Label lname;
        private System.Windows.Forms.Label fname;
        private System.Windows.Forms.Label empId;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}