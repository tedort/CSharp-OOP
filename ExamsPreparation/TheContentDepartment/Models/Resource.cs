using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string name;
        private string creator;
        private int priority;
        private bool isTested;
        private bool isApproved;

        public Resource(string name, string creator, int priority)
        {
            Name = name;
            Creator = creator;
            Priority = priority;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                name = value;
            }
        }
        public string Creator
        {
            get => creator;
            private set
            {
                creator = value;
            }
        }
        public int Priority
        {
            get => priority;
            private set
            {
                priority = value;
            }
        }
        public bool IsTested
        {
            get => isTested;
        }
        public bool IsApproved
        {
            get => isApproved;
        }
        public void Test()
        {
            isTested = !isTested;
        }

        public void Approve()
        {
            isApproved = true;
        }

        public override string ToString()
        {
            return $"{Name} ({GetType().Name}), Created By: {Creator}";
        }
    }
}
