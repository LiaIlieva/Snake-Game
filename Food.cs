using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame2.GameObjects
{
    public class Food : Point
    {
        private char foodElement;
        private Wall currentWall;
        private Random random;  // Declare an instance to use the Random class

        protected Food(Wall currentWall, char element, int foodPoints) : base(currentWall.LeftX, currentWall.TopY)
        {
            this.currentWall = currentWall;
            this.foodElement = element;
            this.random = new Random();
            this.foodPoints = foodPoints;
        }

        public int foodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snake)
        {
            bool isPartOfSnake;
            do
            {
                this.LeftX = random.Next(2, currentWall.LeftX - 2);
                this.TopY = random.Next(2, currentWall.TopY - 2);

                isPartOfSnake = snake.Any(sEl => sEl.LeftX == this.LeftX && sEl.TopY == this.TopY);
            } while (isPartOfSnake);

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodElement);
            Console.ResetColor();
        }

        public bool BumpsIntoSnakeHead(Point snakeHead)
        {
            return snakeHead.LeftX == this.LeftX && snakeHead.TopY == this.TopY;
        }
    }
}
