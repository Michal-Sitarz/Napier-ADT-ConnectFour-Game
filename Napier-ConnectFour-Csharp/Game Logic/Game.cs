using System;
using System.Reflection.Metadata.Ecma335;

namespace Napier_ConnectFour_Csharp
{
    public class Game
    {
        private bool?[,] board; // uniform 2d array, which looks like a grid
        private readonly int _boardRows;
        private readonly int _boardColumns;
        private const char _pieceLabelP1 = 'x';
        private const char _pieceLabelP2 = 'o';
        private readonly int _maxMoves;
        private int movesCounter = 1;
        private bool gameEnded = false;


        public Game(int boardRows, int boardColumns)
        {
            _boardRows = boardRows;
            _boardColumns = boardColumns;
            _maxMoves = _boardColumns * _boardRows;
        }

        public void Start()
        {
            board = new bool?[_boardColumns, _boardRows];
            Run();
        }

        private void Run()
        {
            bool P1move = true;
            DisplayBoard();

        ContinueGame:
            while (!gameEnded)
            {
                //DisplayBoard();

                Console.Write($"\nMove #{movesCounter} >> Now moves: ");
                if (P1move)
                {
                    Console.WriteLine($"Player 1 ({_pieceLabelP1})");
                }
                else
                {
                    Console.WriteLine($"Player 2 ({_pieceLabelP2})");
                }

                bool columnNumberOK = false;
                while (!columnNumberOK)
                {
                    Console.Write("\nChoose column (using number keys): ");
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape) // give a user chance to quit the game
                    {
                        Console.WriteLine("\n\n!!! Are you sure you want to quit the game? (Y/N)");
                        var keyQuit = Console.ReadKey(true);
                        if (keyQuit.Key == ConsoleKey.Enter || char.ToLower(keyQuit.KeyChar) == 'y')
                        {
                            goto QuitGame;
                        }
                        else
                        {
                            goto ContinueGame;
                        }
                    }
                    else
                    {
                        int chosenColumnNumber;
                        if (int.TryParse(key.KeyChar.ToString(), out chosenColumnNumber))
                        {
                            if (chosenColumnNumber > 0 && chosenColumnNumber <= _boardColumns)
                            {
                                if (AddPiece(chosenColumnNumber, P1move))
                                {
                                    DisplayBoard();

                                    columnNumberOK = true;
                                    P1move = !P1move; // flip the boolean flag to swap players move
                                    movesCounter++;
                                    // check here for winning conditions
                                    //if yes -> Quit
                                    // if not -> Continue
                                    if (movesCounter > _maxMoves)
                                    {
                                        Console.WriteLine("There are no more moves available - it is a DRAW!");
                                        goto QuitGame;
                                    }
                                    else
                                    {
                                        goto ContinueGame;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("\nPlease choose one of the board columns with available slot for a new piece!");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"\nPlease choose one of the board columns (1-{_boardColumns})");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please choose a numeric value!");
                        }
                    }
                }
            }
        QuitGame:
            Console.WriteLine("\n>> GG! Good game!");
            UI.GoBackToMainMenu();

        }

        private void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine($"\nBoard {_boardRows}x{_boardColumns}   Maximum moves: {_maxMoves}\n");

            // for each row display a piece symbol (inside a cell brackets) of each column
            for (int row = 0; row < _boardRows; row++)
            {
                Console.Write(' ');

                for (int column = 0; column < _boardColumns; column++)
                {
                    Console.Write('[');

                    var piece = board[column, row];
                    if (piece == true)
                    {
                        Console.Write(_pieceLabelP1);
                    }
                    else if (piece == false)
                    {
                        Console.Write(_pieceLabelP2);
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
            Console.Write(' ');
            for (int column = 0; column < _boardColumns; column++)
            {
                Console.Write(' ');
                Console.Write(column + 1);
                Console.Write(' ');
            }
            Console.Write(' ');

            Console.WriteLine();
        }

        public bool AddPiece(int column, bool P1move)
        {
            column--; // -1 as chosen(displayed) number is 1 bigger than corresponding array index, e.g. first column (1) has index 0
            for (var row = _boardRows - 1; row >= 0; row--)
            {
                if (board[column, row] == null)
                {
                    board[column, row] = P1move;
                    return true;
                }
            }
            return false;

        }
    }
}
