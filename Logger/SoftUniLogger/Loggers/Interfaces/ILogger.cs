using SoftUniLogger.Appenders.Interfaces;

namespace SoftUniLogger.Loggers.Interfaces
{
    public interface ILogger
    {
        void Info(DateTime dateTime, string logMessage);
        void Warning(DateTime dateTime, string logMessage);
        void Error(DateTime dateTime, string logMessage);
        void Critical(DateTime dateTime, string logMessage);
        void Fatal(DateTime dateTime, string logMessage);
        public void AddAppender(IAppender appender);
    }
}
