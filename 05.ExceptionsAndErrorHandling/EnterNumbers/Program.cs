namespace EnterNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int[] numbers = new int[10];

            for (int i = 0; i < 10; i++)
            {
                while (true)
                {
                    try
                    {
                        int currentStart = (i == 0) ? start : numbers[i - 1];
                        numbers[i] = ReadNumber(currentStart, end);
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                throw new ArgumentException("Invalid Number!");
            }

            if (number <= start || number >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return number;
        }
    }
}
