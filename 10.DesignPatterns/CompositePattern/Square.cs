namespace CompositePattern
{
    public class Square : Shape
    {
        public Square(int size, Position position) : base(size, position)
        {

        }

        public override void Draw()
        {
            base.Draw();

            Console.SetCursorPosition(Position.X, Position.Y);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write("#");
                }
                Console.SetCursorPosition(Position.X, Position.Y + i);
            }
        }
    }
}
