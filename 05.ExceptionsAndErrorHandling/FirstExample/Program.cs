using System.Collections.Concurrent;

namespace FirstExample
{
    public class Program
    {
        public static double Sqrt(double value)
        {
            if (value < 0)
                throw new System.ArgumentOutOfRangeException("value",
                "Sqrt for negative numbers is undefined!");
            return Math.Sqrt(value);
        }


        static void Main(string[] args)
        {/*
            Console.WriteLine("How old are you?");
            int age = int.Parse(Console.ReadLine());*/

            /*Exception exception = new Exception("Your age cannot be less than zero!");
            exception.Data["Test"] = 5;

            Console.WriteLine($"Message: {exception.Message}");
            Console.WriteLine($"Source: {exception.Source}");
            Console.WriteLine($"Data: {exception.Data["Test"]}");
            Console.WriteLine($"TargetSite: {exception.TargetSite}");
            Console.WriteLine($"StackTrace: {exception.StackTrace}");*/

            try
            {
                Sqrt(4);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
                throw;
            }

            CustomException exception = new CustomException("Error");
            Console.WriteLine(exception.Message);

        }

        /*public static void Method()
        {
            Method();
        }*/
    }
}
