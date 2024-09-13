namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Tedo");
            list.Add("Pesho");
            list.Add("Gosho");
            string result = list.RandomString();
            Console.WriteLine(result);
        }
    }
}
