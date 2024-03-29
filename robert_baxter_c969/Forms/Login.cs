﻿using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.Models;
using robert_baxter_c969.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace robert_baxter_c969.Forms
{

    public partial class Login : BaseForm<Login>
    {
        private readonly (string ErrorMessage, string UserTitle, string PasswordTitle) Culture;

        public Login(
            IFormFactory formFactory,
            ILogger<Login> logger,
            IDataRepository dataRepository) : base(logger, dataRepository, formFactory)
        {
            InitializeComponent();

            _loginButton.Enabled = false;
            _userNameText.MaxLength = Constants.FortyCharacterTextLimit;
            _passwordText.MaxLength = Constants.FortyCharacterTextLimit;
            _passwordText.PasswordChar = Constants.PasswordMaskCharacter;

            Culture = CultureInfo.CurrentCulture.Name.Equals(Constants.SpanishCultureInfo) ?
                (Constants.InvalidPasswordSpanish, "Nombre De Usuario", "Contraseña") :
                (Constants.InvalidPasswordEnglish, "User Name", "Password");

            UserNameLabel.Text = Culture.UserTitle;
            PasswordLabel.Text = Culture.PasswordTitle;
        }

        private async void LoginButton_Click(object sender, System.EventArgs e)
        {
            await ExecuteAsync(async () =>
            {
                var criteria = new Dictionary<string, string>
                {
                    { nameof(User.UserName), _userNameText.Text },
                };

                var user = (await _dataRepository.Get<User>(criteria)).FirstOrDefault();
                var passwordCorrect = _passwordText.Text.Equals(user?.Password ?? string.Empty);

                if (passwordCorrect)
                {
                    _logger.LogInformation("Successful login attempt by {name}", _userNameText.Text);
                    var mainForm = _formFactory.CreateForm<MainForm>();

                    // only hide to not close app
                    this.Hide();

                    // when the main form is closed finally close this one
                    mainForm.FormClosed += (s, args) => Close();

                    // set the user for life of app
                    mainForm.LoggedInUser = user;
                    mainForm.Show();
                }
                else
                {
                    _logger.LogInformation("Invalid login attempted by {name}", _userNameText.Text);
                    _passwordText.Text = string.Empty;
                }

                return passwordCorrect;
            }, string.Empty, Culture.ErrorMessage);
        }

        private void UserName_TextChanged(object sender, System.EventArgs e)
        {
            CheckLoginButtonEnabled();
        }

        private void Password_TextChanged(object sender, System.EventArgs e)
        {
            CheckLoginButtonEnabled();
        }

        private void CheckLoginButtonEnabled()
        {
            _loginButton.Enabled = !string.IsNullOrWhiteSpace(_userNameText.Text) && !string.IsNullOrWhiteSpace(_passwordText.Text);
        }
    }
}
