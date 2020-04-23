using System;
using System.Collections.Generic;

namespace Napier_ConnectFour_Csharp
{
    public class Game
    {
        private int[,] board; // uniform 2D array, which looks like a grid/matrix
        private readonly int _boardRows;
        private readonly int _boardColumns;
        private readonly int _maxMoves;

        private const char _pieceLabelP1 = 'x';
        private const char _pieceLabelP2 = 'o';

        private int movesCounter = 1;
        private Stack<Move> movesHistory;
        private bool gameEnded = false;

        public Game(int boardRows, int boardColumns)
        {
            _boardRows = boardRows;
            _boardColumns = boardColumns;
            _maxMoves = _boardColumns * _boardRows;
        }

        public void Start()
        {
            board = new int[_boardColumns, _boardRows];
            movesHistory = new Stack<Move>();
            Run();
        }

        private void Run()
        {
            bool player1move = true;
            DisplayBoard();

        ContinueGame:
            while (!gameEnded)
            {

                Console.Write($"\nMove #{movesCounter} >> Now is turn (moves): ");
                if (player1move)
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
                                if (AddPiece(chosenColumnNumber, player1move))
                                {
                                    columnNumberOK = true;

                                    DisplayBoard();

                                    player1move = !player1move; // flip the boolean flag to swap players move
                                    movesCounter++;

                                    // check here for winning conditions
                                    //if yes -> Quit
                                    // if not -> Continue
                                    if (movesCounter > _maxMoves)
                                    {
                                        movesHistory.TrimExcess(); // this sets the Stack size/capacity to only used length of the underlying array

                                        Console.WriteLine("There are no more moves available - it is a DRAW!");

                                        PrintBothStackAndQueue();

                                        //Program.ReplaysList.Add(new GameRecord { Date = DateTime.Now.Date, MovesHistory = ConvertStackIntoQueue(movesHistory), Result = GameResult.draw });
                                        gameEnded = true;
                                    }
                                    else
                                    {
                                        //goto ContinueGame;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("\nColumn full! Please choose column with available slot for a new piece!");
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
            //save moves history

            Console.WriteLine("\n>> GG! Good game!");
            UI.GoBackToMainMenu();

        }

        private void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine($"\nBoard {_boardRows}x{_boardColumns}   Maximum moves: {_maxMoves}\n");

            // for each row display a piece symbol (inside cell brackets) of each column
            for (int row = 0; row < _boardRows; row++)
            {
                Console.Write("    "); // <- board's left margin

                for (int column = 0; column < _boardColumns; column++)
                {
                    Console.Write('[');

                    var piece = board[column, row];
                    if (piece == 1)
                    {
                        Console.Write(_pieceLabelP1);
                    }
                    else if (piece == 2)
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
            Console.Write("    "); // <- board's left margin
            for (int column = 0; column < _boardColumns; column++)
            {
                Console.Write(' ');
                Console.Write(column + 1);
                Console.Write(' ');
            }
            Console.Write(' ');

            Console.WriteLine();
        }

        private bool AddPiece(int column, bool player1move)
        {
            column--; // -1 as chosen (displayed) column number is 1 bigger than corresponding array index, e.g. first column (1) has index [0]
            for (var row = _boardRows - 1; row >= 0; row--)
            {
                if (board[column, row] == 0)
                {
                    board[column, row] = player1move ? 1 : 2; // if player1 moves assign 1, else its player2 move so assign 2

                    // record valid move
                    movesHistory.Push(new Move(board[column, row], column, row));

                    return true;
                }
            }
            return false;
        }

        // Warning: This method will destroy the stack, but will return the queue.
        private Queue<Move> ConvertStackIntoQueue(Stack<Move> stack)
        {
            var queue = new Queue<Move>();
            var tempArray = new Move[stack.Count];

            while (stack.Count > 0) // <- change to while stack.Count and [stack.Count]
            {
                tempArray[stack.Count - 1] = stack.Pop();
            }

            for (var j = 0; j < tempArray.Length; j++)
            {
                queue.Enqueue(tempArray[j]);
            }

            return queue;
        }

        private void PrintBothStackAndQueue()
        {
            // Experiment: list Queue vs Stack
            //var stack = movesHistory;
            var stackArray = new Move[movesHistory.Count];

            movesHistory.CopyTo(stackArray, 0);

            var stack = new Stack<Move>();
            for (int k = 0; k < stackArray.Length; k++)
            {
                stack.Push(stackArray[k]);
            }

            var queue = ConvertStackIntoQueue(movesHistory);
            var elems = queue.Count;

            Console.WriteLine("\n Stack + Queue");
            Console.WriteLine(" ===== + =====");
            for (int i = 0; i < elems; i++)
            {
                var s = stack.Pop();
                var q = queue.Dequeue();
                Console.WriteLine($" [{s.BoardColumn},{s.BoardRow}] | [{q.BoardColumn},{q.BoardRow}]");
            }
            Console.WriteLine(" ===== + =====");

        }

    }
}
