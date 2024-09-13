using DependencyInversionAdvanced;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace MicrosoftDependencyInjection.DI
{
    public class DIContainer
    {
        public static IServiceProvider BuildServiceProvider()
        {
            ServiceCollection collection = new ServiceCollection();

            collection.AddTransient<IRandomGenerator, SmallRandomGenerator>();
            collection.AddTransient(typeof(DateTime), (IServiceProvider sp) =>
            {
                return DateTime.Now;
            });

            collection.AddTransient<StringBuilder>((sp) =>
            {
                var sb = new StringBuilder();
                sb.AppendLine("WOW!");

                return sb;
            });

            //collection.AddScoped<IRandomGenerator, SmallRandomGenerator>();
            //collection.AddSingleton<IRandomGenerator, SmallRandomGenerator>();

            return collection.BuildServiceProvider();
        }
    }
}
