namespace robert_baxter_c969.Forms
{
    partial class MainForm
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
            this.CustomerDisplay = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.ModifyUserButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ViewAppointmentsButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerDisplay
            // 
            this.CustomerDisplay.AllowUserToAddRows = false;
            this.CustomerDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDisplay.Location = new System.Drawing.Point(33, 36);
            this.CustomerDisplay.MultiSelect = false;
            this.CustomerDisplay.Name = "CustomerDisplay";
            this.CustomerDisplay.ReadOnly = true;
            this.CustomerDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerDisplay.Size = new System.Drawing.Size(867, 239);
            this.CustomerDisplay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customers";
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(906, 36);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(133, 43);
            this.AddUserButton.TabIndex = 2;
            this.AddUserButton.Text = "Add New";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // ModifyUserButton
            // 
            this.ModifyUserButton.Location = new System.Drawing.Point(906, 85);
            this.ModifyUserButton.Name = "ModifyUserButton";
            this.ModifyUserButton.Size = new System.Drawing.Size(133, 43);
            this.ModifyUserButton.TabIndex = 3;
            this.ModifyUserButton.Text = "Modify";
            this.ModifyUserButton.UseVisualStyleBackColor = true;
            this.ModifyUserButton.Click += new System.EventHandler(this.ModifyUserButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(906, 134);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(133, 43);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ViewAppointmentsButton
            // 
            this.ViewAppointmentsButton.Location = new System.Drawing.Point(767, 281);
            this.ViewAppointmentsButton.Name = "ViewAppointmentsButton";
            this.ViewAppointmentsButton.Size = new System.Drawing.Size(133, 43);
            this.ViewAppointmentsButton.TabIndex = 5;
            this.ViewAppointmentsButton.Text = "View Appointments";
            this.ViewAppointmentsButton.UseVisualStyleBackColor = true;
            this.ViewAppointmentsButton.Click += new System.EventHandler(this.ViewAppointmentsButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(906, 281);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(133, 43);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 330);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ViewAppointmentsButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ModifyUserButton);
            this.Controls.Add(this.AddUserButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomerDisplay);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Scheduler";
            this.Activated += new System.EventHandler(this.LoadCustomers);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CustomerDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Button ModifyUserButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ViewAppointmentsButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

