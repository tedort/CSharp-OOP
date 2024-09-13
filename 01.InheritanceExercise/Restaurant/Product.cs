namespace Restaurant
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name)
        {
            Name = name;
        }

        public Product(string name, int price) : this(name)
        {
            Price = price;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public decimal Price
        {
            get => price;
            set => price = value;
        }
    }
}
