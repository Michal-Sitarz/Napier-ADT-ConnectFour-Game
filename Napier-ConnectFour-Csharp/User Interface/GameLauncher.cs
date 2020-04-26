using System;

namespace Napier_ConnectFour_Csharp
{
    public static class GameLauncher
    {
        public static void Standard()
        {
            Console.WriteLine("You are about to run the Standard Game!\nTo undo moves, press 'Backspace' or 'Ctrl+Z'\nAt any time, press 'Esc' to quit the game.");
            Console.WriteLine("Press any key to start... Press 'Esc' now to go back to the Main Menu.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Escape)
            {
                UI.DisplayMainMenu();
            }
            else
            {
                var standardGame = new Game(5, 7, 4);
                standardGame.Start();
            }
        }

        public static void Custom()
        {
            Console.WriteLine("You are about to run the Custom Game!\nTo undo moves, press 'Backspace' or 'Ctrl+Z'\nAt any time, press 'Esc' to quit the game.");
            Console.WriteLine("Press any key to start... Press 'Esc' now to go back to the Main Menu.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Escape)
            {
                UI.DisplayMainMenu();
            }
            else
            {
                var game = new Game(3, 3 ,3);
                game.Start();
            }
            
        }

        public static void VersusAI()
        {

        }
    }
}
