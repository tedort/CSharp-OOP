using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get; protected set; }

        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {Salary:f2}";
        }
    }
}
