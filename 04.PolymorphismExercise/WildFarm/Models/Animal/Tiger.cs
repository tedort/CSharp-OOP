
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Tiger : Feline
    {
        private const double TigerModifier = 1;

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Feed(Food.Food food)
        {
            if (food is not Meat)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            base.Feed(food);
            Weight += food.Quantity * TigerModifier;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
