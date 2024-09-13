
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Mouse : Mammal
    {
        public const double MouseModifier = 0.1;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Feed(Food.Food food)
        {
            if (food is not (Vegetable or Fruit))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            base.Feed(food);
            Weight += food.Quantity * MouseModifier;
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
