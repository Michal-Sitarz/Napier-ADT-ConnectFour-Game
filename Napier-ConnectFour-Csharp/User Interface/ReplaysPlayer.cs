using System;

namespace Napier_ConnectFour_Csharp
{
    public static class ReplaysPlayer
    {
        public static void Run()
        {
            DisplayReplaysMenu();
        }

        public static void DisplayReplaysMenu()
        {
            bool gameEnded = false;
            while (!gameEnded)
            {
                Console.Clear();
                Console.WriteLine("\n Replays!\n+=======+");
                Console.WriteLine("\nEnter game's ID number to replay it. Press 'Esc' to go back to Main Menu.");

                DisplayReplaysList();
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    gameEnded = true;
                }
                else
                {
                    if (int.TryParse(key.KeyChar.ToString(), out int replayId) && (replayId > 0 && replayId <= Program.ReplaysList.Count))
                    {
                        PlayGame(Program.ReplaysList[replayId - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Please type in number of game ID displayed in the first column.");
                    }
                }
            }
            UI.DisplayMainMenu();
        }

        private static void DisplayReplaysList()
        {
            Console.WriteLine("\n History of saved game replays\n");
            Console.WriteLine(" ID  |  Who won?  |   Date     ");
            Console.WriteLine("=====+============+============");

            for (int i = 0; i < Program.ReplaysList.Count; i++)
            {
                GameRecord gr = Program.ReplaysList[i];
                Console.WriteLine($" {(i + 1),3} | {gr.Result,9}  | {gr.Date.ToShortDateString()}");
            }
        }

        private static void PlayGame(GameRecord game)
        {
            var board = new Board(game.BoardColumns, game.BoardRows, game.ConnectedPiecesToWin);

            Console.Clear();
            Console.WriteLine($"Game played on: {game.Date.ToLongDateString()} ");
            Console.WriteLine($"Board's size: {game.BoardRows}x{game.BoardColumns}");
            Console.WriteLine($"Game variation - same pieces connected inline: {game.ConnectedPiecesToWin}");
            Console.WriteLine($"Game's winner: {game.Result}");

            Console.WriteLine("\n During replay press any key to forward moves.\n");
            Console.WriteLine("Now, press any key to start!");
            Console.ReadKey();

            board.DisplayBoard();
            Console.ReadKey();

            for (int i = 0; i < game.MovesHistory.Length; i++)
            {
                board.AddMove(game.MovesHistory[i]);
                board.DisplayBoard();
                Console.ReadKey();
            }

            Console.WriteLine($"Game's winner: {game.Result}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

    }
}
