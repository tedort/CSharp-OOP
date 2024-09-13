namespace WildFarm.Models.Animal
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get => wingSize; protected set => wingSize = value; }

        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
