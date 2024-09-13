namespace WildFarm.Models.Animal
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get => name; protected set => name = value; }
        public double Weight { get => weight; protected set => weight = value; }
        public int FoodEaten { get => foodEaten; protected set => foodEaten = value; }

        public abstract string ProduceSound();

        public virtual void Feed(Food.Food food)
        {
            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
