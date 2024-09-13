namespace FootballTeamGenerator
{
    public class StartUp
    {
        private static Dictionary<string, Team> teams = new Dictionary<string, Team>();
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    ProcessCommand(command);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ProcessCommand(string command)
        {
            string[] parts = command.Split(';');
            string action = parts[0];

            switch (action)
            {
                case "Team":
                    AddTeam(parts[1]);
                    break;
                case "Add":
                    AddPlayerToTeam(parts);
                    break;
                case "Remove":
                    RemovePlayerFromTeam(parts);
                    break;
                case "Rating":
                    ShowTeamRating(parts[1]);
                    break;
            }
        }

        private static void AddTeam(string teamName)
        {
            if (!teams.ContainsKey(teamName))
            {
                teams[teamName] = new Team(teamName);
            }
        }

        private static void AddPlayerToTeam(string[] parts)
        {
            string teamName = parts[1];
            if (!teams.ContainsKey(teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist.");
                return;
            }

            string playerName = parts[2];
            int endurance = int.Parse(parts[3]);
            int sprint = int.Parse(parts[4]);
            int dribble = int.Parse(parts[5]);
            int passing = int.Parse(parts[6]);
            int shooting = int.Parse(parts[7]);

            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            teams[teamName].AddPlayer(player);
        }

        private static void RemovePlayerFromTeam(string[] parts)
        {
            string teamName = parts[1];
            if (!teams.ContainsKey(teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist");
                return;
            }

            string playerName = parts[2];
            teams[teamName].RemovePlayer(playerName);
        }

        private static void ShowTeamRating(string teamName)
        {
            if (!teams.ContainsKey(teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist.");
                return;
            }

            Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
        }
    }
}
