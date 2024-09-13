namespace Restaurant
{
    public class Food : Product
    {
        private double grams;

        public Food(string name) : base(name)
        {

        }

        public Food(string name, int price) : base(name, price)
        {
            
        }

        public Food(string name, int price, double grams) : this(name, price)
        {
            Grams = grams;
        }

        public double Grams
        {
            get => grams;
            set => grams = value;
        }
    }
}
