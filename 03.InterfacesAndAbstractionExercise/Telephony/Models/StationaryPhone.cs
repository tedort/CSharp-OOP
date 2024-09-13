using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        private string number;

        public StationaryPhone(string number)
        {
            Number = number;
        }

        public string Number
        {
            get => number;
            private set
            {
                char[] chars = value.ToCharArray();
                foreach (char symbol in chars)
                {
                    if (char.IsLetter(symbol) || char.IsWhiteSpace(symbol))
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                number = value;
            }
        }

        public void Call()
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
