using System;
using System.Collections.Generic;

namespace Napier_ConnectFour_Csharp
{
    class Program
    {
        public static List<GameRecord> ReplaysList = new List<GameRecord>();

        private static void Main(string[] args)
        {
            ReplaysFileHandler.Load();
            Console.WriteLine("\n ### Welcome in the \"Connect four\" game! ### \n");
            UI.DisplayMainMenu("Press the key shown in the bracket [] to choose an option.");
        }
    }
}
