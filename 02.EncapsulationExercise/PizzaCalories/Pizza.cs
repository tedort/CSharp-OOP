namespace PizzaCalories
{
    public class Pizza
    {
        private readonly string name;
        private Dough pizzaDough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            private get => name;
            init
            {
                if (value.Length < 1 || value.Length > 15 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.ExceptionPizzaName);
                }
                name = value;
            }
        }

        public Dough PizzaDough
        {
            set
            {
                pizzaDough = value;
            }
        }

        public void AddToppings(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException(Utilities.ExceptionToppingCount);
            }
            toppings.Add(topping);
        }

        public double TotalCalories
        {
            get => CalculateCalories();
        }

        public double CalculateCalories()
        {
            double result = 0.0;
            foreach (Topping topping in toppings)
            {
                result += topping.Calories;
            }
            result += pizzaDough.Calories;
            return result;
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
