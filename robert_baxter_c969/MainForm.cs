using Microsoft.Extensions.Logging;
using robert_baxter_c969.DependencyInjection;
using System.Windows.Forms;

namespace robert_baxter_c969
{
    public partial class MainForm : Form
    {
        private readonly IFormFactory _formFactory;
        private readonly ILogger<MainForm> _logger;

        public MainForm(IFormFactory formFactory, ILogger<MainForm> logger)
        {
            InitializeComponent();
            _formFactory = formFactory;
            _logger = logger;

            _logger.LogError("this is working");
        }
    }
}
