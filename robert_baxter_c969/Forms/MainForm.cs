﻿using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.DataModels;
using robert_baxter_c969.Data.Models;
using robert_baxter_c969.Data.ViewModels;
using robert_baxter_c969.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace robert_baxter_c969.Forms
{
    public partial class MainForm : BaseForm<MainForm>
    {
        public User LoggedInUser { get; set; }
        private BindingSource _customersSource;
        private IEnumerable<CustomerViewModel> _customers;

        private static bool FirstLoad = true;

        public MainForm(
            IFormFactory formFactory,
            ILogger<MainForm> logger,
            IDataRepository dataRepository) : base(logger, dataRepository, formFactory)
        {
            InitializeComponent();
        }

        private async void LoadCustomers(object sender, System.EventArgs e)
        {
            // load customer table
            await ExecuteAsync(async () =>
            {
                _logger.LogInformation("Looking up all customers");

                _customers = await _dataRepository.ExecuteCustomQuery<CustomerViewModel>(Constants.GetAllCustomers, null);
                _customersSource = new BindingSource { DataSource = _customers };
                CustomerDisplay.DataSource = _customersSource;

                return true;
            }, string.Empty, "Failed to load customer data");

            // check upcoming appointments
            if (FirstLoad)
            {
                FirstLoad = false;

                var showAppointmentAlert = false;
                await ExecuteAsync(async () =>
                {
                    showAppointmentAlert = (await _dataRepository.ExecuteScalar(Constants.CheckUpcomingAppointments, null) > 0);
                    return true;
                }, string.Empty, "Failed to check upcoming appointments");

                if (showAppointmentAlert)
                {
                    _formFactory.CreateForm<AppointmentAlertForm>().Show();
                }
            }
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void AddUserButton_Click(object sender, System.EventArgs e)
        {
            var addUserForm = _formFactory.CreateForm<CustomerForm>();
            addUserForm.Text = "Add User";
            addUserForm.Show();
        }

        private async void ModifyUserButton_Click(object sender, System.EventArgs e)
        {
            var modifyUserForm = _formFactory.CreateForm<CustomerForm>();
            modifyUserForm.SelectedCustomer = _customers.ElementAt(CustomerDisplay.CurrentCell.RowIndex);
            modifyUserForm.Text = "Modify User";
            modifyUserForm.Show();
        }

        private void ViewAppointmentsButton_Click(object sender, System.EventArgs e)
        {
            var viewAppointmentsForm = _formFactory.CreateForm<ViewAppointmentsForm>();
            viewAppointmentsForm.Show();
        }

        private async void DeleteButton_Click(object sender, System.EventArgs e)
        {
            var customerId = _customers.ElementAt(CustomerDisplay.CurrentCell.RowIndex).Id;
            var confirmation = 
                MessageBox.Show("Are you sure you want to delete this customer and all of their appointments?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (DialogResult.Yes.Equals(confirmation))
            {
                await ExecuteAsync(async () =>
                {
                    var customer = await _dataRepository.GetById<Customer>(customerId);
                    var appointments = await _dataRepository.Get<Appointment>(new Dictionary<string, string>
                    {
                        { nameof(Appointment.CustomerId), customer.Id.ToString() }
                    });

                    foreach(var appointment in appointments)
                    {
                        await _dataRepository.Delete(appointment);
                    }

                    await _dataRepository.Delete(customer);

                    return true;

                }, "Successfully deleted customer", "Failed to delete customer");
            }
        }
    }
}
