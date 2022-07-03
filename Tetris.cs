using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris1
{
    class Tetris
    {

        public void run()
        {
            var readkeys = new Task(Readkeys);//var la ten bien, var la bien
            readkeys.Start();
            var animation = new Task(Animation);
            animation.Start();

            var tasks = new[] { readkeys };
            Task.WaitAll(tasks);
            Console.CancelKeyPress += (sender, e) =>
            {
                Environment.Exit(0);
            };
        }
        public Tetris()
        {
            cell = new Cell(ConsoleColor.Black, ConsoleColor.White);
        }
        private Cell cell;
        private void Readkeys()
        {

            ConsoleKeyInfo banphim = new ConsoleKeyInfo();
            while (!Console.KeyAvailable & banphim.Key != ConsoleKey.Escape)
            {
                banphim = Console.ReadKey(true);
                switch (banphim.Key)
                {
                    case ConsoleKey.LeftArrow: cell.X = cell.X - 1; break;
                    case ConsoleKey.RightArrow: cell.X = cell.X + 1; break;
                    case ConsoleKey.UpArrow: cell.Rotate(); break;
                    case ConsoleKey.DownArrow: cell.Y = cell.Y + 2; break;
                }
            }

        }
        private void Animation()
        {
            for (; ; )
            {
                Thread.Sleep(1000);
                cell.Y = cell.Y + 1;
            }
        }
    }
}
