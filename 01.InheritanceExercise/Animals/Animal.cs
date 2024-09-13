using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal()
        {

        }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Animal(string name, int age, string gender) : this(name, age)
        {
            Gender = gender;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        public virtual void ProduceSound()
        {

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{GetType().Name}");
            stringBuilder.AppendLine($"{Name} {Age} {Gender}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
