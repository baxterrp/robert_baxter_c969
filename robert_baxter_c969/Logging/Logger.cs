using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace robert_baxter_c969.Logging
{
    public class Logger : ILogger
    {
        private StreamWriter _streamWriter;

        public Logger()
        {
            // create files based on the day they were used
            var date = DateTime.UtcNow.ToShortDateString().Replace("/", "-");
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Logging/Logs", $"{date}.txt");
            _streamWriter = new StreamWriter(filePath, true);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return _streamWriter;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // lets always log everything
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            // Format message for log 
            // Example: [Friday, March 10, 2023 : 1:50:29 AM UTC] this is working
            var dateSection = $"[{DateTime.UtcNow.ToLongDateString()} {DateTime.UtcNow.ToLongTimeString()} UTC]";
            var logMessage =$"{dateSection} {formatter(state, exception)}";
            
            _streamWriter.WriteLine(logMessage);
            _streamWriter.Flush();
        }
    }
}
