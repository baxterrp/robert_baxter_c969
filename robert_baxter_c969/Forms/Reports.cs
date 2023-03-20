using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.DataModels;
using robert_baxter_c969.Data.Models;
using robert_baxter_c969.Data.ViewModels;
using robert_baxter_c969.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace robert_baxter_c969.Forms
{
    public partial class Reports : BaseForm<Reports>
    {
        private IEnumerable<Appointment> _appointments;
        private IEnumerable<User> _users;
        private IEnumerable<Country> _countries;
        private IEnumerable<CustomerViewModel> _customers;

        public Reports(
            IFormFactory formFactory,
            ILogger<Reports> logger,
            IDataRepository dataRepository) : base(logger, dataRepository, formFactory)
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void LoadReportsData(object sender, EventArgs e)
        {
            AppointmentMonthSelectList.DataSource = DateTimeFormatInfo.CurrentInfo.MonthNames;

            await ExecuteAsync(async () =>
            {
                // several queries being kicked off here, doing them in parallel since none of them are dependent on eachother
                var appointmentResponse = _dataRepository.Get<Appointment>(null);
                var userResponse = _dataRepository.Get<User>(null);
                var countrySelect = _dataRepository.Get<Country>(null);
                var customerResponse = _dataRepository.ExecuteCustomQuery<CustomerViewModel>(Constants.GetAllCustomers, null);

                await Task.WhenAll(appointmentResponse, userResponse, countrySelect, customerResponse);

                _appointments = appointmentResponse.Result;
                _users = userResponse.Result;
                _countries = countrySelect.Result;
                _customers = customerResponse.Result;

                ConsultantSelectList.DataSource = _users;
                CountrySelectList.DataSource = _countries.GroupBy(country => country.Name).Select(group => group.Key).ToList();

                return true;
            }, string.Empty, "Failed to load reports page");
        }

        private void ExecuteAppByMonth_Click(object sender, EventArgs e)
        {
            var selectedMonth = AppointmentMonthSelectList.SelectedIndex + 1;

            _logger.LogInformation("Generating Appointments by month report for the month of {month}", DateTimeFormatInfo.CurrentInfo.MonthNames[selectedMonth]);

            var filteredAppointments = _appointments
                .Where(appointment => appointment.Start.Month == selectedMonth)
                .GroupBy(appointment => appointment.Type)
                .Select(grouping => new
                {
                    Type = grouping.Key,
                    Count = grouping.Count().ToString()
                }).ToList();

            if (!filteredAppointments.Any())
            {
                filteredAppointments.Add(new
                {
                    Type = string.Empty,
                    Count = string.Empty,
                });
            }

            AppByMonthData.DataSource = filteredAppointments;
        }

        private async void ExecuteConsultantScheduleReport_Click(object sender, EventArgs e)
        {
            var userId = ConsultantSelectList.SelectedValue.ToString();

            _logger.LogInformation("Generating consultant schedule report for user {userId}", userId);

            await ExecuteAsync(async () =>
            {
                var appointments = await _dataRepository.ExecuteCustomQuery<AppointmentViewModel>(Constants.GetAppointmentsByUserId, new Dictionary<string, object>
                {
                    { "UserId", userId },
                });

                ConsultScheduleGrid.DataSource = appointments.Select(appointment => new
                {
                    appointment.Customer,
                    appointment.Title,
                    appointment.Location,
                    appointment.Type,
                    Start = appointment.StartTime,
                    End = appointment.EndTime,
                }).ToList();

                return true;
            }, string.Empty, "Failed to load consultant schedule");
        }

        private void ExecuteCustomerByCountry_Click(object sender, EventArgs e)
        {
            var countryName = CountrySelectList.SelectedValue.ToString();

            _logger.LogInformation("Generating customers by country report for country {country}", countryName);

            CustomerByCountryGrid.DataSource = _customers.Where(customer => customer.Country == countryName).ToList();
        }
    }
}
