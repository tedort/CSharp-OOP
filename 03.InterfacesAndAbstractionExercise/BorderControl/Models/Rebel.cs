using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Rebel : BaseEntity, IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; private set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
