namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IDrawable> drawables = new List<IDrawable>();
            int radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);
            drawables.Add(circle);

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);
            drawables.Add(rect);

            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw();
            }
        }
    }
}
