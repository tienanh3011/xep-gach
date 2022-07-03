using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris1
{
    class Cell
    {
        private int[,] cell = new int[3, 3];
        private ConsoleColor bg, fg;
        private int x, y;
        private Draw pen;

        public int Y
        {
            get { return y; }
            set
            {
                Clear();
                y = value;
                Draw();
            }
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
        public void Rotate()
        {
            int[,] tmp = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tmp[j, 2 - i] = cell[i, j];
                }
            }
            cell = tmp;

        }
        public Cell(ConsoleColor bg, ConsoleColor fg)
        {

            pen = new Draw();
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
            //return GetCell(5);

        }
        private int[,] GetCell(int idx)
        {
            ArrayList DefaultCell = new ArrayList();
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
            //int y_ = y;
            
            //Console.ForegroundColor = fg;
            for (int i = 0; i < 3; i++)

            {
                int xL = x;
                int yT = y + (i * pen.Height);
                for (int j = 0; j < 3; j++)
                {
                    xL = x + (j * pen.Width);
                    if (cell[i, j] == 1)
                    {
                        pen.drawRec(xL, yT, xL + pen.Width, yT + pen.Height, fg);
                    }
                    //Console.SetCursorPosition(x + j, y_);
                    // Console.Write("{0}", cell[i, j] == 0 ? ' ' : '*');

                    
                }
            }
        }
        public void Clear()
        {
            int y_ = y;
            //Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < 3; i++)
            {
                int xL = x;
                int yT = y + (i * pen.Height);
                for (int j = 0; j < 3; j++)
                {
                    xL = x + (j * pen.Width);
                    if (cell[i, j] == 1)
                    {
                        pen.drawRec(xL, yT, xL + pen.Width, yT + pen.Height, bg);
                    }
                    //Console.Write(' ');
                }
                
            }
        }
        public void Move()
        {

        }
    }
}