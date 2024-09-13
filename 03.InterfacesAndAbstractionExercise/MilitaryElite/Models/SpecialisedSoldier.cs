using MilitaryElite.Models.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps 
        {
            get => corps;
            init
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid corps!");
                }
                corps = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCorps: {Corps}";
        }
    }
}
