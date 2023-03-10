using Microsoft.Extensions.DependencyInjection;
using System;

namespace robert_baxter_c969.DependencyInjection
{
    public class FormFactory : IFormFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TForm CreateForm<TForm>()
        {
            return _serviceProvider.GetRequiredService<TForm>();
        }
    }
}
