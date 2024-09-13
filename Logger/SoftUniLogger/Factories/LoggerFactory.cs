using SoftUniLogger.Appenders;
using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Layouts;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Loggers;
using SoftUniLogger.Loggers.Interfaces;

namespace SoftUniLogger.Factories
{
    public class LoggerFactory
    {
        public ILogger CreateLogger(string type)
        {
            ILayout layout;
            IAppender appender;

            layout = new SimpleLayout();

            appender = type switch
            {
                "console" => appender = new ConsoleAppender(layout),
                "file" => appender = new FileAppender(layout),
                _ => throw new ArgumentException("Invalid appender type!")
            };

            return new Logger(appender);
        }
    }
}
