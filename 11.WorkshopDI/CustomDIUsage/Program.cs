using MicrosoftDependencyInjection.DI;
using System.Text;
using IServiceProvider = CustomDI.IServiceProvider;

namespace CustomDIUsage
{
    public class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = DIContainer.BuildServiceProvider();
            Engine engine = serviceProvider.GetService<Engine>();

            engine.Something();
        }
    }

    interface IRandomGenerator
    {
        public int GetRandom();
    }

    class SmallRandomGenerator : IRandomGenerator
    {
        public SmallRandomGenerator(DateTime dateToday)
        {
            Console.WriteLine("Small random generator created.");
        }

        public int GetRandom()
        {
            return new Random().Next(0, 10);
        }
    }
}
