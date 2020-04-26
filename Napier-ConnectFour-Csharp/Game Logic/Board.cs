using System;
using System.Collections.Generic;
using System.Text;

namespace Napier_ConnectFour_Csharp
{
    public class Board
    {
        public int[,] Cells { get; private set; } // uniform 2D array, which looks like a grid/matrix; that's "the" content of the board
        public readonly int Columns;
        public readonly int Rows;
        private readonly int SamePiecesToWin;

        public readonly char Player1piece = 'x';
        public readonly char Player2piece = 'o';

        public Board(int columns, int rows, int samePiecesToWin)
        {
            Columns = columns;
            Rows = rows;
            Cells = new int[columns, rows];
            SamePiecesToWin = samePiecesToWin;
        }

        public void AddMove(Move move)
        {
            Cells[move.BoardColumn, move.BoardRow] = move.Player;
        }

        public void UndoMove(Move move)
        {
            Cells[move.BoardColumn, move.BoardRow] = 0;
        }

        public int NextAvailableRow(int column)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (Cells[column, row] == 0)
                {
                    return row;
                }
            }
            return -1;
        }

        // *** win algorithm *** //

        public bool hasWinningMove(Move move)
        {
            //var winningPieces = new Stack<Move>();


            // CHECK VERTICAL (COLUMNS)
            int samePieceCounter = 0;
            int column = move.BoardColumn;
            int row = move.BoardRow;

            // check same column > move through rows > direction: UP (row--)
            while (row >= 0 && Cells[column, row] == move.Player)
            {
                samePieceCounter++;
                if (samePieceCounter == SamePiecesToWin) { return true; }
                row--;
            }

            row = move.BoardRow + 1; //reset row position to current move and jump to next one (to ommit counting again current move's position )

            // check same column > move through rows > direction: DOWN (row++)
            while (row < Rows && Cells[column, row] == move.Player)
            {
                samePieceCounter++;
                if (samePieceCounter == SamePiecesToWin) { return true; }
                row++;
            }


            // CHECK HORIZONTAL (ROWS)
            samePieceCounter = 0; // reset counter & cell position
            column = move.BoardColumn;
            row = move.BoardRow;

            // check same row > move through columns > direction: LEFT (column--)
            while (column >= 0 && Cells[column, row] == move.Player)
            {
                samePieceCounter++;
                if (samePieceCounter == SamePiecesToWin) { return true; }
                column--;
            }

            column = move.BoardColumn + 1; //reset column position to current move and jump to next one (to ommit counting again current move's position)

            // check same row > move through columns > direction: RIGHT (column++)
            while (column < Columns && Cells[column, row] == move.Player)
            {
                samePieceCounter++;
                if (samePieceCounter == SamePiecesToWin) { return true; }
                column++;
            }


            // CHECK DIAGONAL
            samePieceCounter = 0; // reset counter & cell position
            column = move.BoardColumn;
            row = move.BoardRow;

            // check diagonal > direction: UP (row--) LEFT (column--)
            while (row >= 0 && column >= 0 && Cells[column, row] == move.Player)
            {
                samePieceCounter++;
                if (samePieceCounter == SamePiecesToWin) { return true; }
                row--;
                column--;
            }

            row = move.BoardRow + 1; //reset row position to current move and jump to next one (to ommit counting again current move's position) +1 as row++ now
            column = move.BoardColumn + 1; //reset column position to current move and jump to next one (to ommit counting again current move's position) +1 as column++ now

            // check diagonal > opposite direction: DOWN (row++) RIGHT (column++)
            while (row < Rows && column < Columns && Cells[column, row] == move.Player)
            {
                samePieceCounter++;
                if (samePieceCounter == SamePiecesToWin) { return true; }
                row++;
                column++;
            }


            // CHECK ANTIDIAGONAL
            samePieceCounter = 0; // reset counter & cell position
            column = move.BoardColumn;
            row = move.BoardRow;

            // check antidiagonal > direction: UP (row--) RIGHT (column++)
            while (row >= 0 && column < Columns && Cells[column, row] == move.Player)
            {
                samePieceCounter++;
                if (samePieceCounter == SamePiecesToWin) { return true; }
                row--;
                column++;
            }

            row = move.BoardRow + 1; //reset row position to current move and jump to next one (to ommit counting again current move's position) +1 as row++ now
            column = move.BoardColumn - 1; //reset column position to current move and jump to next one (to ommit counting again current move's position) -1 as column-- now

            // check antidiagonal > opposite direction: DOWN (row++) LEFT (column--)
            while (row < Rows && column >= 0 && Cells[column, row] == move.Player)
            {
                samePieceCounter++;
                if (samePieceCounter == SamePiecesToWin) { return true; }
                row++;
                column--;
            }


            return false;
        }

        public void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine($"\nBoard {Rows}x{Columns}   Maximum moves: {Cells.Length}\n");

            // for each row display a piece symbol (inside cell brackets) of each column
            for (int row = 0; row < Rows; row++)
            {
                Console.Write("    "); // <- board's left margin

                for (int column = 0; column < Columns; column++)
                {
                    Console.Write('[');

                    var piece = Cells[column, row];
                    if (piece == 1)
                    {
                        Console.Write(Player1piece);
                    }
                    else if (piece == 2)
                    {
                        Console.Write(Player2piece);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                    Console.Write(']');
                }
                Console.WriteLine(' ');
            }

            // display column's numbering
            Console.Write("    "); // <- board's left margin
            for (int column = 0; column < Columns; column++)
            {
                Console.Write(' ');
                Console.Write(column + 1);
                Console.Write(' ');
            }
            Console.Write(' ');

            Console.WriteLine();
        }
    }
}
