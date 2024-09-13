namespace CustomDI
{
    public interface IServiceCollection
    {
        void AddTransient<TInterface, TImplementation>();

        void AddTransient<TInterface, TImplementation>(Func<IServiceProvider, object> factory);

        void AddSingleton<TInterface, TImplementation>();

        void AddSingleton<TInterface, TImplementation>(Func<IServiceProvider, TImplementation> factory);

        IServiceProvider BuildServiceProvider();
    }
}
