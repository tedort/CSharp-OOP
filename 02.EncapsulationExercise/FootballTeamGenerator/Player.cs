namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            init
            {
                ValidateStat(value, nameof(Endurance));
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            init
            {
                ValidateStat(value, nameof(Sprint));
                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            init
            {
                ValidateStat(value, nameof(Dribble));
                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            init
            {
                ValidateStat(value, nameof(Passing));
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            init
            {
                ValidateStat(value, nameof(Shooting));
                shooting = value;
            }
        }

        public double SkillLevel => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

        private void ValidateStat(int value, string statName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }
    }
}
