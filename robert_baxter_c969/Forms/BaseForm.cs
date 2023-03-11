using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace robert_baxter_c969.Forms
{
    /// <summary>
    /// Extra layer of inheritance to provide additional logic to forms
    /// Cannot be abstract because the editor wants to instantiate separately when editing derived forms
    /// </summary>
    /// <typeparam name="TForm">Derived type of <see cref="Form"/></typeparam>
    public class BaseForm<TForm> : Form, IDisposable where TForm : Form
    {
        protected readonly ILogger<TForm> _logger;
        protected readonly IDataRepository _dataRepository;
        protected readonly IFormFactory _formFactory;

        /// <summary>
        /// public parameterless constructor needed to be able to edit derived forms
        /// </summary>
        public BaseForm() { }

        /// <summary>
        /// Constructor called from derived forms
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/></param>
        /// <param name="dataRepository"><see cref="IDataRepository"/></param>
        /// <param name="formFactory"><see cref="IFormFactory"/></param>
        protected BaseForm(ILogger<TForm> logger, IDataRepository dataRepository, IFormFactory formFactory)
        {
            _logger = logger;
            _dataRepository = dataRepository;
            _formFactory = formFactory;
        }

        /// <summary>
        /// wrapper method for all async calls throughout application to handle exceptions and error messaging
        /// </summary>
        /// <param name="func">delegate function to be executed</param>
        /// <param name="successMessage">message on success if provided</param>
        /// <param name="errorMessage">message on error if provided</param>
        protected async Task ExecuteAsync(Func<Task<bool>> func, string successMessage, string errorMessage)
        {
            try
            {
                var isSuccess = await func();

                if (isSuccess && !string.IsNullOrWhiteSpace(successMessage))
                {
                    MessageBox.Show(successMessage);
                }
                else if(!isSuccess && !string.IsNullOrWhiteSpace(errorMessage))
                {
                    _logger.LogError("Request failed without exception: {message}", errorMessage);
                    MessageBox.Show(errorMessage);
                }
            }
            catch(Exception exception)
            {
                var exceptionMessage = string.IsNullOrWhiteSpace(errorMessage) ? exception.Message : errorMessage;
                _logger.LogError(exceptionMessage, exception);

                MessageBox.Show(exceptionMessage);
            }
        }
    }
}
