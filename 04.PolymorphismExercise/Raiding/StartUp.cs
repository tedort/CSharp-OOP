using Raiding.Models;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> list = new List<BaseHero>();

            int heroCount = int.Parse(Console.ReadLine());

            HeroFactory heroFactory = new HeroFactory();

            while (list.Count < heroCount)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    list.Add(heroFactory.CreateHero(heroType, heroName));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            int result = list.Sum(h => h.Power);
            int bossPower = int.Parse(Console.ReadLine());

            foreach (BaseHero hero in list)
            {
                Console.WriteLine(hero.CastAbility());
            }

            Console.WriteLine(result >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
