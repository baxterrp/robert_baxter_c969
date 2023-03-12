using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.Models;
using robert_baxter_c969.Data.ViewModels;
using robert_baxter_c969.DependencyInjection;
using robert_baxter_c969.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace robert_baxter_c969
{
    public partial class MainForm : BaseForm<MainForm>
    {
        public User LoggedInUser { get; set; }
        private BindingSource _customersSource;
        private IEnumerable<CustomerViewModel> _customers;

        public MainForm(
            IFormFactory formFactory,
            ILogger<MainForm> logger,
            IDataRepository dataRepository): base(logger, dataRepository, formFactory)
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private async void LoadCustomers(object sender, System.EventArgs e)
        {
            _customers = await _dataRepository.ExecuteCustomQuery<CustomerViewModel>(Constants.GetAllCustomers, null);
            _customersSource = new BindingSource { DataSource = _customers };
            CustomerDisplay.DataSource = _customersSource;
        }
    }
}
