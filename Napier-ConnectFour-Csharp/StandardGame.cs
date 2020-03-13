using System;

namespace Napier_ConnectFour_Csharp
{
    public static class StandardGame
    {
        public static void Run()
        {
            Console.WriteLine("You are about to run the Standard Game!\n Press any key to continue...");
            DisplayGrid();
            Console.WriteLine("Choose the column: 1~5");
            char key = Console.ReadKey(true).KeyChar;
            
            while (char.ToLower(key) != 'x')
            {
                DisplayGrid();
                Console.WriteLine("Choose...");
                key = Console.ReadKey(true).KeyChar;
            }
            Console.WriteLine("\n>> GG! Good game!");
            UI.GoBackToMainMenu();
        }

        public static void DisplayGrid()
        {
            Console.WriteLine();
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine("  1  2  3  4  5  6  7  ");
            Console.WriteLine();
        }
    }
}
