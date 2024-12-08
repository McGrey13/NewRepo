namespace COMPANY
{
    partial class BackupAndRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupAndRestore));
            this.backUp = new System.Windows.Forms.Button();
            this.restore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backUp
            // 
            this.backUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.backUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backUp.Location = new System.Drawing.Point(138, 98);
            this.backUp.Name = "backUp";
            this.backUp.Size = new System.Drawing.Size(128, 55);
            this.backUp.TabIndex = 0;
            this.backUp.Text = "Back Up";
            this.backUp.UseVisualStyleBackColor = false;
            this.backUp.Click += new System.EventHandler(this.backUp_Click);
            // 
            // restore
            // 
            this.restore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restore.Location = new System.Drawing.Point(138, 190);
            this.restore.Name = "restore";
            this.restore.Size = new System.Drawing.Size(128, 55);
            this.restore.TabIndex = 1;
            this.restore.Text = "Restore";
            this.restore.UseVisualStyleBackColor = false;
            this.restore.Click += new System.EventHandler(this.button2_Click);
            // 
            // BackupAndRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.restore);
            this.Controls.Add(this.backUp);
            this.Name = "BackupAndRestore";
            this.Text = "BackupAndRestore";
            this.Load += new System.EventHandler(this.BackupAndRestore_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backUp;
        private System.Windows.Forms.Button restore;
    }
}