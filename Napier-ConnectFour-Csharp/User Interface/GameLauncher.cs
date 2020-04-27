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

            var standardGame = new Game();
            standardGame.Start();

        }

        public static void Classic()
        {
            Console.Clear();
            Console.WriteLine("You are about to run the Classic Game!\nNo UNDO moves allowed!!!");
            Console.WriteLine("\nAt any time, press 'Esc' to quit the game.");
            Console.WriteLine("Press any key now to start...");
            Console.ReadKey();

            var standardGame = new Game(false);
            standardGame.Start();

        }

        public static void Bespoke()
        {
            Console.Clear();
            Console.WriteLine("You are about to run the Bespoke (fully-customizable) Game!\n");
            Console.WriteLine("Controls like always - if you'll allow for undo moves, press 'Backspace'");
            Console.WriteLine("\nAt any time, press 'Esc' to quit the game.");
            Console.WriteLine("\nNow, it's time for few customization questions! :) Press any key to start...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Let's specify the size of the board! However, the smallest is 3x3 and biggest is 9x9");

            Console.WriteLine("How many rows?");
            var key = Console.ReadKey().KeyChar;
            if (!(int.TryParse(key.ToString(), out int rows)))
            {
                Console.WriteLine("You didn't specify the right number... Let's try again!");

                Console.WriteLine("Press any key to start over...");
                Console.ReadKey();
                Bespoke();
            }

            Console.WriteLine("How many columns?");
            key = Console.ReadKey().KeyChar;
            if (!(int.TryParse(key.ToString(), out int columns)))
            {
                Console.WriteLine("You didn't specify the right number... Let's try again!");

                Console.WriteLine("Press any key to start over...");
                Console.ReadKey();
                Bespoke();
            }

            int piecesConnected = 4;
            if (rows > 2 && rows <= 9 && columns > 2 && columns <= 9)
            {
                Console.WriteLine("How many same pieces connected inline together to win?");
                key = Console.ReadKey().KeyChar;
                if (!(int.TryParse(key.ToString(), out piecesConnected)))
                {
                    Console.WriteLine("We needed a number here... Default is 4 then.");
                }
            }
            else
            {
                Console.WriteLine("Remember, the smallest board can be 3x3 and biggest can only be 9x9!");

                Console.WriteLine("Press any key to start over...");
                Console.ReadKey();
                Bespoke();
            }

            bool allowUndo;
            Console.WriteLine("Allow UNDO moves? [Y/N]");
            key = Console.ReadKey().KeyChar;
            if (char.ToLower(key) == 'n')
            {
                allowUndo = false;
            }
            else
            {
                allowUndo = true;
            }
            var game = new Game(allowUndo, rows, columns, piecesConnected);
            game.Start();

        }

        public static void VersusAI()
        {

        }

    }
}
