using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        private string number;
        private string site;

        public string Number
        {
            get => number;
            set
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

        public string Site
        {
            get => site;
            set
            {
                char[] chars = value.ToCharArray();
                foreach (char symbol in chars)
                {
                    if (char.IsDigit(symbol) || char.IsWhiteSpace(symbol))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }
                }
                site = value;
            }
        }

        public void Browse()
        {
            Console.WriteLine($"Browsing: {site}!");
        }

        public void Call()
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
