using System;
using System.Collections.Generic;

namespace Napier_ConnectFour_Csharp
{
    class Program
    {
        public static List<GameRecord> ReplaysList = new List<GameRecord>(); // save Game replays at runtime
        /* I know that above line is bad and dodgy, but I wanted to make sure you can see some saved games on runtime, in case File Handler will fail */

        private static void Main(string[] args)
        {
            // put UI menu here? nah, maybe not

            Console.WriteLine("\n ### Welcome in the \"Connect four\" game! ### \n");
            UI.DisplayMainMenu("Press the key shown in the bracket [] to choose an option.");
        }
    }
}
