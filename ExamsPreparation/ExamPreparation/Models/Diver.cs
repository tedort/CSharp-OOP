using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> caughtFish;
        private double competitionPoints;
        private bool hasHealthIssues;

        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            caughtFish = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                if (value <= 0)
                {
                    hasHealthIssues = true;
                    oxygenLevel = 0;
                }
                else
                {
                    oxygenLevel = value;
                }
            }
        }

        public IReadOnlyCollection<string> Catch
        {
            get => caughtFish.AsReadOnly();
        }

        public double CompetitionPoints
        {
            get => competitionPoints;
        }

        public bool HasHealthIssues
        {
            get => hasHealthIssues;
            private set => hasHealthIssues = value;
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            this.caughtFish.Add(fish.Name);
            competitionPoints = Math.Round(competitionPoints + fish.Points, 1);
        }

        public abstract void Miss(int TimeToCatch);

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }

        public abstract void RenewOxy();

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {caughtFish.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
