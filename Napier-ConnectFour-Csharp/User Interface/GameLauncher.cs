using System;

namespace Napier_ConnectFour_Csharp
{
    public static class GameLauncher
    {
        public static void Standard()
        {
            Console.Clear();
            Console.WriteLine("You are about to run the Standard Game!\nTo undo moves, press 'Backspace'");
            Console.WriteLine("\nAt any time, press 'Esc' to quit the game.");
            Console.WriteLine("Press any key now to start...");
            Console.ReadKey();

            var standardGame = new Game(5, 7, 4);
            standardGame.Start();

        }

        public static void Classic()
        {
            Console.Clear();
            Console.WriteLine("You are about to run the Classic Game!\nNo UNDO moves allowed!!!");
            Console.WriteLine("\nAt any time, press 'Esc' to quit the game.");
            Console.WriteLine("Press any key now to start...");
            Console.ReadKey();

            var standardGame = new Game(5, 7, 4, false);
            standardGame.Start();

        }

        public static void Bespoke()
        {
            Console.Clear();
            Console.WriteLine("You are about to run the Custom Game!\nTo undo moves, press 'Backspace'");
            Console.WriteLine("\nAt any time, press 'Esc' to quit the game.");
            Console.WriteLine("Press any key now to start...");
            Console.ReadKey();

            var game = new Game(3, 3, 3);
            game.Start();

        }

        public static void VersusAI()
        {

        }

    }
}
