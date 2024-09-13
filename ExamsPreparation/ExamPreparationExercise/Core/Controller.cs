using System.Text;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private PeakRepository peaks;
        private ClimberRepository climbers;
        private BaseCamp baseCamp;
        private string[] allowedDifficultyLevels = new string[] { "Extreme", "Hard", "Moderate" };

        public Controller()
        {
            peaks = new PeakRepository();
            climbers = new ClimberRepository();
            baseCamp = new BaseCamp();
        }

        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            IPeak peak = null;
            if (peaks.Get(name) != null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }
            else if (!allowedDifficultyLevels.Contains(difficultyLevel))
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }
            else
            {
                peak = new Peak(name, elevation, difficultyLevel);
                peaks.Add(peak);
                return string.Format(OutputMessages.PeakIsAllowed, name, typeof(PeakRepository).Name);
            }
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            IClimber climber = null;
            if (climbers.Get(name) != null)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, typeof(ClimberRepository).Name);
            }
            else
            {
                if (isOxygenUsed)
                {
                    climber = new OxygenClimber(name);
                }
                else
                {
                    climber = new NaturalClimber(name);
                }
                climbers.Add(climber);
                baseCamp.ArriveAtCamp(name);

                return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
            }
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IPeak peak = peaks.Get(peakName);
            IClimber climber = climbers.Get(climberName);

            if (climber == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            else if (peak == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            else if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            else if (peak.DifficultyLevel == "Extreme" && climber.GetType().Name == "NaturalClimber")
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            else
            {
                baseCamp.LeaveCamp(climberName);
                climber.Climb(peak);
                if (climber.Stamina <= 0)
                {
                    return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
                }
                else
                {
                    baseCamp.ArriveAtCamp(climberName);
                    return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
                }
            }
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            IClimber climber = climbers.Get(climberName);

            if (climber == null)
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            else if (climber.Stamina == 10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            else
            {
                climber.Rest(daysToRecover);
                return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
            }
        }

        public string BaseCampReport()
        {
            if (baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("BaseCamp residents:");
            foreach (string baseCampResident in baseCamp.Residents)
            {
                IClimber climber = climbers.Get(baseCampResident);
                sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }

            return sb.ToString().Trim();
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            List<IClimber> climbersList = climbers.All
                .OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name)
                .ToList();
            sb.AppendLine("***Highway-To-Peak***");
            foreach (IClimber climber in climbersList)
            {
                sb.AppendLine(climber.ToString());

                List<IPeak> climberPeaks = climber.ConqueredPeaks
                    .Select(p => peaks.Get(p))
                    .OrderByDescending(p => p.Elevation)
                    .ToList();

                foreach (IPeak climberPeak in climberPeaks)
                {
                    sb.AppendLine(climberPeak.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
