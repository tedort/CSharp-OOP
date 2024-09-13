using System.ComponentModel;
using Attributes;
using System.Reflection;

namespace Attributes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttribute<DocumentationAttribute>() != null).ToArray();

            foreach (Type type in types)
            {
                DocumentationAttribute attr = type.GetCustomAttribute<DocumentationAttribute>();

                Console.WriteLine(attr.MoreInfo);

                MethodInfo[] methods = type.GetMethods();
                foreach (var method in methods)
                {
                    DocumentationAttribute methodAttr = method.GetCustomAttribute<DocumentationAttribute>();

                    if (methodAttr != null)
                    {
                        Console.WriteLine($"{method.ReturnType.Name} - {method.Name} - {methodAttr.MoreInfo}");
                    }
                }
            }

        }
    }

    [Obsolete]
    class Student
    {
        public void Graduate()
        {

        }
    }
}
