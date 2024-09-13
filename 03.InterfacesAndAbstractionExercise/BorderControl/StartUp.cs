using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    Rebel rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    buyers.Add(rebel);
                }
                else if (tokens.Length == 4)
                {
                    Citizen citizen = new Citizen(tokens[2], int.Parse(tokens[1]), tokens[0], tokens[3]);
                    buyers.Add(citizen);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.Find(b => b.Name == input);
                if (buyer == null)
                {
                    continue;
                }
                buyer.BuyFood();
            }

            int result = buyers.Sum(b => b.Food);
            Console.WriteLine(result);
        }
    }
}
