using System.Reflection;

namespace Fields
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);

            FieldInfo field = type.GetField("age");
            Console.WriteLine(field.Name);
            Console.WriteLine(field.IsPublic);
        }
    }
}
