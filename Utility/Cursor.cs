using LTT.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Utility
{
    class Cursor
    {
        InputKey inputKey;
        public Cursor(InputKey inputKey)
        {
            this.inputKey = new InputKey();
        }
        public void LimitCursor(int x, int y, int yMin, int yMax)
        {
            ConsoleKeyInfo getKey;
            
            bool isNotEnd = true;

            while (isNotEnd)
            {
                Console.SetCursorPosition(x, y); //좌표 지정
                getKey = Console.ReadKey(true);    //다음문자나 사용자가 누른 키를 가져옴
                switch (getKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        x--;
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        break;
                    case ConsoleKey.UpArrow:
                        y--;
                        if (y < yMin)
                        {
                            y = yMax;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        y++;
                        if (y > yMax)
                        {
                            y = yMin;
                        }
                        break;
                    case ConsoleKey.Enter:
                        isNotEnd = false;
                        return;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
    }
}
