namespace _01.SingleInheritance
{
    public class Student : Person
    {
        private string school;
        public Student(string name, int age, string school) : base(name, age)
        {
            School = school;
        }

        public string School
        {
            get => school;
            set => school = value;
        }

        public override void Sleep()
        {
            Console.WriteLine("Hr...");
        }
    }
}
