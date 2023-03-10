using Microsoft.Extensions.Logging;

namespace robert_baxter_c969.Logging
{
    public class LoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new Logger();
        }

        public void Dispose()
        {
            // nothing to dispose
        }
    }
}
