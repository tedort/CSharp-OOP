namespace MilitaryElite.Models.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public List<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
