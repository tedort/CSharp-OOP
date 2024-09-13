namespace MicrosoftDependencyInjection.Loggers
{
    public class PurpleConsoleLogger : ILogger
    {
        private DateTime dateToday;

        public PurpleConsoleLogger(DateTime dateToday)
        {
            this.dateToday = dateToday;
            Log("Logger has been created");
        }

        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{dateToday}:{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
