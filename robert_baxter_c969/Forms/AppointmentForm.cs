using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.DataModels;
using robert_baxter_c969.Data.Models;
using robert_baxter_c969.Data.ViewModels;
using robert_baxter_c969.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace robert_baxter_c969.Forms
{
    public partial class AppointmentForm : BaseForm<AppointmentForm>
    {
        private IEnumerable<Customer> _customers;

        public AppointmentViewModel SelectedAppointment { get; set; }

        public AppointmentForm(
            IFormFactory formFactory,
            ILogger<AppointmentForm> logger,
            IDataRepository dataRepository) : base(logger, dataRepository, formFactory)
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidateField(string fieldName)
        {
            var hasError = false;

            switch (fieldName)
            {
                case nameof(TitleValue):
                    hasError = string.IsNullOrWhiteSpace(TitleValue.Text);
                    TitleValue.BackColor = hasError ? Color.Salmon : Color.White;
                    break;
                case nameof(StartTimePicker):
                    var startTimeMessage =
                        StartTimePicker.Value.TimeOfDay < new TimeSpan(9, 0, 0) || StartTimePicker.Value.TimeOfDay > new TimeSpan(17, 0, 0) ?
                        "Start time must within business hours : 9am and 5pm" : StartTimePicker.Value > EndTimePicker.Value ? "Start time must be before end time" : string.Empty;
                    StartTimeErrorMessage.Text = startTimeMessage;
                    hasError = !string.IsNullOrWhiteSpace(startTimeMessage);
                    break;
                case nameof(EndTimePicker):
                    hasError = EndTimePicker.Value.TimeOfDay < new TimeSpan(9, 0, 0) || EndTimePicker.Value.TimeOfDay > new TimeSpan(17, 0, 0);
                    EndTimeErrorMessage.Text = hasError ? "End time must within business hours : 9am and 5pm" : string.Empty;

                    // need to reset start time error if changing end time resolved the start/end date error
                    if (EndTimePicker.Value > StartTimePicker.Value)
                    {
                        StartTimeErrorMessage.Text = string.Empty;
                    }

                    break;
                case nameof(TypeValue):
                    hasError = string.IsNullOrWhiteSpace(TypeValue.Text);
                    TypeValue.BackColor = hasError ? Color.Salmon : Color.White;
                    break;
            }

            SaveButton.Enabled = !hasError;

            return hasError;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            var requiredFields = new List<string> { nameof(TitleValue), nameof(StartTimePicker), nameof(EndTimePicker), nameof(TypeValue) };
            var hasErrors = false;

            foreach (var field in requiredFields)
            {
                hasErrors |= ValidateField(field);
            }

            if (hasErrors)
            {
                SaveButton.Enabled = false;
                return;
            }
            
            // if all of the regular field validation has passed to this point, lets check for overlapping appointments
            var userId = _formFactory.CreateForm<MainForm>().LoggedInUser.Id;
            var appointments = await _dataRepository.ExecuteCustomQuery<AppointmentViewModel>(Constants.GetAppointmentsByUserId, new Dictionary<string, object>
            {
                { nameof(Appointment.UserId), userId },
            });

            var hasOverlappingAppointments =
                appointments
                    .Where(appointment => appointment.Id != SelectedAppointment.Id)
                    .Any(appointment => 
                        // zero out the seconds for the time comparisons
                        appointment.StartTime.AddSeconds(-1 * appointment.StartTime.Second) <= EndTimePicker.Value.AddSeconds(-1 * EndTimePicker.Value.Second) &&
                        StartTimePicker.Value.AddSeconds(-1 * StartTimePicker.Value.Second) <= appointment.EndTime.AddSeconds(-1 * appointment.EndTime.Second));

            if (hasOverlappingAppointments)
            {
                MessageBox.Show("Your appointment time overlaps with an existing appointment, please correct before continuing");
                return;
            }

            await ExecuteAsync(async () =>
            {
                if (SelectedAppointment is null) { return false; }

                if (SelectedAppointment.Id <= 0)
                {
                    var user = _formFactory.CreateForm<MainForm>().LoggedInUser;

                    var appointment = new Appointment
                    {
                        UserId = user.Id,
                        CustomerId = (int)CustomerSelect.SelectedValue,
                        Title = TitleValue.Text,
                        Type = TypeValue.Text,
                        Contact = ContactValue.Text,
                        Start = StartTimePicker.Value.ToUniversalTime(),
                        End = EndTimePicker.Value.ToUniversalTime(),
                        Description = DescriptionText.Text,
                        Location = LocationText.Text,
                        Url = UrlValue.Text,
                    };

                    await _dataRepository.Insert(appointment);
                }
                else
                {
                    var persistedAppointment = await _dataRepository.GetById<Appointment>(SelectedAppointment.Id);
                    persistedAppointment.CustomerId = (int)CustomerSelect.SelectedValue;
                    persistedAppointment.Title = TitleValue.Text;
                    persistedAppointment.Type = TypeValue.Text;
                    persistedAppointment.Contact = ContactValue.Text;
                    persistedAppointment.Start = StartTimePicker.Value.ToUniversalTime();
                    persistedAppointment.End = EndTimePicker.Value.ToUniversalTime();
                    persistedAppointment.Description = DescriptionText.Text;
                    persistedAppointment.Location = LocationText.Text;
                    persistedAppointment.Url = UrlValue.Text;

                    await _dataRepository.Update(persistedAppointment);
                }

                return true;
            }, "Successfully saved appointment", "Failed to save appointment");

            Close();
        }

        private async void LoadCustomers(object sender, EventArgs e)
        {
            await ExecuteAsync(async () =>
            {
                _customers = await _dataRepository.Get<Customer>(null);
                CustomerSelect.DataSource = _customers;

                LoadAppointment();

                return true;
            }, string.Empty, "Failed to load customers");
        }

        private void LoadAppointment()
        {
            if (SelectedAppointment is null)
            {
                SelectedAppointment = new AppointmentViewModel();
            }
            else
            {
                CustomerSelect.SelectedValue = SelectedAppointment.CustomerId;
                StartTimePicker.Value = SelectedAppointment.StartTime.ToLocalTime();
                EndTimePicker.Value = SelectedAppointment.EndTime.ToLocalTime();
                TitleValue.Text = SelectedAppointment.Title;
                TypeValue.Text = SelectedAppointment.Type;
                DescriptionText.Text = SelectedAppointment.Description;
                LocationText.Text = SelectedAppointment.Location;
                ContactValue.Text = SelectedAppointment.Contact;
                UrlValue.Text = SelectedAppointment.Url;
            }
        }

        private void ValidateOnFocusOut(object sender, EventArgs e)
        {
            var name = sender.GetType().GetProperty("Name").GetValue(sender, null).ToString();
            ValidateField(name);
        }
    }
}
