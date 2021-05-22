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
        Warrior,Archer,Mage,Summoner,Ninja
    }

    public class Player : Units
    {
        public PlayerClass PlayerClass { get; set; }
        public int HP { get; set; }
        public int HPcurrent { get; set; }
        public int MP { get; set; }
        public int MPcurrent { get; set; }

        public Player(string name, PlayerClass playerClass)
            :base(name)
        {
            PlayerClass = playerClass;
            HP = 300;
            MP = 100;

            switch (PlayerClass)
            {
                case PlayerClass.Warrior:
                    HP += 100;
                    break;
                case PlayerClass.Archer:
                    HP += 50;
                    MP += 20;
                    break;
                case PlayerClass.Mage:
                    HP -= 20;
                    MP += 100;
                    break;
                case PlayerClass.Summoner:
                    HP -= 30;
                    MP += 120;
                    break;
                case PlayerClass.Ninja:
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

                Console.Write("PLAYER NAME:>");
                str = Console.ReadLine();

                if (str != "" && str.All(char.IsLetter)) return str;

                if (Repeat == false) Repeat = true;
            }
        }

        public static PlayerClass SelectClass()
        {

            while (true)
            {

                Console.Write("SELECT CLASS [");
                for (int i = 0; i < Enum.GetNames(typeof(PlayerClass)).Length; i++)
                {
                    Console.Write($"{i+1}. {(PlayerClass)i}");
                    if (i < Enum.GetNames(typeof(PlayerClass)).Length-1) Console.Write(" ");
                }
                Console.WriteLine("]");

                var ReturnKey = XtronFunctions.FindKeyInArray(XtronFunctions.GenerateNumKeyArray(Enum.GetNames(typeof(PlayerClass)).Length));
                var ReturnKeyOut = Convert.ToInt32(ReturnKey.Substring(1, 1));

                if (ReturnKeyOut <= Enum.GetNames(typeof(PlayerClass)).Length)
                {
                    return (PlayerClass)ReturnKeyOut - 1;
                }

            }
        }

    }
}
