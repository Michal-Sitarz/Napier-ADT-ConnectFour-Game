using System;

namespace Napier_ConnectFour_Csharp
{
    public class ReplaysPlayer
    {
        public static void Run()
        {
            Console.WriteLine("Replays!");

            DisplayAllReplays();
            Console.ReadKey(); // sort out UI/UX to use this actually: menu first, choosing record ID, then display/replay the game (display updating board)

            UI.GoBackToMainMenu();
        }

        private static void DisplayAllReplays()
        {
            Console.WriteLine("\n History of saved game replays\n");
            Console.WriteLine(" ID  |  Who won?  |   Date     ");
            Console.WriteLine("=====+============+============");

            for (int i = 0; i < Program.ReplaysList.Count; i++)
            {
                GameRecord gr = Program.ReplaysList[i];
                Console.WriteLine($" {(i+1),3} | {gr.Result,9}  | {gr.Date.ToShortDateString()}");
            }

        }

        private static void DisplayMoves(GameRecord game)
        {
            var queue = game.MovesHistory;

            Console.WriteLine($"Game played on: {game.Date.ToLongDateString()} ");
            Console.WriteLine($"Game's winner: {game.Result}");
            
            Console.WriteLine("\n Moves:");
            Console.WriteLine(" =====");
           
            for (int i = 0; i < queue.Count; i++)
            {
                Move m = queue.Dequeue();
                Console.WriteLine($" [{m.BoardColumn},{m.BoardRow}]");
            }
            Console.WriteLine(" =====");

        }
    }
}
