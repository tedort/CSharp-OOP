namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private double coffeeMilliliters;
        private decimal coffeePrice;
        private double caffeine;

        public Coffee(string name, int price, double milliliters, double caffeine) : base(name, price, milliliters)
        {
            Caffeine = caffeine;
        }

        private double CoffeeMilliliters
        {
            get => coffeeMilliliters;
            set => coffeeMilliliters = 50;
        }

        private decimal CoffeePrice
        {
            get => coffeePrice;
            set => coffeePrice = 3.50m;
        }

        private double Caffeine
        {
            get => caffeine;
            set => caffeine = value;
        }
    }
}
