using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.DependencyInjection;
using System;

namespace robert_baxter_c969.Forms
{
    public partial class ViewAppointmentsForm : BaseForm<ViewAppointmentsForm>
    {
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
    }
}
