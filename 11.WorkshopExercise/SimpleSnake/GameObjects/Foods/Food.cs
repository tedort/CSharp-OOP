using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Random _random;
        private Wall _wall;
        private char _foodSymbol;

        protected Food(Wall wall, char foodSymbol, int foodPoints) 
            : base(wall.LeftX, wall.TopY)
        {
            _wall = wall;
            FoodPoints = foodPoints;
            _foodSymbol = foodSymbol;
            _random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = _random.Next(2, _wall.LeftX - 2);
            TopY = _random.Next(2, _wall.TopY - 2);

            bool isPointOnSnake = snakeElements
                .Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPointOnSnake)
            {
                LeftX = _random.Next(2, _wall.LeftX - 2);
                TopY = _random.Next(2, _wall.TopY - 2);

                isPointOnSnake = snakeElements
                    .Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(_foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead)
        {
            return snakeHead.TopY == TopY &&
                snakeHead.LeftX == LeftX;
        }
    }
}
