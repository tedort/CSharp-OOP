using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get; private set; }

        public void AddRepair(IRepair repair)
        {
            Repairs.Add(repair);
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Repairs:" + (Repairs.Count == 0 ? "" : Environment.NewLine + string.Join(Environment.NewLine, Repairs.Select(r => "  " + r.ToString())));
        }
    }
}
