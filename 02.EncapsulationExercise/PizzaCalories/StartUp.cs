namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] doughData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Pizza pizza = new Pizza(pizzaData[1]);
                Dough dough = new Dough(doughData[1], doughData[2], double.Parse(doughData[3]));
                pizza.PizzaDough = dough;
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] toppingData = command
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Topping topping = new Topping(toppingData[1], double.Parse(toppingData[2]));
                    pizza.AddToppings(topping);
                    command = Console.ReadLine();
                }
                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
