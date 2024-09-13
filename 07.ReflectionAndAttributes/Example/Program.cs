using System.Reflection;

namespace Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in types)
            {
                Console.WriteLine(type.Name);
            }
        }
    }
}
