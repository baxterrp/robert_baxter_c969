using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using robert_baxter_c969.Configuration;
using robert_baxter_c969.Data;
using robert_baxter_c969.DependencyInjection;
using robert_baxter_c969.Forms;
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
            var connectionString = ConfigurationManager.ConnectionStrings["c969-db-connection"].ConnectionString;
            var dbConfig = new DbConfiguration
            {
                ConnectionString = connectionString,
            };

            services.AddSingleton(dbConfig);
            services.AddSingleton<IDataRepository, DataRepository>();

            // use factory to provide all forms
            services.AddSingleton<IFormFactory, FormFactory>();

            // load all of the forms here
            services.AddSingleton<Login>();
            services.AddSingleton<MainForm>();
            
            // configure custom logger to output to text files
            services.AddTransient<Logger>();
            services.AddLogging();

            var serviceProvider = services.BuildServiceProvider();

            // add custom logger provider
            serviceProvider.GetRequiredService<ILoggerFactory>().AddProvider(new LoggerProvider());
            
            // load the login form and run
            Application.Run(serviceProvider.GetRequiredService<Login>());
        }
    }
}
