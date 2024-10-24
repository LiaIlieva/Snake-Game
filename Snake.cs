using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame2.GameObjects
{
    public class Snake
    {

        public Snake(Wall currentWall) 
        {
            this.wall = currentWall;
            this.SnakeBody = new Queue<Point>();
            this.food = new Food[3];
            this.foodIndex = RandomFoodNumber;

            this.CreateSnake();
            this.GetFoods();

            this.food[foodIndex].SetRandomPosition(this.SnakeBody);

        }

        public const int StartingLength = 6;

        private const char SnakeSymbol = '\u25CF';
        public Queue<Point> SnakeBody { get; set; }

        public Food[] food {get; set; }

        public int foodIndex;

        public Wall wall { get; set; }

        public int nextLeftX { get; set; }

        public int nextTopY { get; set; }

        private int RandomFoodNumber => new Random().Next(0, food.Length);

        public void CreateSnake() 
        {
            for (int i = 0; i < StartingLength; i++)
            {
                SnakeBody.Enqueue(new Point(2, i + 1));
            }
        }

        public void GetFoods()
        {
            this.food[0] = new FoodAsterisk(this.wall);
            this.food[1] = new FoodDollar(this.wall);
            this.food[2] = new FoodHash(this.wall);
        }

        public bool IsMoving(Point currentDirection) 
        {
            Point snakeHead = this.SnakeBody.Last();

            GetNextPoint(currentDirection, snakeHead);

            bool bumpsIntoSnake = this.SnakeBody.Any(el => el.LeftX == this.nextLeftX && el.TopY == this.nextTopY);
            if (bumpsIntoSnake) return false;

            snakeHead = new Point(this.nextLeftX, this.nextTopY);
            if(this.wall.IsPointOfWall(snakeHead)) return false;

            this.SnakeBody.Enqueue((Point)snakeHead);
            snakeHead.Draw(SnakeSymbol);

            Point snakeTail = this.SnakeBody.Dequeue();
            snakeTail.Draw(' ');

            if (this.food[foodIndex].BumpsIntoSnakeHead(snakeHead))
            {
                this.Eat(currentDirection, snakeHead);
            }

            return true;
        }

        public void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        public void Eat(Point direction, Point snakehead) 
        {
            int length = food[foodIndex].foodPoints;

            for (int i = 0; i < length; i++)
            {
                Point newSnakeHead = new Point(this.nextLeftX, this.nextTopY);
                GetNextPoint(direction, newSnakeHead);
                this.SnakeBody.Enqueue((Point)newSnakeHead);
                newSnakeHead.Draw(SnakeSymbol);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.food[foodIndex].SetRandomPosition(this.SnakeBody);
        }
    }
}