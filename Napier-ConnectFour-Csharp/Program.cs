using System;

namespace Napier_ConnectFour_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n ### Welcome in the \"Connect four\" game! ### \n");
            UI.DisplayMainMenu("Press the key shown in the bracket [] to choose an option.");
            
            /*
            int gridColumns = 7;
            int gridRows = 5;
            var grid = new char[gridColumns, gridRows]; // [7, 5]

            for (int row = 0; row < grid.GetLength(1); row++)
            {
                for (int column = 0; column < grid.GetLength(0); column++)
                {
                    grid[column, row] = ' ';
                }
            }

            grid[0, 0] = 'x'; // "0,0";
            grid[0, 1] = 'x'; // "0,1";
            grid[1, 0] = 'x'; // "1,0";
            grid[1, 1] = 'x'; // "1,1";
            grid[5, 0] = 'x'; // "5,0";
            grid[1, 3] = 'x'; // "1,3";



            Console.WriteLine("<for><for>");
            for (int row = 0; row < grid.GetLength(1); row++)
            {
                Console.Write("\nRow " + (row + 1) + ": ");
                for (int column = 0; column < grid.GetLength(0); column++)
                {
                    Console.Write("[" + grid[column, row] + "]");
                }

            }



            Console.ReadKey();
            */
        }

    }
}
