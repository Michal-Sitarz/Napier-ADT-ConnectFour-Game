using System;

namespace Napier_ConnectFour_Csharp
{
    public static class UI
    {
        public static void DisplayMainMenu(string message = "")
        {
            Console.Clear();
            Console.WriteLine("\n MENU:\n ====+====+====");
            Console.WriteLine(" Play [S]tandard game");
            Console.WriteLine(" Play [C]ustom game");
            Console.WriteLine(" [R]eplays");
            Console.WriteLine(" E[x]it");
            Console.WriteLine(" ====+====+====");

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine("\n>> " + message + " <<\n");
            }

            char key = Console.ReadKey(true).KeyChar;
            switch (key)
            {
                case 'S':
                case 's':
                    StandardGame.Run();
                    break;

                case 'C':
                case 'c':
                    CustomGame.Run();
                    break;

                case 'R':
                case 'r':
                    Replays.Run();
                    break;

                case 'X':
                case 'x':
                    Console.WriteLine("Good bye!!!\nPress any key to exit...");
                    Console.ReadKey(true);
                    break;

                default:
                    DisplayMainMenu("Please press the key corresponding to the menu!");
                    break;
            }

        }

        public static void GoBackToMainMenu()
        {
            Console.WriteLine("Press any key to go back to the Main Menu...");
            Console.ReadKey(true);
            DisplayMainMenu();
        }
    }
}
