using System;
using System.Collections.Generic;

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
            //var replays = Program.ReplaysList.ToOrderedArray();

            bool gameEnded = false;
            while (!gameEnded)
            {
                Console.Clear();
                Console.WriteLine("\n Replays!\n+=======+");
                Console.WriteLine("\nEnter game's ID number to replay it. Press 'x' and confirm with 'Enter' to go back to Main Menu.");

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
                        DisplayMoves(Program.ReplaysList[replayId - 1]);
                        //DisplayMoves(replays[replayId - 1]);
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

        }

        private static void DisplayMoves(GameRecord game)
        {
            var queue = game.MovesHistory;

            Console.Clear();
            Console.WriteLine($"Game played on: {game.Date.ToLongDateString()} ");
            Console.WriteLine($"Board's size: {game.BoardRows}x{game.BoardColumns}");
            Console.WriteLine($"Game's winner: {game.Result}");

            Console.WriteLine("\n Moves:");
            Console.WriteLine(" =====");

            for (int i = 0; i < queue.Count; i++)
            {
                Move m = queue.Dequeue();
                Console.WriteLine($" [{m.BoardColumn},{m.BoardRow}]");
            }
            Console.WriteLine(" =====");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            DisplayReplaysMenu();
        }
    }
}
