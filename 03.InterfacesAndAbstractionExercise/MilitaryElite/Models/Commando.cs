using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private static readonly HashSet<string> validStates = new HashSet<string> { "inProgress", "Finished" };
        private readonly List<IMission> missions;
        public IReadOnlyCollection<IMission> Missions => missions.AsReadOnly();

        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public void AddMission(IMission mission)
        {
            if (validStates.Contains(mission.State))
            {
                missions.Add(mission);
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Missions:" + (Missions.Count == 0 ? "" : Environment.NewLine + string.Join(Environment.NewLine, Missions.Select(m => "  " + m.ToString())));
        }
    }
}
