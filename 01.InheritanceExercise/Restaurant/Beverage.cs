namespace Restaurant
{
    public class Beverage : Product
    {
        private double milliliters;

        public Beverage(string name, int price, double milliliters) : base(name, price)
        {
            Milliliters = milliliters;
        }

        public double Milliliters
        {
            get => milliliters;
            set => milliliters = value;
        }
    }
}
