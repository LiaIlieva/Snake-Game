using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame2.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';
        public Wall(int leftX, int topY) : base(leftX, topY)
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);
            SetVerticalLine(0);
            SetVerticalLine(this.LeftX-1);
        }

        public void SetHorizontalLine(int topY) 
        {
            for (int i = 0; i < this.LeftX; i++)
            {
                this.Draw(i, topY, wallSymbol);
            }
        }

        public void SetVerticalLine(int leftX)
        {
            for (int j = 0; j < this.TopY; j++)
            {
                this.Draw(leftX, j, wallSymbol);
            }
        }

        public bool IsPointOfWall(Point snake) 
        {
            return snake.LeftX == this.LeftX || snake.TopY == this.TopY || snake.LeftX == 0 || snake.TopY == 0;
        }
    }
}
