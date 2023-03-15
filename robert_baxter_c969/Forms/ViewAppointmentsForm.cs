using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
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
        private BindingSource _appointmentsSource;

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

                _appointmentsSource = new BindingSource { DataSource = _appointments };
                AppointmentDisplay.DataSource = _appointmentsSource;

                return true;
            }, string.Empty, "Failed to load appointments");
        }

        private void OnTabChange(object sender, EventArgs e)
        {
            var newAppointmentSource = new BindingSource(); 
            
            switch(AppointmentTabs.SelectedIndex)
            {
                case 1:
                    newAppointmentSource.DataSource = _appointments.Where(a => GetWeekNumber(a.StartTime) == GetWeekNumber(DateTime.Now));
                    break;
                case 2:
                    newAppointmentSource.DataSource = _appointments.Where(a => a.StartTime.Month == DateTime.Now.Month);
                    break;
                default:
                    newAppointmentSource.DataSource = _appointments;
                    break;
            }

            _appointmentsSource.DataSource = newAppointmentSource;
        }

        private static int GetWeekNumber(DateTime date)
        {
            return
                new CultureInfo(CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    .Calendar
                    .GetWeekOfYear(date, CalendarWeekRule.FirstFullWeek, DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek);
        }
    }
}
