namespace COMPANY
{
    partial class ADMIN
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
            System.Windows.Forms.Button departmentbtn;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMIN));
            this.taskbtn = new System.Windows.Forms.Button();
            this.projectbtn = new System.Windows.Forms.Button();
            this.empbtn = new System.Windows.Forms.Button();
            this.backupAndRestore = new System.Windows.Forms.Button();
            this.logOut = new System.Windows.Forms.Button();
            departmentbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // departmentbtn
            // 
            departmentbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            departmentbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            departmentbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            departmentbtn.Location = new System.Drawing.Point(242, 117);
            departmentbtn.Margin = new System.Windows.Forms.Padding(2);
            departmentbtn.Name = "departmentbtn";
            departmentbtn.Size = new System.Drawing.Size(116, 51);
            departmentbtn.TabIndex = 17;
            departmentbtn.Text = "DEPARTMENT";
            departmentbtn.UseVisualStyleBackColor = false;
            departmentbtn.Click += new System.EventHandler(this.departmentbtn_Click);
            // 
            // taskbtn
            // 
            this.taskbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.taskbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskbtn.Location = new System.Drawing.Point(242, 277);
            this.taskbtn.Margin = new System.Windows.Forms.Padding(2);
            this.taskbtn.Name = "taskbtn";
            this.taskbtn.Size = new System.Drawing.Size(116, 51);
            this.taskbtn.TabIndex = 19;
            this.taskbtn.Text = "TASK";
            this.taskbtn.UseVisualStyleBackColor = false;
            this.taskbtn.Click += new System.EventHandler(this.taskbtn_Click);
            // 
            // projectbtn
            // 
            this.projectbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.projectbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectbtn.Location = new System.Drawing.Point(242, 199);
            this.projectbtn.Margin = new System.Windows.Forms.Padding(2);
            this.projectbtn.Name = "projectbtn";
            this.projectbtn.Size = new System.Drawing.Size(116, 51);
            this.projectbtn.TabIndex = 18;
            this.projectbtn.Text = "PROJECT";
            this.projectbtn.UseVisualStyleBackColor = false;
            this.projectbtn.Click += new System.EventHandler(this.projectbtn_Click);
            // 
            // empbtn
            // 
            this.empbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.empbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.empbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empbtn.Location = new System.Drawing.Point(242, 38);
            this.empbtn.Margin = new System.Windows.Forms.Padding(2);
            this.empbtn.Name = "empbtn";
            this.empbtn.Size = new System.Drawing.Size(116, 51);
            this.empbtn.TabIndex = 16;
            this.empbtn.Text = "EMPLOYEE";
            this.empbtn.UseVisualStyleBackColor = false;
            this.empbtn.Click += new System.EventHandler(this.empbtn_Click);
            // 
            // backupAndRestore
            // 
            this.backupAndRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.backupAndRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backupAndRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupAndRestore.Location = new System.Drawing.Point(242, 347);
            this.backupAndRestore.Margin = new System.Windows.Forms.Padding(2);
            this.backupAndRestore.Name = "backupAndRestore";
            this.backupAndRestore.Size = new System.Drawing.Size(116, 51);
            this.backupAndRestore.TabIndex = 20;
            this.backupAndRestore.Text = "Back Up and Restore";
            this.backupAndRestore.UseVisualStyleBackColor = false;
            this.backupAndRestore.Click += new System.EventHandler(this.backupAndRestore_Click);
            // 
            // logOut
            // 
            this.logOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.logOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOut.Location = new System.Drawing.Point(473, 11);
            this.logOut.Margin = new System.Windows.Forms.Padding(2);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(94, 27);
            this.logOut.TabIndex = 21;
            this.logOut.Text = "Log out";
            this.logOut.UseVisualStyleBackColor = false;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // ADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 420);
            this.Controls.Add(this.logOut);
            this.Controls.Add(this.backupAndRestore);
            this.Controls.Add(this.taskbtn);
            this.Controls.Add(this.projectbtn);
            this.Controls.Add(departmentbtn);
            this.Controls.Add(this.empbtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ADMIN";
            this.Text = "ADMIN";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button taskbtn;
        private System.Windows.Forms.Button projectbtn;
        private System.Windows.Forms.Button empbtn;
        private System.Windows.Forms.Button backupAndRestore;
        private System.Windows.Forms.Button logOut;
    }
}