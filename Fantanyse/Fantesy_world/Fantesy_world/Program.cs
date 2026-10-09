using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fantesy_world
{
    abstract class Character
    {
        protected static Random random = new Random();
        public string Name { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public ConsoleColor Color { get; set; }

        public abstract void Move();
        public abstract void Show();

        public Character(string name, int x, int y)
        {
            Name = name;
            this.x = random.Next(0, World.Width);
            this.y = random.Next(0, World.Height);
        }

        public bool TargetInWorld(int x, int y)
        {
            if(x <= 0 && x >= World.Width && y <= 0 && y >= World.Height)
            {
                return true;
            }
            return false;
        }

    }
    sealed class Wizard : Character
    {
        public Wizard(string name, int x, int y) : base(name, x, y)
        {
            this.Color = ConsoleColor.Blue;
        }
        public override void Move()
        {
           int X = random.Next(0, 8);
            int dx = 0;
            int dy = 0;
            switch (X)
            {
                case 0:
                    dx=-1;dy =1;
                    break;
                case 1:
                    dx=0;dy=1;
                    break;
                case 2:
                    dx= +1; dy = 1;
                    break;
                case 3:
                    dx = 1; dy = 0;
                    break;
                case 4:
                    dx=1;dy=-1;
                    break;
                case 5:
                    dx = 0; dy = -1;
                    break;
                case 6:
                    dx=-1;dy=-1;
                    break;
                case 7:
                    dx=-1;dy=-1;
                    break;
                default:
                    break;

            }
            if (TargetInWorld(x + dx, y + dy))
            {
                x += dx;
                y += dy;
            }

            Console.WriteLine("Player is moving");
        }
        public override void Show()
        {
            
            Console.WriteLine($"Player Name: {Name}, Position: ({x}, {y})");
            Console.BackgroundColor = Color;

        }
    }
    class World
    {
      public const int Width = 20;
      public const int Height = 10;

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of your character:");
            string name = Console.ReadLine();
            Wizard wizard = new Wizard(name, 0, 0);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Clear();
                wizard.Move();
                wizard.Show();
                Console.WriteLine("Press any key to move the character...");
                Console.ReadKey();
                
                
            }
        }
    }
}
