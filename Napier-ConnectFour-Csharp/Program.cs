using System;
using System.Collections.Generic;

namespace Napier_ConnectFour_Csharp
{
    class Program
    {
        public static List<GameRecord> ReplaysList = new List<GameRecord>(); 
        /* Disclaimer: I know the line above is bad and dodgy, but if for any reason the File Handler won't be able to store Game's history of moves in a local file,
           at least it will be stored in this global list, so at a single runtime of the app, you'd be able to test the "Replays" functionality to replay the moves of a previously played game(s). */

        private static void Main(string[] args)
        {
            // try loading game history from a local file

            //var ReplaysList = new List<GameRecord>();

            Console.WriteLine("\n ### Welcome in the \"Connect four\" game! ### \n");
            UI.DisplayMainMenu("Press the key shown in the bracket [] to choose an option.");
        }
    }
}
