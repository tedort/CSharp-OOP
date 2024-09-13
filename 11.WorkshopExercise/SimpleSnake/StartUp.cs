namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(32, 18);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall, snake);
            engine.Run();

            //Point p = new Point(2, 0);
            //p.Draw('@');

            //Wall wall = new Wall(20, 20);
            //wall.SetHorizontalLine(0);
            //wall.SetVerticalLine(0);
        }
    }
}
