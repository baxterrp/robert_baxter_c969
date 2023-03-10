using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace robert_baxter_c969.Logging
{
    public class Logger : ILogger
    {
        private StreamWriter _streamWriter;

        public Logger(string callerMember)
        {
            // a new log file will be created each day it is used
            var date = DateTime.UtcNow.ToShortDateString().Replace("/", "-");

            // all logs will be output to the Logging/Logs folder but will not be added to the solution
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Logging/Logs", $"{date}-{callerMember}.txt");
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
