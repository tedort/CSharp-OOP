namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(3, 5);
            Shape circle = new Circle(4);

            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(circle.Draw());
        }
    }
}
