namespace robert_baxter_c969.Forms
{
    partial class Login
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
            this._loginButton = new System.Windows.Forms.Button();
            this._userNameText = new System.Windows.Forms.TextBox();
            this._passwordText = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _loginButton
            // 
            this._loginButton.Location = new System.Drawing.Point(316, 111);
            this._loginButton.Name = "_loginButton";
            this._loginButton.Size = new System.Drawing.Size(102, 22);
            this._loginButton.TabIndex = 0;
            this._loginButton.Text = "Login";
            this._loginButton.UseVisualStyleBackColor = true;
            this._loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // _userNameText
            // 
            this._userNameText.Location = new System.Drawing.Point(175, 29);
            this._userNameText.Name = "_userNameText";
            this._userNameText.Size = new System.Drawing.Size(243, 20);
            this._userNameText.TabIndex = 1;
            this._userNameText.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // _passwordText
            // 
            this._passwordText.Location = new System.Drawing.Point(173, 72);
            this._passwordText.Name = "_passwordText";
            this._passwordText.Size = new System.Drawing.Size(245, 20);
            this._passwordText.TabIndex = 2;
            this._passwordText.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(21, 32);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(60, 13);
            this.UserNameLabel.TabIndex = 3;
            this.UserNameLabel.Text = "User Name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(21, 72);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 145);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this._passwordText);
            this.Controls.Add(this._userNameText);
            this.Controls.Add(this._loginButton);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _loginButton;
        private System.Windows.Forms.TextBox _userNameText;
        private System.Windows.Forms.TextBox _passwordText;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
    }
}