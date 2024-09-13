using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> items;

        public AddRemoveCollection()
        {
            items = new List<string>();
        }

        public int Add(string item)
        {
            items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string result = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return result;
        }
    }
}
