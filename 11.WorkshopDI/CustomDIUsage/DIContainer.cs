using CustomDI;
using CustomDIUsage;
using IServiceProvider = CustomDI.IServiceProvider;

namespace MicrosoftDependencyInjection.DI
{
    public class DIContainer
    {
        public static IServiceProvider BuildServiceProvider()
        {
            IServiceCollection collection = new ServiceCollection();

            collection.AddTransient<IRandomGenerator, SmallRandomGenerator>();
            collection.AddTransient<Engine, Engine>();

            collection.AddTransient<DateTime, DateTime>((sp) =>
            {
                return DateTime.Now;
            });

            return collection.BuildServiceProvider();
        }
    }
}
