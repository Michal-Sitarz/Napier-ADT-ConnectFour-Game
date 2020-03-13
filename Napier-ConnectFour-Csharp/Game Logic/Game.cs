using System;

namespace Napier_ConnectFour_Csharp
{
    public class Game
    {
        private Piece[,] grid; // uniform 2d array, which looks like a grid

        public Game(int gridColumns, int gridRows)
        {
            grid = new Piece[gridRows, gridColumns];
        }

        public void Run()
        {
            //Console.WriteLine("Choose the column: 1~5");
            Console.WriteLine("GRID: columns = "+grid.GetLength(1));
            Console.WriteLine("GRID: rows = " + grid.GetLength(0)+ "\n+++\n");

            char key = Console.ReadKey(true).KeyChar;
            
            while (char.ToLower(key) != 'x')
            {
                DisplayGrid();

                Console.WriteLine("\nChoose...");
                key = Console.ReadKey(true).KeyChar;
                
            }
            Console.WriteLine("\n>> GG! Good game!");
            UI.GoBackToMainMenu();
        }

        private void DisplayGrid()
        {
            Console.WriteLine();
            
            for(int row=0; row<grid.GetLength(0); row++)
            {
                string gridRowToDisplay = " ";
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    gridRowToDisplay += "[";
                    // TODO: add logic here later @ the context of the cell
                    gridRowToDisplay += " ";
                    gridRowToDisplay += "]";
                }
                gridRowToDisplay = " ";

                Console.WriteLine(gridRowToDisplay);
            }
            

            Console.WriteLine("  1  2  3  4  5  6  7  "); // TODO: change into dynamically generated numbers of columns

            /*
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine(" [ ][ ][ ][ ][ ][ ][ ] ");
            Console.WriteLine("  1  2  3  4  5  6  7  ");
            */
            Console.WriteLine();
        }
    }
}
