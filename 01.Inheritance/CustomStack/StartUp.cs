namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings strings = new StackOfStrings();
            Console.WriteLine(strings.IsEmpty());
            strings.Push("Tedo");
            List<string> names = new List<string>() { "Pesho", "Gosho"};
            strings.AddRange(names);
            Console.WriteLine(strings.IsEmpty());
        }
    }
}
