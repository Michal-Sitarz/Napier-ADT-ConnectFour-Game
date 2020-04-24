using System;

namespace Napier_ConnectFour_Csharp
{
    public static class StandardGame
    {
        public static void Create()
        {
            Console.WriteLine("You are about to run the Standard Game!\nPress any key to continue... Press 'Esc' to abort.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Escape)
            {
                UI.DisplayMainMenu();
            }
            else
            {
                
            }
        }
    }
}
