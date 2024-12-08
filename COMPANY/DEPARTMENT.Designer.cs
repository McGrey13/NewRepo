namespace COMPANY
{
    partial class DEPARTMENT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DEPARTMENT));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.deleteDepartment = new System.Windows.Forms.Button();
            this.updateDepartment = new System.Windows.Forms.Button();
            this.addDepartment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.departmentName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "DEPARTMENTS:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(99, 120);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(647, 243);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // deleteDepartment
            // 
            this.deleteDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.deleteDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteDepartment.Location = new System.Drawing.Point(502, 431);
            this.deleteDepartment.Name = "deleteDepartment";
            this.deleteDepartment.Size = new System.Drawing.Size(95, 41);
            this.deleteDepartment.TabIndex = 20;
            this.deleteDepartment.Text = "Delete";
            this.deleteDepartment.UseVisualStyleBackColor = false;
            this.deleteDepartment.Click += new System.EventHandler(this.deleteDepartment_Click);
            // 
            // updateDepartment
            // 
            this.updateDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.updateDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateDepartment.Location = new System.Drawing.Point(366, 431);
            this.updateDepartment.Name = "updateDepartment";
            this.updateDepartment.Size = new System.Drawing.Size(95, 41);
            this.updateDepartment.TabIndex = 19;
            this.updateDepartment.Text = "Update";
            this.updateDepartment.UseVisualStyleBackColor = false;
            this.updateDepartment.Click += new System.EventHandler(this.updateDepartment_Click);
            // 
            // addDepartment
            // 
            this.addDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.addDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDepartment.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addDepartment.Location = new System.Drawing.Point(223, 431);
            this.addDepartment.Name = "addDepartment";
            this.addDepartment.Size = new System.Drawing.Size(95, 41);
            this.addDepartment.TabIndex = 18;
            this.addDepartment.Text = "Add Department";
            this.addDepartment.UseVisualStyleBackColor = false;
            this.addDepartment.Click += new System.EventHandler(this.addDepartment_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Department Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // departmentName
            // 
            this.departmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentName.Location = new System.Drawing.Point(357, 405);
            this.departmentName.Name = "departmentName";
            this.departmentName.Size = new System.Drawing.Size(120, 24);
            this.departmentName.TabIndex = 22;
            this.departmentName.TextChanged += new System.EventHandler(this.departmentName_TextChanged_1);
            // 
            // DEPARTMENT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(844, 544);
            this.Controls.Add(this.departmentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteDepartment);
            this.Controls.Add(this.updateDepartment);
            this.Controls.Add(this.addDepartment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DEPARTMENT";
            this.Text = "DEPARTMENT";
            this.Load += new System.EventHandler(this.DEPARTMENT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteDepartment;
        private System.Windows.Forms.Button updateDepartment;
        private System.Windows.Forms.Button addDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox departmentName;
    }
}