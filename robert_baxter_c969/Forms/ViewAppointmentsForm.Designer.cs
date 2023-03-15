namespace robert_baxter_c969.Forms
{
    partial class ViewAppointmentsForm
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.AppointmentDisplay = new System.Windows.Forms.DataGridView();
            this.AppointmentTabs = new System.Windows.Forms.TabControl();
            this.AllAppointmentsTab = new System.Windows.Forms.TabPage();
            this.WeeklyAppointmentsTab = new System.Windows.Forms.TabPage();
            this.MonthlyAppointmentsTab = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentDisplay)).BeginInit();
            this.AppointmentTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(820, 395);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(133, 43);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AppointmentDisplay
            // 
            this.AppointmentDisplay.AllowUserToAddRows = false;
            this.AppointmentDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AppointmentDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppointmentDisplay.Location = new System.Drawing.Point(36, 51);
            this.AppointmentDisplay.MultiSelect = false;
            this.AppointmentDisplay.Name = "AppointmentDisplay";
            this.AppointmentDisplay.Size = new System.Drawing.Size(774, 313);
            this.AppointmentDisplay.TabIndex = 2;
            this.AppointmentDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // AppointmentTabs
            // 
            this.AppointmentTabs.Controls.Add(this.AllAppointmentsTab);
            this.AppointmentTabs.Controls.Add(this.WeeklyAppointmentsTab);
            this.AppointmentTabs.Controls.Add(this.MonthlyAppointmentsTab);
            this.AppointmentTabs.Location = new System.Drawing.Point(36, 29);
            this.AppointmentTabs.Name = "AppointmentTabs";
            this.AppointmentTabs.SelectedIndex = 0;
            this.AppointmentTabs.Size = new System.Drawing.Size(328, 19);
            this.AppointmentTabs.TabIndex = 3;
            this.AppointmentTabs.SelectedIndexChanged += new System.EventHandler(this.OnTabChange);
            // 
            // AllAppointmentsTab
            // 
            this.AllAppointmentsTab.Location = new System.Drawing.Point(4, 22);
            this.AllAppointmentsTab.Name = "AllAppointmentsTab";
            this.AllAppointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AllAppointmentsTab.Size = new System.Drawing.Size(320, 0);
            this.AllAppointmentsTab.TabIndex = 0;
            this.AllAppointmentsTab.Text = "All Appointments";
            this.AllAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // WeeklyAppointmentsTab
            // 
            this.WeeklyAppointmentsTab.Location = new System.Drawing.Point(4, 22);
            this.WeeklyAppointmentsTab.Name = "WeeklyAppointmentsTab";
            this.WeeklyAppointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.WeeklyAppointmentsTab.Size = new System.Drawing.Size(192, 0);
            this.WeeklyAppointmentsTab.TabIndex = 1;
            this.WeeklyAppointmentsTab.Text = "Weekly Appointments";
            this.WeeklyAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // MonthlyAppointmentsTab
            // 
            this.MonthlyAppointmentsTab.Location = new System.Drawing.Point(4, 22);
            this.MonthlyAppointmentsTab.Name = "MonthlyAppointmentsTab";
            this.MonthlyAppointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.MonthlyAppointmentsTab.Size = new System.Drawing.Size(192, 0);
            this.MonthlyAppointmentsTab.TabIndex = 2;
            this.MonthlyAppointmentsTab.Text = "Monthly Appointments";
            this.MonthlyAppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // ViewAppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 450);
            this.Controls.Add(this.AppointmentTabs);
            this.Controls.Add(this.AppointmentDisplay);
            this.Controls.Add(this.ExitButton);
            this.Name = "ViewAppointmentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Appointments";
            this.Activated += new System.EventHandler(this.LoadAppointments);
            ((System.ComponentModel.ISupportInitialize)(this.AppointmentDisplay)).EndInit();
            this.AppointmentTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.DataGridView AppointmentDisplay;
        private System.Windows.Forms.TabControl AppointmentTabs;
        private System.Windows.Forms.TabPage AllAppointmentsTab;
        private System.Windows.Forms.TabPage WeeklyAppointmentsTab;
        private System.Windows.Forms.TabPage MonthlyAppointmentsTab;
    }
}