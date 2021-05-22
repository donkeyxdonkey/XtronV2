using System;

namespace XtronV2
{
    class Program
    {
        static void Main(string[] args)
        {
            //GÖR OM PROGRAM UTAN SPAGHETTI
            Console.WindowHeight = Console.LargestWindowHeight - 10;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;

            var GM = new Game();
            GM.StartGame();

            Console.Clear();
            Console.WriteLine("EXIT");
            Console.ReadLine();
        }
    }
}
