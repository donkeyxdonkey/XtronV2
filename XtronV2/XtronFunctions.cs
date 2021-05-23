using System;
using System.Diagnostics;

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

        public static string FindKeyInArray(string[] StringArray)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
            } while (!Array.Exists(StringArray, element => element == Convert.ToString(keyInfo.Key)));
            return Convert.ToString(keyInfo.Key);
        }

        public static string[] GenerateNumKeyArray(int ZeroToDigit)
        {
            if (ZeroToDigit > 9) ZeroToDigit = 9;

            string[] ArrOut = new string[ZeroToDigit];
            for (int i = 0; i < ZeroToDigit; i++)
            {
                ArrOut[i] = $"D{i + 1}";
            }
            return ArrOut;
        }

        public static void DelayStringWrite(string InputString, int DelayMS)
        {
            var SW = new Stopwatch();
            SW.Start();
            var i = 0;

            while (i < InputString.Length)
            {
                if (SW.ElapsedMilliseconds >= DelayMS)
                {
                    Console.Write(InputString[i]);
                    i++;
                    SW.Stop();
                    SW.Reset();
                    SW.Start();
                }
            }

            SW.Stop();
        }

    }

}
