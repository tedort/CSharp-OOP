namespace TypeClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Type);

            Console.WriteLine(type.Name);
            Console.WriteLine(type.FullName);
            Console.WriteLine(type.Assembly);
            Console.WriteLine(type.IsClass);
            Console.WriteLine(type.IsGenericType);
            Console.WriteLine(type.IsArray);
            Console.WriteLine(type.IsAbstract);
        }
    }
}
