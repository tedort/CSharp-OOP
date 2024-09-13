using System.Text;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        private int stamina;
        private List<string> conqueredPeaks;

        public Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Stamina
        {
            get => stamina;
            protected set
            {
                if (value > 10)
                {
                    stamina = 10;
                }

                else if (value < 0)
                {
                    stamina = 0;
                }
                else
                {
                    stamina = value;
                }
            }
        }
        public IReadOnlyCollection<string> ConqueredPeaks
        {
            get => conqueredPeaks.AsReadOnly();
        }

        public void Climb(IPeak peak)
        {
            if (!conqueredPeaks.Contains(peak.Name))
            {
                conqueredPeaks.Add(peak.Name);
            }

            if (peak.DifficultyLevel == "Extreme")
            {
                stamina -= 6;
            }

            else if (peak.DifficultyLevel == "Hard")
            {
                stamina -= 4;
            }

            else if (peak.DifficultyLevel == "Moderate")
            {
                stamina -= 2;
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.AppendLine("Peaks conquered: " + (conqueredPeaks.Count > 0 ? conqueredPeaks.Count : "no peaks conquered"));
            return sb.ToString().Trim();
        }
    }
}
