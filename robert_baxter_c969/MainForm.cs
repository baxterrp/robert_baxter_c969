using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.Models;
using robert_baxter_c969.DependencyInjection;
using robert_baxter_c969.Forms;

namespace robert_baxter_c969
{
    public partial class MainForm : BaseForm<MainForm>
    {
        public User LoggedInUser { get; set; }

        public MainForm(
            IFormFactory formFactory,
            ILogger<MainForm> logger,
            IDataRepository dataRepository): base(logger, dataRepository, formFactory)
        {
            InitializeComponent();
        }
    }
}
