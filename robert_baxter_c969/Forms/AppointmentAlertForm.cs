using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.DependencyInjection;
using System;

namespace robert_baxter_c969.Forms
{
    public partial class AppointmentAlertForm : BaseForm<AppointmentAlertForm>
    {
        public AppointmentAlertForm(
        IFormFactory formFactory,
        ILogger<AppointmentAlertForm> logger,
            IDataRepository dataRepository) : base(logger, dataRepository, formFactory)
        {
            InitializeComponent();
        }

        private void CloseAlertButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewAppointmentsAlertButton_Click(object sender, EventArgs e)
        {
            _formFactory.CreateForm<ViewAppointmentsForm>().Show();
            Close();
        }
    }
}
