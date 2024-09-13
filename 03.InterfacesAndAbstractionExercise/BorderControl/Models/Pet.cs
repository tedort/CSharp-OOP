namespace BorderControl.Models
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }

        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
}
