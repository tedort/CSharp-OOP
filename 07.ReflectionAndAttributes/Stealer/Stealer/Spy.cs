using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type type = Type.GetType(investigatedClass);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            Object instance = Activator.CreateInstance(type);

            sb.AppendLine($"Class under investigation: {type.Name}");

            foreach (FieldInfo field in fields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields();
            MethodInfo[] publicMethods = type.GetMethods();
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo publicMethod in privateMethods.Where(p => p.Name.Contains("get")))
            {
                Console.WriteLine($"{publicMethod.Name} must be public!");
            }

            foreach (MethodInfo publicMethod in publicMethods.Where(p => p.Name.Contains("set")))
            {
                Console.WriteLine($"{publicMethod.Name} must be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string investigatedClass)
        {
            Type type = Type.GetType(investigatedClass);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {type.Name}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string investigatedClass)
        {
            Type type = Type.GetType(investigatedClass);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo method in methods.Where(m => m.Name.Contains("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(m => m.Name.Contains("set")))
            {
                ParameterInfo[] parameters = method.GetParameters();
                foreach (ParameterInfo parameter in parameters)
                {
                    sb.AppendLine($"{method.Name} will set field of {parameter.ParameterType}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
