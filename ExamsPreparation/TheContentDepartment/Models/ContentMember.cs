using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        private string[] allowedPaths = { "CSharp", "JavaScript", "Python", "Java" };
        private string path;

        public ContentMember(string name, string path) : base(name, path)
        {
            Path = path;
        }

        public string Path
        {
            get => path;
            private set
            {
                if (!allowedPaths.Contains(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, value));
                }
                path = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Path} path. Currently working on {InProgress.Count} tasks.";
        }
    }
}
