namespace MilitaryElite.Models.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
        public void AddMission(IMission mission);
    }
}
