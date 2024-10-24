using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame2.GameObjects
{
    public class Point
    {
        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }

        public int LeftX { get; set; }
        public int TopY { get; set; }

        public void Draw(char symbol)
        {
            // Ensure the coordinates are within the console's buffer size
            if (LeftX >= 0 && LeftX < Console.WindowWidth && TopY >= 0 && TopY < Console.WindowHeight)
            {
                Console.SetCursorPosition(LeftX, TopY);
                Console.Write(symbol);
            }
            else
            {
                Console.WriteLine("Error: The coordinates are out of the console's range.");
            }
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            // Ensure the coordinates are within the console's buffer size
            if (LeftX >= 0 && LeftX < Console.WindowWidth && TopY >= 0 && TopY < Console.WindowHeight)
            {
                Console.SetCursorPosition(leftX, topY);
                Console.Write(symbol);
            }
            else
            {
                Console.WriteLine("Error: The coordinates are out of the console's range.");
            }
        }
    }
}
