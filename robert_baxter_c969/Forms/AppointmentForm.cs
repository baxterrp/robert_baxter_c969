using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.DataModels;
using robert_baxter_c969.Data.Models;
using robert_baxter_c969.Data.ViewModels;
using robert_baxter_c969.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        private async void SaveButton_Click(object sender, EventArgs e)
        {
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
    }
}
