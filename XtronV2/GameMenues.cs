using System;
using System.Collections.Generic;
using System.IO;

using XtronF;

namespace XtronV2
{
    public class GameMenues
    {
        private static List<string> HeaderText = new List<string>();
        private static int HeaderLength = 0;
        private static string SmallTab = "     ";

        public static void GenerateHeader()
        {
            HeaderText.Add("____  ___ __");
            HeaderText.Add("\\   \\/  //  |________  ____   ____");
            HeaderText.Add(" \\     /\\   __\\_  __ \\/  _ \\ /    \\");
            HeaderText.Add(" /     \\ |  |  |  | \\(  <_> )   |  \\");
            HeaderText.Add("/___/\\  \\|__|  |__|   \\____/|___|  /");
            HeaderText.Add("      \\_/                        \\/");

            for (int i = 0; i < HeaderText.Count; i++)
            {
                if (HeaderText[i].Length > HeaderLength) HeaderLength = HeaderText[i].Length;
            }

            for (int i = 0; i < HeaderText.Count; i++)
            {
                if (HeaderText[i].Length < HeaderLength)
                {
                    for (int j = HeaderText[i].Length; j < HeaderLength; j++)
                    {
                        HeaderText[i] += " ";
                    }
                }
            }

            Tuple<int, int> xy = new Tuple<int, int>(HeaderText.Count + 4, 70);
            Tuple<int, int> xyDiff = new Tuple<int, int>((xy.Item1 - HeaderText.Count) / 2, (xy.Item2 - HeaderLength) / 2);
            var tDiff = (xy.Item2 - HeaderLength) / 2; // skillnaden mellan headerns bredd och titeltextens bredd
            var SolidBlock = "█";
            var Space = " ";
            

            string[] ProgramHeader = new string[xy.Item1];

            for (int i = 0; i < xy.Item1; i++)
            {
                var k = 0;

                for (int j = 0; j < xy.Item2; j++)
                {
                    if (i == 0 || i == xy.Item1 - 1) ProgramHeader[i] += SolidBlock;
                    else
                    {
                        if (j == 0 || j == xy.Item2 - 1)
                        {
                            ProgramHeader[i] += SolidBlock;
                        }
                        else if ((i >= xyDiff.Item1 && i <= xy.Item1 - xyDiff.Item1 - 1) && j > xyDiff.Item2 && j <= xy.Item2 - xyDiff.Item2)
                        {
                            ProgramHeader[i] += HeaderText[i - xyDiff.Item1].Substring(k, 1);
                            k++;
                        }
                        else ProgramHeader[i] += Space;

                        if (j == xy.Item2 - 1) k = 0;
                    }
                }
            }

            for (int i = 0; i < ProgramHeader.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("\n");
                }
                if (i <= 1 || i >= ProgramHeader.Length - 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{SmallTab}{ProgramHeader[i]}");
                }
                else
                {
                    Console.Write($"{ SmallTab}{ProgramHeader[i].Substring(0, 1)}");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(ProgramHeader[i].Substring(1, ProgramHeader[i].Length - 2));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(ProgramHeader[i].Substring(ProgramHeader[i].Length - 1, 1));
                }
            }
            Console.WriteLine("\n");
        }

        public static int StartMenuSelect()
        {
            XtronFunctions.DrawLine(ConsoleColor.DarkGreen);
            Console.WriteLine($"\n{SmallTab}>> NEW GAME");
            if (!File.Exists(@"gamesave.txt")) Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{SmallTab}   CONTINUE");
            if (Console.ForegroundColor == ConsoleColor.DarkRed) Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{SmallTab}   EXIT\n\n");
            XtronFunctions.DrawLine(ConsoleColor.DarkGreen);
                                    
            int MenuSelect;            
            return MenuSelect = MenuBrowse(3, 5, 16, 22);

        }

        public static int MenuBrowse(int MenuItems, int CursorX, int CursorY, int EndAtLine, ConsoleKey consoleKey = ConsoleKey.Enter)
        {

            ConsoleKeyInfo keyInfo;
            int MenuSelect = 1;
            int StartY = CursorY;

            do
            {
                keyInfo = Console.ReadKey(true);
                

                switch (Convert.ToString(keyInfo.Key))
                {
                    case "UpArrow":
                        if (CursorY > StartY)
                        {
                            Console.SetCursorPosition(CursorX, CursorY);
                            Console.Write("  ");
                            CursorY--;
                            Console.SetCursorPosition(CursorX, CursorY);
                            Console.Write(">>");
                            MenuSelect--;
                        }
                        break;
                    case "DownArrow":
                        if (CursorY < (StartY + MenuItems -1))
                        {
                            Console.SetCursorPosition(CursorX, CursorY);
                            Console.Write("  ");
                            CursorY++;
                            Console.SetCursorPosition(CursorX, CursorY);
                            Console.Write(">>");
                            MenuSelect++;
                        }
                        break;
                }
                Console.SetCursorPosition(0, EndAtLine);

            } while (Convert.ToString(keyInfo.Key) != Convert.ToString(consoleKey));

            return MenuSelect;
        }


    }
}
