using System.Dynamic;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class TeamLead : TeamMember
    {
        private string path;

        public TeamLead(string name, string path) : base(name, path)
        {
            Path = path;
        }

        public string Path
        {
            get => path;
            private set
            {
                if (value != "Master")
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
                }
                path = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}) – Currently working on {InProgress.Count} tasks.";
        }
    }
}
