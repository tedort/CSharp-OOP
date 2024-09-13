namespace PizzaCalories
{
    public class Topping
    {
        private readonly string toppingType;
        private readonly double weight;

        public Topping(string toppingType, double weight)
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        public string ToppingType
        {
            init
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format(Utilities.ExceptionTopping, value));
                }
                toppingType = value;
            }
        }

        public double Weight
        {
            init
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(Utilities.ExceptionToppingWeight, toppingType));
                }
                weight = value;
            }
        }

        public double Calories
        {
            get => CalculateCalories();
        }

        private double CalculateCalories()
        {
            double toppingModifier = toppingType.ToLower() switch
            {
                "meat" => Utilities.MeatModifier,
                "veggies" => Utilities.VeggiesModifier,
                "cheese" => Utilities.CheeseModifier,
                "sauce" => Utilities.SauceModifier
            };
            return Utilities.BaseModifier * weight * toppingModifier;
        }
    }
}
