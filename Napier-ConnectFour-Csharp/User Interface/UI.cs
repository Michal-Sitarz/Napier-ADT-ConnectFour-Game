using System;

namespace Napier_ConnectFour_Csharp
{
    public static class UI
    {
        public static void DisplayMainMenu(string message = "")
        {
            Console.Clear();
            Console.WriteLine("\n MENU:");
            Console.WriteLine(" +====+====+=====+====+====+");
            Console.WriteLine(" | 2 players:              |");
            Console.WriteLine(" |  > Play [S]tandard game |");
            Console.WriteLine(" |  > Play [C]ustom game   |");
            Console.WriteLine(" |                         |");
            Console.WriteLine(" | 1 player vs AI          |");
            Console.WriteLine(" |  > Play [A]i game       |");
            Console.WriteLine(" |                         |");
            Console.WriteLine(" |  [R]eplays              |");
            Console.WriteLine(" |  [Q]uit                 |");
            Console.WriteLine(" +====+====+=====+====+====+");

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine("\n>> " + message + " <<\n");
            }

            char key = char.ToLower(Console.ReadKey(true).KeyChar);
            switch (key)
            {
                case 's':
                    GameLauncher.Standard();
                    break;

                case 'c':
                    GameLauncher.Custom();
                    break;

                case 'a':
                    GameLauncher.VersusAI();
                    break;

                case 'r':
                    ReplaysPlayer.Run();
                    break;

                case 'q':
                    Console.WriteLine("Good bye!!!\nPress any key to exit...");
                    ReplaysFileHandler.Save();
                    Console.ReadKey(true);
                    Environment.Exit(0);
                    return;

                default:
                    DisplayMainMenu("Please press the key corresponding to the menu!");
                    break;
            }

        }

    }
}
