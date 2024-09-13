
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Hen : Bird
    {
        private const double HenModifier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food.Food food)
        {
            base.Feed(food);
            Weight += food.Quantity * HenModifier;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
