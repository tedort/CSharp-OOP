namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
