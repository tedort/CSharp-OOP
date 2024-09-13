using CommandPattern.Commands;

namespace CommandPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            while (true)
            {
                calculator.PrintHistory();

                string @operator = Console.ReadLine();
                int value = int.Parse(Console.ReadLine());

                ICommand command = null;
                if (@operator == "+")
                {
                    command = new PlusCommand(value);
                }
                else if (@operator == "-")
                {
                    command = new MinusCommand(value);
                }
                else if (@operator == "*")
                {
                    command = new MultiplyCommand(value);
                }
                else if (@operator == "/")
                {
                    command = new DivideCommand(value);
                }
                else if (@operator == "u")
                {
                    calculator.Undo(value);
                }
                else if (@operator == "r")
                {
                    calculator.Redo(value);
                }
                if (command != null)
                {
                    calculator.ExecuteCommand(command);
                }

                Console.Clear();
            }
        }
    }
}
