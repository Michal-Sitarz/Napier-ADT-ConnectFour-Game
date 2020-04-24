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
            Console.WriteLine(" |>>   2 players         <<|");
            Console.WriteLine(" |  Play [S]tandard game   |");
            Console.WriteLine(" |  Play [C]ustom game     |");
            Console.WriteLine(" |                         |");
            Console.WriteLine(" |>>   1 player vs AI    <<|");
            Console.WriteLine(" |  Play VS [A]i bot game  |");
            Console.WriteLine(" |                         |");
            Console.WriteLine(" | [R]eplays               |");
            Console.WriteLine(" |  E[x]it                 |");
            Console.WriteLine(" +====+====+=====+====+====+");

            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine("\n>> " + message + " <<\n");
            }

            char key = char.ToLower(Console.ReadKey(true).KeyChar);
            switch (key)
            {
                case 's':
                    var standardGame = new Game(5, 7);
                    standardGame.Start();
                    break;
                case 'a':
                    VersusAiGame.Create();
                    break;

                case 'c':
                    var customGame = new Game(3, 3);
                    customGame.Start();
                    break;

                case 'r':
                    ReplaysPlayer.Run();
                    break;

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
