using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new Cake("Tedo");
            Console.WriteLine(cake.Grams);
            Console.WriteLine(cake.Calories);
        }
    }
}