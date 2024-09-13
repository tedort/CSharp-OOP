namespace _04.Polymorphism
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            /*BMWThree bmw = new BMWThree();
            Drive(bmw);
            Console.WriteLine("----------");
            Drive(new SkodaOctavia());

            Console.WriteLine(bmw is object);
            Console.WriteLine(bmw is IDriveable);
            Console.WriteLine(bmw is JetSki);
            Console.WriteLine(bmw is Car);*/

            Console.WriteLine(DateTime.Now is var now && now == DateTime.Now);
        }

        public static void Drive(IDriveable driveable)
        {
            driveable.Start();
            driveable.Accelerate();
            driveable.Decelerate();
            driveable.Stop();
        }
    }
}
