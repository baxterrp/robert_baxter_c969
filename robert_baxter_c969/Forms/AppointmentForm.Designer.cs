using System.Windows.Forms;

namespace robert_baxter_c969.Forms
{
    partial class AppointmentForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CustomerSelect = new System.Windows.Forms.ListBox();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.label1 = new System.Windows.Forms.Label();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.StartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TitleValue = new System.Windows.Forms.TextBox();
            this.LocationText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.TextBox();
            this.TypeValue = new System.Windows.Forms.TextBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.ContactValue = new System.Windows.Forms.TextBox();
            this.ContactLabel = new System.Windows.Forms.Label();
            this.UrlValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(452, 361);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(133, 43);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(591, 361);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(133, 43);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CustomerSelect
            // 
            this.CustomerSelect.DisplayMember = "CustomerName";
            this.CustomerSelect.FormattingEnabled = true;
            this.CustomerSelect.Location = new System.Drawing.Point(17, 36);
            this.CustomerSelect.Name = "CustomerSelect";
            this.CustomerSelect.Size = new System.Drawing.Size(336, 69);
            this.CustomerSelect.TabIndex = 2;
            this.CustomerSelect.ValueMember = "Id";
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer";
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTimeLabel.Location = new System.Drawing.Point(14, 184);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(73, 17);
            this.StartTimeLabel.TabIndex = 4;
            this.StartTimeLabel.Text = "Start Time";
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartTimePicker.Location = new System.Drawing.Point(17, 204);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.Size = new System.Drawing.Size(337, 20);
            this.StartTimePicker.TabIndex = 5;
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTimePicker.Location = new System.Drawing.Point(17, 266);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.Size = new System.Drawing.Size(337, 20);
            this.EndTimePicker.TabIndex = 7;
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTimeLabel.Location = new System.Drawing.Point(14, 246);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(68, 17);
            this.EndTimeLabel.TabIndex = 6;
            this.EndTimeLabel.Text = "End Time";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(14, 124);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(35, 17);
            this.TitleLabel.TabIndex = 8;
            this.TitleLabel.Text = "Title";
            // 
            // TitleValue
            // 
            this.TitleValue.Location = new System.Drawing.Point(17, 144);
            this.TitleValue.Name = "TitleValue";
            this.TitleValue.Size = new System.Drawing.Size(336, 20);
            this.TitleValue.TabIndex = 9;
            // 
            // LocationText
            // 
            this.LocationText.Location = new System.Drawing.Point(388, 88);
            this.LocationText.Name = "LocationText";
            this.LocationText.Size = new System.Drawing.Size(336, 20);
            this.LocationText.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(386, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(386, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Description";
            // 
            // DescriptionText
            // 
            this.DescriptionText.Location = new System.Drawing.Point(388, 204);
            this.DescriptionText.Multiline = true;
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(336, 135);
            this.DescriptionText.TabIndex = 13;
            // 
            // TypeValue
            // 
            this.TypeValue.Location = new System.Drawing.Point(388, 36);
            this.TypeValue.Name = "TypeValue";
            this.TypeValue.Size = new System.Drawing.Size(336, 20);
            this.TypeValue.TabIndex = 15;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeLabel.Location = new System.Drawing.Point(386, 12);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(40, 17);
            this.TypeLabel.TabIndex = 14;
            this.TypeLabel.Text = "Type";
            // 
            // ContactValue
            // 
            this.ContactValue.Location = new System.Drawing.Point(388, 144);
            this.ContactValue.Name = "ContactValue";
            this.ContactValue.Size = new System.Drawing.Size(336, 20);
            this.ContactValue.TabIndex = 17;
            // 
            // ContactLabel
            // 
            this.ContactLabel.AutoSize = true;
            this.ContactLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactLabel.Location = new System.Drawing.Point(386, 124);
            this.ContactLabel.Name = "ContactLabel";
            this.ContactLabel.Size = new System.Drawing.Size(56, 17);
            this.ContactLabel.TabIndex = 16;
            this.ContactLabel.Text = "Contact";
            // 
            // UrlValue
            // 
            this.UrlValue.Location = new System.Drawing.Point(18, 319);
            this.UrlValue.Name = "UrlValue";
            this.UrlValue.Size = new System.Drawing.Size(336, 20);
            this.UrlValue.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Url";
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 416);
            this.Controls.Add(this.UrlValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ContactValue);
            this.Controls.Add(this.ContactLabel);
            this.Controls.Add(this.TypeValue);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.DescriptionText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LocationText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleValue);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.EndTimePicker);
            this.Controls.Add(this.EndTimeLabel);
            this.Controls.Add(this.StartTimePicker);
            this.Controls.Add(this.StartTimeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustomerSelect);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "AppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentForm";
            this.Load += new System.EventHandler(this.LoadCustomers);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ListBox CustomerSelect;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.DateTimePicker StartTimePicker;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
        private System.Windows.Forms.Label EndTimeLabel;
        private Label TitleLabel;
        private TextBox TitleValue;
        private TextBox LocationText;
        private Label label2;
        private Label label3;
        private TextBox DescriptionText;
        private TextBox TypeValue;
        private Label TypeLabel;
        private TextBox ContactValue;
        private Label ContactLabel;
        private TextBox UrlValue;
        private Label label4;
    }
}