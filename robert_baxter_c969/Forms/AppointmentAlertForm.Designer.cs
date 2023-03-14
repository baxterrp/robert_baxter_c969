namespace robert_baxter_c969.Forms
{
    partial class AppointmentAlertForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ViewAppointmentsAlertButton = new System.Windows.Forms.Button();
            this.CloseAlertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "You have upcoming appointments.";
            // 
            // ViewAppointmentsAlertButton
            // 
            this.ViewAppointmentsAlertButton.Location = new System.Drawing.Point(29, 71);
            this.ViewAppointmentsAlertButton.Name = "ViewAppointmentsAlertButton";
            this.ViewAppointmentsAlertButton.Size = new System.Drawing.Size(133, 43);
            this.ViewAppointmentsAlertButton.TabIndex = 1;
            this.ViewAppointmentsAlertButton.Text = "View Appointments";
            this.ViewAppointmentsAlertButton.UseVisualStyleBackColor = true;
            this.ViewAppointmentsAlertButton.Click += new System.EventHandler(this.ViewAppointmentsAlertButton_Click);
            // 
            // CloseAlertButton
            // 
            this.CloseAlertButton.Location = new System.Drawing.Point(189, 71);
            this.CloseAlertButton.Name = "CloseAlertButton";
            this.CloseAlertButton.Size = new System.Drawing.Size(133, 43);
            this.CloseAlertButton.TabIndex = 2;
            this.CloseAlertButton.Text = "Close";
            this.CloseAlertButton.UseVisualStyleBackColor = true;
            this.CloseAlertButton.Click += new System.EventHandler(this.CloseAlertButton_Click);
            // 
            // AppointmentAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 126);
            this.Controls.Add(this.CloseAlertButton);
            this.Controls.Add(this.ViewAppointmentsAlertButton);
            this.Controls.Add(this.label1);
            this.Name = "AppointmentAlertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentAlertForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ViewAppointmentsAlertButton;
        private System.Windows.Forms.Button CloseAlertButton;
    }
}