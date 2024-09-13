﻿namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public IReadOnlyList<Person> FirstTeam
        {
            get => firstTeam.AsReadOnly();
        }

        public IReadOnlyList<Person> ReserveTeam
        {
            get => reserveTeam.AsReadOnly();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

        public override string ToString()
        {
            return $"First team has {FirstTeam.Count} players.\n" +
                $"Reserve team has {ReserveTeam.Count} players.";
        }
    }
}
