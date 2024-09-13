namespace WildFarm.Models.Food
{
    public abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get => quantity; protected set => quantity = value; }
    }
}
