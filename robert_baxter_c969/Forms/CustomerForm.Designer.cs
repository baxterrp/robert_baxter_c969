namespace robert_baxter_c969.Forms
{
    partial class CustomerForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AddressLine1Label = new System.Windows.Forms.Label();
            this.NameValue = new System.Windows.Forms.TextBox();
            this.AddressLine1Value = new System.Windows.Forms.TextBox();
            this.AddressLine2Value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CityValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CountryValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PostalCodeValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PhoneNumberValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(268, 244);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(133, 43);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Cancel";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(407, 244);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(133, 43);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(33, 34);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Name";
            // 
            // AddressLine1Label
            // 
            this.AddressLine1Label.AutoSize = true;
            this.AddressLine1Label.Location = new System.Drawing.Point(33, 89);
            this.AddressLine1Label.Name = "AddressLine1Label";
            this.AddressLine1Label.Size = new System.Drawing.Size(77, 13);
            this.AddressLine1Label.TabIndex = 3;
            this.AddressLine1Label.Text = "Address Line 1";
            // 
            // NameValue
            // 
            this.NameValue.Location = new System.Drawing.Point(36, 50);
            this.NameValue.Name = "NameValue";
            this.NameValue.Size = new System.Drawing.Size(225, 20);
            this.NameValue.TabIndex = 4;
            // 
            // AddressLine1Value
            // 
            this.AddressLine1Value.Location = new System.Drawing.Point(36, 105);
            this.AddressLine1Value.Name = "AddressLine1Value";
            this.AddressLine1Value.Size = new System.Drawing.Size(225, 20);
            this.AddressLine1Value.TabIndex = 5;
            // 
            // AddressLine2Value
            // 
            this.AddressLine2Value.Location = new System.Drawing.Point(36, 155);
            this.AddressLine2Value.Name = "AddressLine2Value";
            this.AddressLine2Value.Size = new System.Drawing.Size(225, 20);
            this.AddressLine2Value.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Address Line 2";
            // 
            // CityValue
            // 
            this.CityValue.Location = new System.Drawing.Point(36, 206);
            this.CityValue.Name = "CityValue";
            this.CityValue.Size = new System.Drawing.Size(225, 20);
            this.CityValue.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "City";
            // 
            // CountryValue
            // 
            this.CountryValue.Location = new System.Drawing.Point(315, 105);
            this.CountryValue.Name = "CountryValue";
            this.CountryValue.Size = new System.Drawing.Size(225, 20);
            this.CountryValue.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Country";
            // 
            // PostalCodeValue
            // 
            this.PostalCodeValue.Location = new System.Drawing.Point(315, 155);
            this.PostalCodeValue.Name = "PostalCodeValue";
            this.PostalCodeValue.Size = new System.Drawing.Size(225, 20);
            this.PostalCodeValue.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Postal Code";
            // 
            // PhoneNumberValue
            // 
            this.PhoneNumberValue.Location = new System.Drawing.Point(315, 50);
            this.PhoneNumberValue.Name = "PhoneNumberValue";
            this.PhoneNumberValue.Size = new System.Drawing.Size(225, 20);
            this.PhoneNumberValue.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Phone Number";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 303);
            this.Controls.Add(this.PhoneNumberValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PostalCodeValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CountryValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CityValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddressLine2Value);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddressLine1Value);
            this.Controls.Add(this.NameValue);
            this.Controls.Add(this.AddressLine1Label);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ExitButton);
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.LoadCustomerData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label AddressLine1Label;
        private System.Windows.Forms.TextBox NameValue;
        private System.Windows.Forms.TextBox AddressLine1Value;
        private System.Windows.Forms.TextBox AddressLine2Value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CityValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CountryValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PostalCodeValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PhoneNumberValue;
        private System.Windows.Forms.Label label5;
    }
}