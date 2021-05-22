using System;
using XtronF; //XtronFunctions

namespace XtronV2
{
    class Game
    {
        public Player Hero1 = new Player("", PlayerClass.Warrior);

        public void StartGame()
        {
            


            //STARTMENY
            GameMenues.GenerateHeader();
            
            var MenuSelect = GameMenues.StartMenuSelect();
            Console.WriteLine(MenuSelect);


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



            
            Console.ReadLine();


        }
        
    }
}
