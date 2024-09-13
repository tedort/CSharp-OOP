namespace Restaurant
{
    public class Dessert : Food
    {
        private double calories;

        public Dessert(string name) : base(name)
        {

        }

        public Dessert(string name, int price) : base(name, price)
        {
            
        }

        public double Calories
        {
            get => calories;
            set => calories = value;
        }
    }
}
