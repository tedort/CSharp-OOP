using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Cat : Feline
    {
        private const double CatModifier = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Feed(Food.Food food)
        {
            if (food is not (Vegetable or Meat))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
            base.Feed(food);
            Weight += food.Quantity * CatModifier;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
