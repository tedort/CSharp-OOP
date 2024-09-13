using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System.IO;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fishes;
        private string[] diverTypes = new string[] { typeof(ScubaDiver).Name, typeof(FreeDiver).Name };
        private string[] fishTypes = new string[] { typeof(ReefFish).Name, typeof(PredatoryFish).Name, typeof(DeepSeaFish).Name };

        public Controller()
        {
            divers = new DiverRepository();
            fishes = new FishRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!diverTypes.Contains(diverType))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.GetModel(diverName) != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);
            }

            IDiver diver = null;

            if (diverType == typeof(ScubaDiver).Name)
            {
                diver = new ScubaDiver(diverName);
            }
            if (diverType == typeof(FreeDiver).Name)
            {
                diver = new FreeDiver(diverName);
            }

            divers.AddModel(diver);

            return string.Format(OutputMessages.DiverRegistered, diverName, typeof(DiverRepository).Name);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!fishTypes.Contains(fishType))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fishes.GetModel(fishName) != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, typeof(FishRepository).Name);
            }

            IFish newFish = null;

            if (fishType == typeof(ReefFish).Name)
            {
                newFish = new ReefFish(fishName, points);
            }
            if (fishType == typeof(DeepSeaFish).Name)
            {
                newFish = new DeepSeaFish(fishName, points);
            }
            if (fishType == typeof(PredatoryFish).Name)
            {
                newFish = new PredatoryFish(fishName, points);
            }

            fishes.AddModel(newFish);

            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return string.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);
            }

            if (fishes.GetModel(fishName) == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, typeof(FishRepository).Name, fishName);
            }

            IDiver currentDiver = divers.GetModel(diverName);
            IFish currentFish = fishes.GetModel(fishName);

            if (currentDiver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (currentDiver.OxygenLevel < currentFish.TimeToCatch)
            {
                currentDiver.Miss(currentFish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (currentDiver.OxygenLevel == currentFish.TimeToCatch)
            {
                if (isLucky)
                {
                    currentDiver.Hit(currentFish);
                    return String.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, currentFish.Name);
                }
                else
                {
                    currentDiver.Miss(currentFish.TimeToCatch);
                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            else
            {
                currentDiver.Miss(currentFish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
        }

        public string HealthRecovery()
        {
            List<IDiver> healthIssueDivers = divers.Models.Where(d => d.HasHealthIssues).ToList();

            foreach (IDiver diver in healthIssueDivers)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }

            return string.Format(OutputMessages.DiversRecovered, healthIssueDivers.Count);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(diver.ToString());

            sb.AppendLine("Catch Report:");

            foreach (var caughFish in diver.Catch)
            {
                sb.AppendLine(caughFish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            List<IDiver> diversToReport = divers.Models
                .Where(d => !d.HasHealthIssues)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in diversToReport)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
