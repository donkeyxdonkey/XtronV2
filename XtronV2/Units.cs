using System;
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

        public Player(string name, PlayerClass playerClass)
            :base(name)
        {
            PlayerClass = playerClass;
        }

        public static PlayerClass SelectClass()
        {
            var Repeat = false;

            while (true)
            {
                if (Repeat == true) XtronF.XtronFunctions.ClearLine(2);

                Console.Write("SELECT CLASS [");

                for (int i = 0; i < Enum.GetNames(typeof(PlayerClass)).Length; i++)
                {
                    Console.Write($"{i+1}. {(PlayerClass)i}");
                    if (i < Enum.GetNames(typeof(PlayerClass)).Length-1)
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine("]");                
                Console.Write("PLAYER CLASS:>");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int inputint) == true)
                {
                    if (inputint <= Enum.GetNames(typeof(PlayerClass)).Length)
                    {
                        return (PlayerClass)inputint - 1;
                    }
                }

                if (Repeat == false) Repeat = true;
            }
        }

    }
}
