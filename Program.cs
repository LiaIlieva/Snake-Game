using SimpleSnake2.Utilities;
using SnakeGame2.GameObjects;
using System;

namespace SimpleSnake
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);

            Console.WriteLine();

            Snake snake = new Snake(wall);
            
            Engine engine = new Engine(wall, snake);
            engine.Run();

        }
    }
}
