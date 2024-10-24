using SimpleSnake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame2.GameObjects;

public class Engine
{

    public Engine(Wall wall, Snake snake)
    {
        this.currentSnake = snake;
        this.currentWal = wall;
        this.directionPoints = new Point[4];
        CreateDirections();
        this.sleeptime = 100;
    }

    public Point[] directionPoints { get; set; }

    public Direction direction = Direction.Down;

    private Snake currentSnake { get; set; }
    private Wall currentWal { get; set; }
    public double sleeptime { get; set; }

    private void CreateDirections()
    {
        this.directionPoints[0] = new Point(1, 0);
        this.directionPoints[1] = new Point(-1, 0);
        this.directionPoints[2] = new Point(0, 1);
        this.directionPoints[3] = new Point(0, -1);
    }

    private void GetNextDirection()
    {
        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

        if (consoleKeyInfo.Key == ConsoleKey.LeftArrow)
        {
            if (direction != Direction.Right) { direction = Direction.Left; }
        }
        else if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
        {
            if (direction != Direction.Left) { direction = Direction.Right; }
        }
        else if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
        {
            if (direction != Direction.Down) { direction = Direction.Up; }
        }
        else if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
        {
            if (direction != Direction.Up) { direction = Direction.Down; }
        }

        Console.CursorVisible = false;
    }

    private void StopGame()
    {
        Console.Clear();
        Console.SetCursorPosition(40, 10);
        Console.WriteLine("Game over!");
        Thread.Sleep(1000); // Give time for the message to appear
        Environment.Exit(0);
    }



    public void AskUserForRestart()
    {
        int LeftX = this.currentWal.LeftX + 1;
        int TopY = this.currentWal.TopY;

        Console.SetCursorPosition(LeftX, TopY);
        Console.WriteLine("Do u want to continue? y/n");
        string input = Console.ReadLine();

        if (input == "y")
        {
            Console.Clear();
            StartUp.Main();
        }
        else
        {
            StopGame();
        }
    }

    public void Run()
    {
        while (true)
        {
            if (Console.KeyAvailable)
            {
                GetNextDirection();
            }
            int num = (int)direction;
            Point direction2 = this.directionPoints[(int)direction];
            bool isMovingNow = currentSnake.IsMoving(this.directionPoints[(int)direction]);

            if (isMovingNow == false)
            {
                AskUserForRestart();

            }

            sleeptime -= 0.01;
            Thread.Sleep((int)sleeptime);
        }

    }
}
