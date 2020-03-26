using System;

namespace SpaceportProject
{
    public class MainMenu : MenuDockStarship
    {
        public static void Menu()
        {
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Welcom to the Spaceport, you have to be in starwars movie to park here \n");
                Console.WriteLine("plz enter you name to identify your self \n");
                AccessControl();

                Console.WriteLine("[0] Dock your ship");
                Console.WriteLine("[1] Checkout ship");
                Console.WriteLine("[2] Docking history");
                Console.WriteLine("[3] Exit");

                string option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "0":
                        //ControlParkingspace();
                        break;

                    case "1":
                        CheckingForShips("Luke Skywalker");
                        break;

                    case "2":
                        Console.WriteLine("Option 2");
                        break;

                    case "3":
                        Console.WriteLine("Exit program");
                        Console.ReadKey();
                        menu = false;
                        break;
                }
            }
        }
    }
}