using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.DependencyInjection;
using robert_baxter_c969.Logging;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace robert_baxter_c969
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            services.AddSingleton<IDataRepository>(
                new DataRepository(ConfigurationManager.ConnectionStrings["c969-db-connection"].ConnectionString));
            services.AddSingleton<IFormFactory, FormFactory>();
            services.AddTransient<MainForm>();
            services.AddSingleton<Logger>();

            services.AddLogging();

            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetRequiredService<ILoggerFactory>().AddProvider(new LoggerProvider());
            
            var mainForm = serviceProvider.GetRequiredService<MainForm>();

            Application.Run(mainForm);
        }
    }
}
