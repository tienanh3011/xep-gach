using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/* readkey
 * key info
 * background()
 * Console.ForegroundColor
 */
class Cell
{
    private int[,] cell;
    private ConsoleColor bg, fg;
    private int x, y;
    public int Y
    {
       get{ return y; }
       set {Clear();
            y = value;
            Draw(); }
    }
    public int X
    {
        get { return x; }
        set
        {
            Clear();
            x = value;
            Draw();
        }
    }
    public Cell(ConsoleColor bg, ConsoleColor fg)
    {
        cell = new int[3, 3];
        x = 0;
        y = 0;
        this.bg = bg;
        this.fg = fg;
        cell = NextCell();
    }
    /*private int[,] NextCell1()
    {
        int maxCell = 6;
        Random rnd = new Random();
        return GetCell(rnd.Next(maxCell)+1);

    }*/
    private int[,] NextCell()
    {
        int maxCell = 6;
        Random rnd = new Random();
        return GetCell(rnd.Next(maxCell));

    }
    private int[,] GetCell(int idx)
    {
        ArrayList DefaultCell=new ArrayList();
        DefaultCell.Add(new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });//cach ngan gon
        DefaultCell.Add(new int[,] { { 1, 1, 1 }, { 0, 1, 0 }, { 0, 0, 0 } });
        DefaultCell.Add(new int[,] { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } });
        DefaultCell.Add(new int[,] { { 1, 1, 1 }, { 0, 0, 0 }, { 0, 0, 0 } });
        DefaultCell.Add(new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 1, 1 } });
        DefaultCell.Add(new int[,] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 1, 1 } });
        /* switch (idx)
         {
             case 1: return DefaultCell1(); break;
             case 2: return DefaultCell2(); break;
             case 3: return DefaultCell3(); break;
             case 4: return DefaultCell4(); break;
             case 5: return DefaultCell5(); break;

         }
         return DefaultCell6();*/
        return (int[,])DefaultCell[idx];
    }
   /* private int[,] DefaultCell1()
    {
        int[,] cell = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        return cell;
    }
    private int[,] DefaultCell2()
    {
        int[,] cell = { { 1, 1, 1 }, { 0, 1, 0 }, { 0, 0, 0 } };
        return cell;
    }
    private int[,] DefaultCell3()
    {
        int[,] cell = { { 1, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        return cell;
    }
    private int[,] DefaultCell4()
    {
        int[,] cell = { { 1, 1, 1 }, { 0, 0, 0 }, { 0, 0, 0 } };
        return cell;
    }
    private int[,] DefaultCell5()
    {
        int[,] cell = { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 1, 1 } };
        return cell;
    }
    private int[,] DefaultCell6()
    {
        int[,] cell = { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 1, 1 } };
        return cell;
    }*/
    public void Draw()
    {
        int y_ = y;
        Console.ForegroundColor = fg;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.SetCursorPosition(x + j, y_);
                Console.Write("{0}", cell[i, j] == 0 ? ' ' : '*');
            }
            y_++;
        }
    }
    public void Clear()
    {
        int y_ = y;
        Console.ForegroundColor = ConsoleColor.Black;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.SetCursorPosition(x + j, y_);
                Console.Write("{0}", cell[i, j] == 0 ? ' ' : '*');
            }
            y_++;
        }
    }
    public void Move()
    {

    }
}

namespace Tetris
{
    internal class xepgach
    {
        static Cell cell = new(ConsoleColor.Green, ConsoleColor.White);
        static void Main(string[] args)
        {

            //cell.Draw();

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
            /* Console.ForegroundColor = ConsoleColor.Green;//doi mau chu

             int x = 0, y = 0;
             int x_old, y_old;
             Console.SetCursorPosition(x, y);//toa do
             Console.WriteLine("***");
             Console.WriteLine("***");
             Console.WriteLine("***");
             Console.BackgroundColor = ConsoleColor.Black;
             do
             {
                 x_old = x; y_old = y;
                 ConsoleKeyInfo banphim;
                 banphim = Console.ReadKey();//gan nut
                 if (banphim.Key == ConsoleKey.Escape) //escape
                     break;
                 switch (banphim.Key)
                 {
                     case ConsoleKey.LeftArrow: x--; break;
                     case ConsoleKey.RightArrow: x++; break;
                     case ConsoleKey.UpArrow: y--; break;
                     case ConsoleKey.DownArrow: y += 2; break;
                 }
                 Console.ForegroundColor = ConsoleColor.Black;
                 Console.SetCursorPosition(x_old, y_old);
                 Console.WriteLine("***");
                 Console.WriteLine("***");
                 Console.WriteLine("***");
                 Console.ForegroundColor = ConsoleColor.Green;//doi mau chu
                 Console.SetCursorPosition(x, y);
                 Console.WriteLine("***");
                 Console.WriteLine("***");
                 Console.WriteLine("***");

             } while (true);*/

        }
        private static void Readkeys()
        {
            
            ConsoleKeyInfo banphim = new ConsoleKeyInfo();
            while (!Console.KeyAvailable & banphim.Key != ConsoleKey.Escape) 
            {
                banphim = Console.ReadKey(true);
                switch (banphim.Key)
                {
                    case ConsoleKey.LeftArrow: cell.X= cell.X-1; break;
                    case ConsoleKey.RightArrow: cell.X=cell.X+1; break;
                    case ConsoleKey.UpArrow: cell.Y=cell.Y-1 ; break;
                    case ConsoleKey.DownArrow: cell.Y=cell.Y+2; break;
                }
            }

        }
        private static void Animation()
        {
            for (; ; )
            {
                Thread.Sleep(1000);
                cell.Y = cell.Y + 1;
            }
        }
    }
}
