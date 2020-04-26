using System;
using System.Collections.Generic;

namespace Napier_ConnectFour_Csharp
{
    class Program
    {
        public static List<GameRecord> ReplaysList = new List<GameRecord>(); // save Game replays at runtime
        /* I know it's not a best practice to expose a list this way to any other class/object, but I wanted to make sure you can see some saved games on runtime 
           And if I'd schedule more time for it, I'd implement some local File Handler or local single file database or something... */

        private static void Main(string[] args)
        {
            Console.WriteLine("\n ### Welcome in the \"Connect four\" game! ### \n");
            UI.DisplayMainMenu("Press the key shown in the bracket [] to choose an option.");
        }
    }
}
