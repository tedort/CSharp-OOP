namespace SimpleSnake.GameObjects.Foods
{
    public class Asterisk : Food
    {
        private const char FoodSymbol = '*';
        private const int points = 1;

        public Asterisk(Wall wall) 
            : base(wall, FoodSymbol, points)
        {
        }
    }
}
