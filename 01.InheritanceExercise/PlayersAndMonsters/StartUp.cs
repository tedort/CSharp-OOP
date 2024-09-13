using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Wizard wizard = new Wizard("tedort", 10);
            Console.WriteLine(wizard);
        }
    }
}