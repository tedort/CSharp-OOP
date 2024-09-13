namespace PlayCatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int exceptionCount = 0;

                while (exceptionCount < 3)
                {
                    string input = Console.ReadLine();

                    string[] commandParts = input.Split(' ');
                    string command = commandParts[0];

                    try
                    {
                        switch (command)
                        {
                            case "Replace":
                                int replaceIndex = int.Parse(commandParts[1]);
                                int newElement = int.Parse(commandParts[2]);
                                array[replaceIndex] = newElement;
                                break;

                            case "Print":
                                int startIndex = int.Parse(commandParts[1]);
                                int endIndex = int.Parse(commandParts[2]);
                                if (startIndex < 0 || endIndex >= array.Length || startIndex > endIndex)
                                {
                                    throw new IndexOutOfRangeException();
                                }
                                Console.WriteLine(string.Join(", ", array.Skip(startIndex).Take(endIndex - startIndex + 1)));
                                break;

                            case "Show":
                                int showIndex = int.Parse(commandParts[1]);
                                Console.WriteLine(array[showIndex]);
                                break;

                            default:
                                throw new FormatException();
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("The index does not exist!");
                        exceptionCount++;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        exceptionCount++;
                    }
                }

                Console.WriteLine(string.Join(", ", array));
            }
            catch (FormatException)
            {
                Console.WriteLine("The variable is not in the correct format!");
            }
        }
    }
}
