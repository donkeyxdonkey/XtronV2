using System;
using System.Linq;
using XtronF;
//using System.Collections.Generic;
//using System.Text;

namespace XtronV2
{
    public class Units
    {
        public string Name { get; set; }

        public Units(string name)
        {
            Name = name;
        }
    }

    public enum PlayerClass
    {
        WARRIOR,ARCHER,MAGE,SUMMONER,NINJA
    }


    public class Player : Units
    {

        public PlayerClass PlayerClass { get; set; }
        public int HP { get; set; }
        public int HPcurrent { get; set; }
        public int MP { get; set; }
        public int MPcurrent { get; set; }

        public int STR { get; set; }
        public int INT { get; set; }
        public int AGI { get; set; }

        public Player(string name, PlayerClass playerClass)
            :base(name)
        {
            PlayerClass = playerClass;
            HP = 300;
            MP = 100;

            switch (PlayerClass)
            {
                case PlayerClass.WARRIOR:
                    HP += 100;
                    MP -= 20;
                    break;
                case PlayerClass.ARCHER:
                    HP += 50;
                    MP += 20;
                    break;
                case PlayerClass.MAGE:
                    HP -= 20;
                    MP += 100;
                    break;
                case PlayerClass.SUMMONER:
                    HP -= 30;
                    MP += 120;
                    break;
                case PlayerClass.NINJA:
                    HP += 20;
                    MP += 35;
                    break;
            }

            HPcurrent = HP;
            MPcurrent = MP;
        }

        public static string CorrectLetterOnlyInput()
        {
            var str = "";
            var Repeat = false;

            while (true)
            {
                if (Repeat == true) XtronFunctions.ClearLine(1);

                Console.Write($"\n   PLAYER NAME:>");
                str = Console.ReadLine();

                if (str != "" && str.All(char.IsLetter)) //FIXA SÅ INTE ENTER FLYTTAR NER OM TOM INPUT
                {
                    XtronFunctions.ClearLine(1);
                    Console.WriteLine($"   ADVENTURER {str.ToUpper()}, SELECT YOUR CLASS!\n");
                    return str.ToUpper();
                }

                if (Repeat == false) Repeat = true;
            }
        }

        public static PlayerClass SelectClass()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            while (true)
            {
                for (int i = 0; i < Enum.GetNames(typeof(PlayerClass)).Length; i++)
                {
                    if (i == 0)
                    {                        
                        Console.Write("   >> ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{(PlayerClass)i}");
                    } 
                    else Console.WriteLine($"      {(PlayerClass)i}");     
                }
                
                var ReturnKeyOut = GameMenues.MenuBrowse(5, 3, 18, 25);
                if (ReturnKeyOut <= Enum.GetNames(typeof(PlayerClass)).Length) return (PlayerClass)ReturnKeyOut - 1;

            }


        }

    }
}
