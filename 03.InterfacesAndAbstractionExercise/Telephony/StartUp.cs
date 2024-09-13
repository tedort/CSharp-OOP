using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> sites = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone(phoneNumber);
                        stationaryPhone.Call();
                    }
                    else if (phoneNumber.Length == 10)
                    {
                        Smartphone smartphone = new Smartphone();
                        smartphone.Number = phoneNumber;
                        smartphone.Call();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (string site in sites)
            {
                try
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Site = site;
                    smartphone.Browse();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
