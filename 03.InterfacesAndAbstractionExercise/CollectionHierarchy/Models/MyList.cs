using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private readonly List<string> items;

        public MyList()
        {
            items = new List<string>();
        }

        public int Used => items.Count;

        public int Add(string item)
        {
            items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string result = items[0];
            items.RemoveAt(0);
            return result;
        }
    }
}
