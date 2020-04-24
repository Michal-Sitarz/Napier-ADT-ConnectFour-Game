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

        private const int samePiecesToWin = 4;
        public readonly char Player1piece = 'x';
        public readonly char Player2piece = 'o';

        public Board(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            Cells = new int[columns, rows];
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

        public bool isWinningMove(Move move)
        {
            int samePieceCounter = 1;
            int startColumn = move.BoardColumn;
            int startRow = move.BoardRow;
            int[] winningPieces = new int[samePiecesToWin];


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
