using LTT.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Controller
{
    class InputKey
    {
        private ExceptionHandler exceptionHandler;

        public InputKey()
        {
            this.exceptionHandler = new ExceptionHandler();
        }

        public string EnterKey(bool password)
        {
            string inputString = "";
            ConsoleKeyInfo keyInfo;

            keyInfo = Console.ReadKey(true);

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return "-1";
                }
                else if (keyInfo.Key != ConsoleKey.Backspace)
                {
                    if (!exceptionHandler.IsMatch(keyInfo.KeyChar.ToString(), Constant.Constant.INPUTSTRING))
                    {
                        keyInfo = Console.ReadKey(true);
                        
                        continue;
                    }
                    inputString += keyInfo.KeyChar;

                    if (password == true)
                    {
                        Console.Write("*");
                    }

                    else
                    {
                        Console.Write(keyInfo.KeyChar);
                    }
                }
                else
                {
                    if (inputString.Length > 0)
                    {
                        inputString = inputString.Substring(0, inputString.Length - 1);
                        Console.CursorLeft -= 1;
                        Console.Write(' ');
                        Console.CursorLeft -= 1;
                    }
                }
                keyInfo = Console.ReadKey(true);
            }
            return inputString;
        }
    }
}
