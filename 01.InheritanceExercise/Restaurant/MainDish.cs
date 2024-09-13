namespace Restaurant
{
    public class MainDish : Food
    {
        public MainDish(string name, int price) : base(name, price)
        {
        }

        public MainDish(string name, int price, double grams) : this(name, price)
        {

        }
    }
}
