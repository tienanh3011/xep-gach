using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris1
{
    class Draw
    {
        const int WIDTH = 2;
        public int Width
        {
            get { return WIDTH; }
        }

        const int HEIGHT = 1;
        public int Height
        {
            get { return HEIGHT; }
        }
        public void drawRec(int xLeft, int ytop, int xRight, int yBottom, ConsoleColor color)
        {
            for(int y=ytop;y<yBottom;y++)
            {
                for(int x=xLeft;x<xRight;x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.BackgroundColor = color;
                    Console.CursorVisible = false;
                    Console.Write(' ');
                }
            }
        }
    }
}
