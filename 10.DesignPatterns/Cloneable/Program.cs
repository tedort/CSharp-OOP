using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Cloneable
{
    class Course
    {
        public string Name { get; set; }
    }


    class User : ICloneable
    {
        public string Username { get; set; }

        public Course Course { get; set; }

        public object Clone()
        {
            // shallow copy
            // return this.MemberwiseClone();

            // deep copy
            return JsonConvert.DeserializeObject<User>((JsonConvert.SerializeObject(this)));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course { Name = "C# OOP" };

            User user = new User() { Username = "Pesho", Course = course};

            User user2 = (User)user.Clone();

            user2.Username = "gosho";
            user2.Course.Name = "Java";

            Console.WriteLine(user.Username);
            Console.WriteLine(user2.Username);

            Console.WriteLine(user.Course.Name);
            Console.WriteLine(user2.Course.Name);
        }
    }
}
