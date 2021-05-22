using System;
using XtronF; //XtronFunctions

namespace XtronV2
{
    class Game
    {
        internal void StartGame()
        {
            var NewPlayer = new Player(XtronFunctions.CorrectLetterOnlyInput(), Player.SelectClass());

            Console.WriteLine($"Player Name: {NewPlayer.Name}, Class: {NewPlayer.PlayerClass}");
            Console.ReadLine();            
            
        }

        

    }
}
