namespace Restaurant
{
    public class Fish : MainDish
    {
        public Fish(string name, int price) : base(name, price)
        {
            Grams = 22;
        }
    }
}
