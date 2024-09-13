namespace Calculators
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            if (calculator.Add(5, 6) != 11)
            {
                Console.WriteLine("Bug in calculator add");
            }
        }
    }
}
