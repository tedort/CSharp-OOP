using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            int removeOperations = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            List<int> resultsAdd = new List<int>();

            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            List<int> resultsAddRemove = new List<int>();
            List<string> resultsRemove = new List<string>();

            MyList myList = new MyList();
            List<int> resultsAddMyList = new List<int>();
            List<string> resultsRemoveMyList = new List<string>();

            foreach (string item in items)
            {
                resultsAdd.Add(addCollection.Add(item));
                resultsAddRemove.Add(addRemoveCollection.Add(item));
                resultsAddMyList.Add(myList.Add(item));
            }

            for (int i = 0; i < removeOperations; i++)
            {
                resultsRemove.Add(addRemoveCollection.Remove());
                resultsRemoveMyList.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", resultsAdd));
            Console.WriteLine(string.Join(" ", resultsAddRemove));
            Console.WriteLine(string.Join(" ", resultsAddMyList));
            Console.WriteLine(string.Join(" ", resultsRemove));
            Console.WriteLine(string.Join(" ", resultsRemoveMyList));
        }
    }
}
