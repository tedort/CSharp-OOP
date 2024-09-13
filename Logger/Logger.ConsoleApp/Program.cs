using System.Globalization;
using SoftUniLogger.Appenders;
using SoftUniLogger.Appenders.Interfaces;
using SoftUniLogger.Factories;
using SoftUniLogger.Layouts;
using SoftUniLogger.Layouts.Interfaces;
using SoftUniLogger.Loggers.Interfaces;
using SoftUniLogger.Models;

namespace Logger.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //InitializeWithoutPatterns();
            //ILogger consoleLogger = InitializeWithFactory();

            int numberOfAppenders = int.Parse(Console.ReadLine());
            List<IAppender> appenders = new List<IAppender>();
            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appenderData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ILayout layout = new SimpleLayout();
                switch (appenderData[1])
                {
                    case "SimpleLayout":
                        layout = new SimpleLayout();
                        break;
                    case "XmlLayout":
                        layout = new XmlLayout();
                        break;
                    default:
                        Console.WriteLine("Invalid layout!");
                        break;
                }

                IAppender appender = new ConsoleAppender(layout);
                switch (appenderData[0])
                {
                    case "ConsoleAppender":
                        appender = new ConsoleAppender(layout);
                        break;
                    case "FileAppender":
                        appender = new FileAppender(layout);
                        break;
                }

                if (appenderData.Length == 3)
                {
                    switch (appenderData[2])
                    {

                        case "INFO":
                            appender.LogLevel = SoftUniLogger.Models.LogEntryLevel.Info;
                            break;
                        case "WARNING":
                            appender.LogLevel = SoftUniLogger.Models.LogEntryLevel.Warning;
                            break;
                        case "ERROR":
                            appender.LogLevel = SoftUniLogger.Models.LogEntryLevel.Error;
                            break;
                        case "CRITICAL":
                            appender.LogLevel = SoftUniLogger.Models.LogEntryLevel.Critical;
                            break;
                        case "FATAL":
                            appender.LogLevel = SoftUniLogger.Models.LogEntryLevel.Fatal;
                            break;
                    }
                }

                appenders.Add(appender);
            }

            ILogger logger = new SoftUniLogger.Loggers.Logger(appenders);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                switch (data[0])
                {
                    case "INFO":
                        logger.Info(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "WARNING":
                        logger.Warning(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "ERROR":
                        logger.Error(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "CRITICAL":
                        logger.Critical(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "FATAL":
                        logger.Fatal(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                }
            }
        }

        private static ILogger InitializeWithFactory()
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            ILogger consoleLogger = loggerFactory.CreateLogger("console");
            ILogger xmlLogger = loggerFactory.CreateLogger("file");
            return consoleLogger;
        }

        private static void InitializeWithoutPatterns()
        {
            ILayout simpleLayout = new SimpleLayout();
            ILayout xmlLayout = new XmlLayout();

            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            IAppender fileAppender = new FileAppender(xmlLayout);

            consoleAppender.LogLevel = SoftUniLogger.Models.LogEntryLevel.Error;

            ILogger logger = new SoftUniLogger.Loggers.Logger(fileAppender);
            logger.AddAppender(consoleAppender);
        }
    }
}
