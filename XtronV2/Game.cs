using System;
using System.Diagnostics;
using XtronF; //XtronFunctions

namespace XtronV2
{
    class Game
    {
        public Player Hero1 = new Player("", PlayerClass.WARRIOR);

        public void StartGame()
        {
            //STARTMENY
            GameMenues.GenerateHeader();
            
            var MenuSelect = GameMenues.StartMenuSelect();
            XtronFunctions.ClearLine(7);

            switch (MenuSelect)
            {
                case 1:
                    Hero1 = new Player(Player.CorrectLetterOnlyInput(), Player.SelectClass());
                    Console.WriteLine($"Player Name: {Hero1.Name} Class: {Hero1.PlayerClass} HP: {Hero1.HP}");
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
            }

            XtronFunctions.DelayStringWrite("Quack Quack Quack", 250);
                        
            Console.ReadLine();
                       
        }
        
    }
}
