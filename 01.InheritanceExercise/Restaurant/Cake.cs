namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name)
        {
            Grams = 250;
            Calories = 1000;
            Price = 5;
        }
    }
}
