using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.DependencyInjection;

namespace robert_baxter_c969.Forms
{
    public partial class UserForm : BaseForm<UserForm>
    {
        public UserForm(
        IFormFactory formFactory,
        ILogger<UserForm> logger,
            IDataRepository dataRepository): base(logger, dataRepository, formFactory)
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
