
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Owl : Bird
    {
        private const double OwlModifier = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food.Food food)
        {
            if (food is not Meat)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            base.Feed(food);
            Weight += food.Quantity * OwlModifier;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
