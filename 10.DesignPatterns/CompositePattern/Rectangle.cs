namespace CompositePattern
{
    public class Rectangle : Shape
    {
        public Rectangle(int size, Position position) : base(size, position)
        {
            
        }

        public override void Draw()
        {
            base.Draw();

            Console.SetCursorPosition(Position.X, Position.Y);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size * 2; j++)
                {
                    Console.Write("#");
                }

                Console.SetCursorPosition(Position.X, Position.Y + i);
            }
        }
    }
}
