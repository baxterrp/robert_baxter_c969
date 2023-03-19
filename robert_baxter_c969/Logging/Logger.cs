using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.IO;

namespace robert_baxter_c969.Logging
{
    public class Logger : ILogger
    {
        private StreamWriter _streamWriter;

        public Logger(string callerMember)
        {
            // a new log file will be created each day it is used
            var date = DateTime.Now.ToShortDateString().Replace("/", "-");

            // all logs will be output to the bin/debug folder
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{date}-{callerMember}.txt");
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
            // Using local time since all logs are stored locally
            // Example: [Information][Friday, March 10, 2023 : 1:50:29 AM en-US] this is working
            var additionalInformation = $"[{logLevel}][{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()} {CultureInfo.CurrentCulture.Name}]";
            var logMessage = $"{additionalInformation} {formatter(state, exception)}";

            _streamWriter.WriteLine(logMessage);
            _streamWriter.Flush();
        }
    }
}
