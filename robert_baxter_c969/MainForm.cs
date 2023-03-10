using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.DependencyInjection;
using System.Windows.Forms;

namespace robert_baxter_c969
{
    public partial class MainForm : Form
    {
        private readonly IDataRepository _dataRepository;
        private readonly IFormFactory _formFactory;
        private readonly ILogger<MainForm> _logger;

        public MainForm(IFormFactory formFactory, ILogger<MainForm> logger, IDataRepository dataRepository)
        {
            InitializeComponent();
            _formFactory = formFactory;
            _logger = logger;
            _dataRepository = dataRepository;
        }
    }
}
