namespace robert_baxter_c969.Forms
{
    partial class Reports
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
            this.ConsultantScheduleTab = new System.Windows.Forms.TabPage();
            this.ConsultScheduleGrid = new System.Windows.Forms.DataGridView();
            this.ExecuteConsultantScheduleReport = new System.Windows.Forms.Button();
            this.ConsultantSelectList = new System.Windows.Forms.ListBox();
            this.CustomersByCountryTab = new System.Windows.Forms.TabPage();
            this.ExecuteCustomerByCountry = new System.Windows.Forms.Button();
            this.CustomerByCountryGrid = new System.Windows.Forms.DataGridView();
            this.CountrySelectList = new System.Windows.Forms.ListBox();
            this.ReportsTabs = new System.Windows.Forms.TabControl();
            this.AppointmentCountsTab = new System.Windows.Forms.TabPage();
            this.AppByMonthData = new System.Windows.Forms.DataGridView();
            this.ExecuteAppByMonth = new System.Windows.Forms.Button();
            this.AppointmentMonthSelectList = new System.Windows.Forms.ListBox();
            this.ConsultantScheduleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultScheduleGrid)).BeginInit();
            this.CustomersByCountryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerByCountryGrid)).BeginInit();
            this.ReportsTabs.SuspendLayout();
            this.AppointmentCountsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppByMonthData)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(655, 395);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(133, 43);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ConsultantScheduleTab
            // 
            this.ConsultantScheduleTab.Controls.Add(this.ConsultScheduleGrid);
            this.ConsultantScheduleTab.Controls.Add(this.ExecuteConsultantScheduleReport);
            this.ConsultantScheduleTab.Controls.Add(this.ConsultantSelectList);
            this.ConsultantScheduleTab.Location = new System.Drawing.Point(4, 22);
            this.ConsultantScheduleTab.Name = "ConsultantScheduleTab";
            this.ConsultantScheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConsultantScheduleTab.Size = new System.Drawing.Size(768, 342);
            this.ConsultantScheduleTab.TabIndex = 1;
            this.ConsultantScheduleTab.Text = "Consultant Schedule";
            this.ConsultantScheduleTab.UseVisualStyleBackColor = true;
            // 
            // ConsultScheduleGrid
            // 
            this.ConsultScheduleGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ConsultScheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultScheduleGrid.Location = new System.Drawing.Point(177, 16);
            this.ConsultScheduleGrid.MultiSelect = false;
            this.ConsultScheduleGrid.Name = "ConsultScheduleGrid";
            this.ConsultScheduleGrid.ReadOnly = true;
            this.ConsultScheduleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConsultScheduleGrid.Size = new System.Drawing.Size(575, 238);
            this.ConsultScheduleGrid.TabIndex = 11;
            // 
            // ExecuteConsultantScheduleReport
            // 
            this.ExecuteConsultantScheduleReport.Location = new System.Drawing.Point(619, 283);
            this.ExecuteConsultantScheduleReport.Name = "ExecuteConsultantScheduleReport";
            this.ExecuteConsultantScheduleReport.Size = new System.Drawing.Size(133, 43);
            this.ExecuteConsultantScheduleReport.TabIndex = 10;
            this.ExecuteConsultantScheduleReport.Text = "Run";
            this.ExecuteConsultantScheduleReport.UseVisualStyleBackColor = true;
            this.ExecuteConsultantScheduleReport.Click += new System.EventHandler(this.ExecuteConsultantScheduleReport_Click);
            // 
            // ConsultantSelectList
            // 
            this.ConsultantSelectList.DisplayMember = "UserName";
            this.ConsultantSelectList.FormattingEnabled = true;
            this.ConsultantSelectList.Location = new System.Drawing.Point(19, 16);
            this.ConsultantSelectList.Name = "ConsultantSelectList";
            this.ConsultantSelectList.Size = new System.Drawing.Size(120, 238);
            this.ConsultantSelectList.TabIndex = 1;
            this.ConsultantSelectList.ValueMember = "Id";
            // 
            // CustomersByCountryTab
            // 
            this.CustomersByCountryTab.Controls.Add(this.ExecuteCustomerByCountry);
            this.CustomersByCountryTab.Controls.Add(this.CustomerByCountryGrid);
            this.CustomersByCountryTab.Controls.Add(this.CountrySelectList);
            this.CustomersByCountryTab.Location = new System.Drawing.Point(4, 22);
            this.CustomersByCountryTab.Name = "CustomersByCountryTab";
            this.CustomersByCountryTab.Padding = new System.Windows.Forms.Padding(3);
            this.CustomersByCountryTab.Size = new System.Drawing.Size(768, 342);
            this.CustomersByCountryTab.TabIndex = 1;
            this.CustomersByCountryTab.Text = "Customers by Country";
            this.CustomersByCountryTab.UseVisualStyleBackColor = true;
            // 
            // ExecuteCustomerByCountry
            // 
            this.ExecuteCustomerByCountry.Location = new System.Drawing.Point(619, 283);
            this.ExecuteCustomerByCountry.Name = "ExecuteCustomerByCountry";
            this.ExecuteCustomerByCountry.Size = new System.Drawing.Size(133, 43);
            this.ExecuteCustomerByCountry.TabIndex = 13;
            this.ExecuteCustomerByCountry.Text = "Run";
            this.ExecuteCustomerByCountry.UseVisualStyleBackColor = true;
            this.ExecuteCustomerByCountry.Click += new System.EventHandler(this.ExecuteCustomerByCountry_Click);
            // 
            // CustomerByCountryGrid
            // 
            this.CustomerByCountryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomerByCountryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerByCountryGrid.Location = new System.Drawing.Point(177, 16);
            this.CustomerByCountryGrid.MultiSelect = false;
            this.CustomerByCountryGrid.Name = "CustomerByCountryGrid";
            this.CustomerByCountryGrid.ReadOnly = true;
            this.CustomerByCountryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerByCountryGrid.Size = new System.Drawing.Size(575, 238);
            this.CustomerByCountryGrid.TabIndex = 12;
            // 
            // CountrySelectList
            // 
            this.CountrySelectList.DisplayMember = "UserName";
            this.CountrySelectList.FormattingEnabled = true;
            this.CountrySelectList.Location = new System.Drawing.Point(19, 16);
            this.CountrySelectList.Name = "CountrySelectList";
            this.CountrySelectList.Size = new System.Drawing.Size(120, 238);
            this.CountrySelectList.TabIndex = 2;
            this.CountrySelectList.ValueMember = "Id";
            // 
            // ReportsTabs
            // 
            this.ReportsTabs.Controls.Add(this.AppointmentCountsTab);
            this.ReportsTabs.Controls.Add(this.ConsultantScheduleTab);
            this.ReportsTabs.Controls.Add(this.CustomersByCountryTab);
            this.ReportsTabs.Location = new System.Drawing.Point(12, 12);
            this.ReportsTabs.Name = "ReportsTabs";
            this.ReportsTabs.SelectedIndex = 0;
            this.ReportsTabs.Size = new System.Drawing.Size(776, 368);
            this.ReportsTabs.TabIndex = 8;
            // 
            // AppointmentCountsTab
            // 
            this.AppointmentCountsTab.Controls.Add(this.AppByMonthData);
            this.AppointmentCountsTab.Controls.Add(this.ExecuteAppByMonth);
            this.AppointmentCountsTab.Controls.Add(this.AppointmentMonthSelectList);
            this.AppointmentCountsTab.Location = new System.Drawing.Point(4, 22);
            this.AppointmentCountsTab.Name = "AppointmentCountsTab";
            this.AppointmentCountsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AppointmentCountsTab.Size = new System.Drawing.Size(768, 342);
            this.AppointmentCountsTab.TabIndex = 0;
            this.AppointmentCountsTab.Text = "Appointments by Month";
            this.AppointmentCountsTab.UseVisualStyleBackColor = true;
            // 
            // AppByMonthData
            // 
            this.AppByMonthData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AppByMonthData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppByMonthData.Location = new System.Drawing.Point(177, 16);
            this.AppByMonthData.MultiSelect = false;
            this.AppByMonthData.Name = "AppByMonthData";
            this.AppByMonthData.ReadOnly = true;
            this.AppByMonthData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AppByMonthData.Size = new System.Drawing.Size(575, 238);
            this.AppByMonthData.TabIndex = 10;
            // 
            // ExecuteAppByMonth
            // 
            this.ExecuteAppByMonth.Location = new System.Drawing.Point(619, 283);
            this.ExecuteAppByMonth.Name = "ExecuteAppByMonth";
            this.ExecuteAppByMonth.Size = new System.Drawing.Size(133, 43);
            this.ExecuteAppByMonth.TabIndex = 9;
            this.ExecuteAppByMonth.Text = "Run";
            this.ExecuteAppByMonth.UseVisualStyleBackColor = true;
            this.ExecuteAppByMonth.Click += new System.EventHandler(this.ExecuteAppByMonth_Click);
            // 
            // AppointmentMonthSelectList
            // 
            this.AppointmentMonthSelectList.FormattingEnabled = true;
            this.AppointmentMonthSelectList.Location = new System.Drawing.Point(19, 16);
            this.AppointmentMonthSelectList.Name = "AppointmentMonthSelectList";
            this.AppointmentMonthSelectList.Size = new System.Drawing.Size(120, 238);
            this.AppointmentMonthSelectList.TabIndex = 0;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReportsTabs);
            this.Controls.Add(this.ExitButton);
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.LoadReportsData);
            this.ConsultantScheduleTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConsultScheduleGrid)).EndInit();
            this.CustomersByCountryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerByCountryGrid)).EndInit();
            this.ReportsTabs.ResumeLayout(false);
            this.AppointmentCountsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AppByMonthData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TabPage ConsultantScheduleTab;
        private System.Windows.Forms.TabControl ReportsTabs;
        private System.Windows.Forms.TabPage AppointmentCountsTab;
        private System.Windows.Forms.TabPage CustomersByCountryTab;
        private System.Windows.Forms.ListBox AppointmentMonthSelectList;
        private System.Windows.Forms.Button ExecuteAppByMonth;
        private System.Windows.Forms.DataGridView AppByMonthData;
        private System.Windows.Forms.ListBox ConsultantSelectList;
        private System.Windows.Forms.Button ExecuteConsultantScheduleReport;
        private System.Windows.Forms.DataGridView ConsultScheduleGrid;
        private System.Windows.Forms.Button ExecuteCustomerByCountry;
        private System.Windows.Forms.DataGridView CustomerByCountryGrid;
        private System.Windows.Forms.ListBox CountrySelectList;
    }
}