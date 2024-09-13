using System.Threading.Channels;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                people.Add(person);
            }
            Team team = new Team("SoftUni");

            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team);
        }
    }
}
