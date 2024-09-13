using WildFarm.Models.Animal;
using WildFarm.Models.Food;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<Animal> animals = new List<Animal>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Animal animal = null;
                switch (animalTokens[0])
                {
                    case "Owl":
                        animal = new Owl(animalTokens[1], double.Parse(animalTokens[2]), double.Parse(animalTokens[3]));
                        break;
                    case "Hen":
                        animal = new Hen(animalTokens[1], double.Parse(animalTokens[2]), double.Parse(animalTokens[3]));
                        break;
                    case "Mouse":
                        animal = new Mouse(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3]);
                        break;
                    case "Dog":
                        animal = new Dog(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3]);
                        break;
                    case "Cat":
                        animal = new Cat(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3], animalTokens[4]);
                        break;
                    case "Tiger":
                        animal = new Tiger(animalTokens[1], double.Parse(animalTokens[2]), animalTokens[3], animalTokens[4]);
                        break;
                }
                animals.Add(animal);

                string[] foodTokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Food food = null;
                switch (foodTokens[0])
                {
                    case "Vegetable":
                        food = new Vegetable(int.Parse(foodTokens[1]));
                        break;
                    case "Fruit":
                        food = new Fruit(int.Parse(foodTokens[1]));
                        break;
                    case "Meat":
                        food = new Meat(int.Parse(foodTokens[1]));
                        break;
                    case "Seeds":
                        food = new Seeds(int.Parse(foodTokens[1]));
                        break;
                }
                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Feed(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
