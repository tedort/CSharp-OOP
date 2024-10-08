﻿namespace CompositePattern
{
    public class Shape
    {
        protected List<Shape> children;

        public Shape(int size, Position position)
        {
            children = new List<Shape>();
            Size = size;
            Position = position;
        }

        public int Size { get; set; }

        public Position Position { get; set; }

        public void AddChild(Shape shape)
        {
            children.Add(shape);
        }

        public virtual void Draw()
        {
            foreach (Shape child in children)
            {
                child.Draw();
            }
        }

        public virtual void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    Position.Y--;
                    break;
                case Direction.Down:
                    Position.Y++;
                    break;
                case Direction.Left:
                    Position.X--;
                    break;
                case Direction.Right:
                    Position.X++;
                    break;
                default:
                    break;
            }

            foreach (Shape child in children)
            {
                child.Move(direction);
            }
        }
    }
}
