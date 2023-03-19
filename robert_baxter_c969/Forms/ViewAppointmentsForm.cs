using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.DataModels;
using robert_baxter_c969.Data.ViewModels;
using robert_baxter_c969.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace robert_baxter_c969.Forms
{
    public partial class ViewAppointmentsForm : BaseForm<ViewAppointmentsForm>
    {
        private IEnumerable<AppointmentViewModel> _appointments;
        private BindingSource _appointmentSource;

        public ViewAppointmentsForm(
            IFormFactory formFactory,
            ILogger<ViewAppointmentsForm> logger,
            IDataRepository dataRepository) : base(logger, dataRepository, formFactory)
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void LoadAppointments(object sender, EventArgs e)
        {
            await ExecuteAsync(async () =>
            {
                _appointments = await _dataRepository.ExecuteCustomQuery<AppointmentViewModel>(Constants.GetAppointmentsByUserId, new Dictionary<string, object>
                {
                    { "UserId", _formFactory.CreateForm<MainForm>().LoggedInUser.Id }
                });

                _appointmentSource = new BindingSource { DataSource = _appointments.Any() ? _appointments : null };
                AppointmentDisplay.DataSource = _appointmentSource;

                return true;
            }, string.Empty, "Failed to load appointments");
        }

        private void OnTabChange(object sender, EventArgs e)
        {
            var newAppointmentSource = new BindingSource();

            switch (AppointmentTabs.SelectedIndex)
            {
                case 1:
                    var weeklyAppointments = _appointments.Where(a => GetWeekNumber(a.StartTime) == GetWeekNumber(DateTime.Now));
                    newAppointmentSource.DataSource = weeklyAppointments.Any() ? weeklyAppointments : null;
                    break;
                case 2:
                    var monthlyAppointments = _appointments.Where(a => a.StartTime.Month == DateTime.Now.Month);
                    newAppointmentSource.DataSource = monthlyAppointments.Any() ? monthlyAppointments : null;
                    break;
                default:
                    newAppointmentSource.DataSource = _appointments.Any() ? _appointments : null;
                    break;
            }

            _appointmentSource.DataSource = newAppointmentSource;
        }

        private static int GetWeekNumber(DateTime date)
        {
            return
                new CultureInfo(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    .Calendar
                    .GetWeekOfYear(date, CalendarWeekRule.FirstFullWeek, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
        }

        private void AddAppointmentButton_Click(object sender, EventArgs e)
        {
            var appointmentForm = _formFactory.CreateForm<AppointmentForm>();
            appointmentForm.Show();
        }

        private void ModifyAppointmentButton_Click(object sender, EventArgs e)
        {
            var appointmentForm = _formFactory.CreateForm<AppointmentForm>();
            appointmentForm.SelectedAppointment = _appointments.ElementAt(AppointmentDisplay.CurrentRow.Index);
            appointmentForm.Show();
        }

        private async void DeleteAppointmentButton_Click(object sender, EventArgs e)
        {
            var confirmation =
               MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (DialogResult.Yes.Equals(confirmation))
            {
                var appointmentViewModel = _appointments.ElementAt(AppointmentDisplay.CurrentRow.Index);

                await ExecuteAsync(async () =>
                {
                    var appointment = await _dataRepository.GetById<Appointment>(appointmentViewModel.Id);
                    await _dataRepository.Delete(appointment);

                    return true;
                }, "Successfully canceled appointment", "Failed to cancel appointment");
            }
        }
    }
}
