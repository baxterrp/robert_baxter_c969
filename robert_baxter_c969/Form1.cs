using robert_baxter_c969.Data;
using System.Windows.Forms;

namespace robert_baxter_c969
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var reader = new DataRepository();
        }
    }
}
