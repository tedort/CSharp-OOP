using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; }

        public string State
        {
            get => state;
            set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("Invalid state!");
                }
                state = value;
            }
        }

        public void CompleteMission()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
