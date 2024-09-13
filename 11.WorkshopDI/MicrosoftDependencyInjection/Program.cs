using MicrosoftDependencyInjection.DI;
using MicrosoftDependencyInjection.Loggers;
using IServiceProvider = CustomDI.IServiceProvider;

namespace MicrosoftDependencyInjection
{
    public class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = DIContainer.BuildServiceProvider();

            Engine engine = serviceProvider.GetService<Engine>();

            engine.Print();
        }
    }
    interface IRandomGenerator
    {
        public int GetRandom();
    }

    class SmallRandomGenerator : IRandomGenerator
    {
        private ILogger logger;
        public SmallRandomGenerator(ILogger logger)
        {
            this.logger = logger;
            Console.WriteLine("Small random generator created.");
        }

        public int GetRandom()
        {
            logger.Log("Generating a random number");
            return new Random().Next(0, 10);
        }
    }

}
