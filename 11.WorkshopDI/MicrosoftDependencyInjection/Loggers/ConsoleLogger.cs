namespace MicrosoftDependencyInjection.Loggers
{
    public class ConsoleLogger : ILogger
    {
        private DateTime dateToday;

        public ConsoleLogger(DateTime dateToday)
        {
            this.dateToday = dateToday;
        }

        public void Log(string message)
        {
            Console.WriteLine($"{dateToday}:{message}");
        }
    }
}
