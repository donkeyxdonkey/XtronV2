using System;
using System.Linq;

namespace XtronF
{
    public static class XtronFunctions
    {
        //FUNKTIONER

        public static void ClearLine(int Times)
        {
            for (int i = 0; i < Times; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
            }
        }

        public static void DrawLine(ConsoleColor ConsColor)
        {
            if (Console.ForegroundColor != ConsColor) Console.ForegroundColor = ConsColor;
            Console.WriteLine("-------------------------------------------------------------------------------");
        }

        public static string CorrectLetterOnlyInput()
        {
            var str = "";
            var Repeat = false;

            while (true)
            {
                if (Repeat == true) ClearLine(1);

                Console.Write("PLAYER NAME:>");
                str = Console.ReadLine();

                if (str != "" && str.All(char.IsLetter)) return str;

                if (Repeat == false) Repeat = true;
            }
        }

    }

}
