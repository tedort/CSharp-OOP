namespace _01.SingleInheritance
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age) 
        {
            Name = name;
            Age = age;
        }
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public virtual void Sleep()
        {
            Console.WriteLine("Hrrr...");
        }
    }
}
