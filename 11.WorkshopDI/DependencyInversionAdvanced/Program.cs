using Microsoft.Extensions.DependencyInjection;
using MicrosoftDependencyInjection.DI;
using System.Text;

namespace DependencyInversionAdvanced
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = DIContainer.BuildServiceProvider();

            var random = serviceProvider.GetService<IRandomGenerator>();
            random = serviceProvider.GetService<IRandomGenerator>();
            random = serviceProvider.GetService<IRandomGenerator>();
            random = serviceProvider.GetService<IRandomGenerator>();
            random = serviceProvider.GetService<IRandomGenerator>();
            random = serviceProvider.GetService<IRandomGenerator>();
        }
    }

    interface IRandomGenerator
    {
        public int GetRandom();
    }

    class SmallRandomGenerator : IRandomGenerator
    {
        public SmallRandomGenerator(DateTime dateToday, StringBuilder sb)
        {
            Console.WriteLine("Small random generator created.");

            Console.WriteLine(sb);
        }

        public int GetRandom()
        {
            return new Random().Next(0, 10);
        }
    }
}
