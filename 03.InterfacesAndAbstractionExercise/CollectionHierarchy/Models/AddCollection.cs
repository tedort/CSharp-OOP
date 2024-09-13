using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> items;

        public AddCollection()
        {
            items = new List<string>();
        }

        public int Add(string item)
        {
            items.Add(item);
            return items.Count - 1;
        }
    }
}
