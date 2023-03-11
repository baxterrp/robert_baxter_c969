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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this._loginButton.Location = new System.Drawing.Point(252, 111);
            this._loginButton.Name = "LoginButton";
            this._loginButton.Size = new System.Drawing.Size(102, 22);
            this._loginButton.TabIndex = 0;
            this._loginButton.Text = "Login";
            this._loginButton.UseVisualStyleBackColor = true;
            this._loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // _userNameText
            // 
            this._userNameText.Location = new System.Drawing.Point(111, 32);
            this._userNameText.Name = "_userNameText";
            this._userNameText.Size = new System.Drawing.Size(243, 20);
            this._userNameText.TabIndex = 1;
            this._userNameText.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // _passwordText
            // 
            this._passwordText.Location = new System.Drawing.Point(109, 72);
            this._passwordText.Name = "_passwordText";
            this._passwordText.Size = new System.Drawing.Size(245, 20);
            this._passwordText.TabIndex = 2;
            this._passwordText.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 145);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}