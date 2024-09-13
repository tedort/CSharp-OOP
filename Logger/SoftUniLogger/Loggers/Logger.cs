using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Loggers.Interfaces;
using SoftUniLogger.Models;

namespace SoftUniLogger.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> _appenders = new List<IAppender>();

        public Logger(IAppender appender)
        {
            _appenders.Add(appender);
        }

        public Logger(List<IAppender> appenders)
        {
            _appenders = appenders;
        }

        public void AddAppender(IAppender appender)
        {
            _appenders.Add(appender);
        }

        public void Critical(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Critical, logMessage));
        }

        public void Error(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Error, logMessage));
        }

        public void Fatal(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Fatal, logMessage));
        }

        public void Info(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Info, logMessage));
        }

        public void Warning(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Warning, logMessage));
        }

        private void Log(Message message)
        {
            foreach (IAppender appender in _appenders)
            {
                if (message.LogEntryLevel >= appender.LogLevel)
                {
                    appender.Append(message);
                }
            }
        }
    }
}
