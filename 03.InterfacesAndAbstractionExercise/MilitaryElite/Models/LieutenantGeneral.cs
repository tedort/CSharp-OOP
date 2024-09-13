using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<IPrivate> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => privates.AsReadOnly();

        public void AddPrivate(IPrivate @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Privates:" + (Privates.Count == 0 ? "" : Environment.NewLine + string.Join(Environment.NewLine, Privates.Select(p => "  " + p.ToString())));
        }
    }
}
