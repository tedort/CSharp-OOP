namespace CustomDI
{
    public interface IServiceProvider
    {
        T GetService<T>();
    }
}
