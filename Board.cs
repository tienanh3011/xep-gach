using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris1
{
    class Board
    {
        private Draw pen;
        private ConsoleColor bg, fg;
        public Board(ConsoleColor bg, ConsoleColor fg)
        {
            pen = new Draw();
            this.bg = bg; ;this.fg = fg;
        }
        public void Draw ()
        {
            pen.drawRec(0, 0, 34, 31, bg);
            pen.drawRec(0, 0, 2, 31, fg);
            pen.drawRec(32, 0, 34, 31, fg);
            pen.drawRec(0, 30, 34, 31, fg);
        }
    }
}
