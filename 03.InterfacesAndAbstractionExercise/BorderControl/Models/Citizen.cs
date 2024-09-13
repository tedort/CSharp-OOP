using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : BaseEntity, IBuyer
    {
        public int Age { get; init; }
        public string Name { get; set; }
        public int Food { get; private set; }

        public Citizen(string id, int age, string name, string birthday)
        {
            Id = id;
            Age = age;
            Name = name;
            Birthday = birthday;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
