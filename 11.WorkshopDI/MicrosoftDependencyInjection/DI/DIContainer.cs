using CustomDI;
using MicrosoftDependencyInjection.Loggers;
using IServiceProvider = CustomDI.IServiceProvider;

namespace MicrosoftDependencyInjection.DI
{
    public class DIContainer
    {
        public static IServiceProvider BuildServiceProvider()
        {
            ServiceCollection collection = new ServiceCollection();

            collection.AddTransient<IRandomGenerator, SmallRandomGenerator>();
            collection.AddTransient<ILogger, PurpleConsoleLogger>();
            collection.AddTransient<Engine, Engine>();
            collection.AddTransient<DateTime, DateTime>(sp =>
            {
                return DateTime.Now;
            });

            return collection.BuildServiceProvider();
        }
    }
}
