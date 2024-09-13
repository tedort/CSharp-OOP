namespace FluentInterface
{
    public class Program
    {
        static void Main(string[] args)
        {
            new Fluent().DoNothing().DoSomething().DoNothing();
        }
    }
}
