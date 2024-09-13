
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Dog : Mammal
    {
        private const double DogModifier = 0.4;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Feed(Food.Food food)
        {
            if (food is not Meat)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            base.Feed(food);
            Weight += food.Quantity * DogModifier;
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
