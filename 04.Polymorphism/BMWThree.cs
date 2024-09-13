namespace _04.Polymorphism
{
    public class BMWThree : Car
    {
        public override void Accelerate()
        {
            Console.WriteLine("Quickly going fast");
        }

        public override void Decelerate()
        {
            Console.WriteLine("Slowly going slow");
        }

        public override void Start()
        {
            base.Start();
            Console.WriteLine("BMW start immediately only in summer");
        }
    }
}
