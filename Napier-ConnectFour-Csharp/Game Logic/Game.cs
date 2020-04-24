using System;
using System.Collections.Generic;

namespace Napier_ConnectFour_Csharp
{
    public class Game
    {
        private Board board;
        private GameRecord record;

        private readonly int MaxMoves;
        private int movesCounter = 1;
        private Stack<Move> movesHistory;
        private bool gameEnded = false;
        bool player1turn = true;

        public Game(int boardRows, int boardColumns)
        {
            board = new Board(boardColumns, boardRows);
            MaxMoves = boardColumns * boardRows;
        }

        public void Start()
        {
            movesHistory = new Stack<Move>();
            record = new GameRecord();
            record.Date = DateTime.Now.Date;
            Run();
        }

        private void Run()
        {
            while (!gameEnded)
            {
                board.DisplayBoard();
                DisplayPlayerTurn();

                bool columnNumberOK = false;
                while (!columnNumberOK)
                {
                    Console.Write("\nChoose column (using number keys): ");
                    var key = Console.ReadKey();
                    // give players chance to quit the game
                    if (key.Key == ConsoleKey.Escape)
                    {
                        record.Result = GameResult.game_quit;
                        gameEnded = true;
                        goto QuitGame;
                    }
                    // give players chance to undo moves
                    else if (key.Key == ConsoleKey.Backspace || (key.Modifiers.HasFlag(ConsoleModifiers.Control) && char.ToLower(key.KeyChar) == 'z'))
                    {
                        if (movesCounter > 1)
                        {
                            var lastMove = movesHistory.Pop();
                            board.UndoMove(lastMove);
                            movesCounter--;
                            player1turn = !player1turn; // revert the next player's turn

                            board.DisplayBoard();
                            DisplayPlayerTurn();
                        }
                        else
                        {
                            Console.WriteLine("No moves to undo... The board is empty!");
                        }
                    }
                    else
                    {
                        int chosenColumnNumber;
                        if (int.TryParse(key.KeyChar.ToString(), out chosenColumnNumber)) // assigns number on success
                        {
                            if (chosenColumnNumber > 0 && chosenColumnNumber <= board.Columns)
                            {
                                chosenColumnNumber--; // column's index -1, as chosen column number (displayed for user) is 1 bigger than corresponding array index, e.g. first column (1) has index [0]
                                if (AddMoveEligibleForColumn(chosenColumnNumber))
                                {
                                    // move added -> continue with the game
                                    columnNumberOK = true;

                                    // check here for winning conditions
                                    if (board.isWinningMove(movesHistory.Peek()))
                                    {
                                        board.DisplayBoard(); // <<<<< swap for "flashy" display board after implementation <<<<<<<<<<

                                        int winner = player1turn ? 1 : 2;
                                        Console.WriteLine("\n *** Well done Player {0} ({1})!!! You won!!! Well done! ***\n", winner, player1turn ? board.Player1piece : board.Player2piece);

                                        record.Result = (GameResult)winner; // casts result for one of the players of last winning move
                                        gameEnded = true;
                                    }
                                    else
                                    {
                                        board.DisplayBoard();
                                        player1turn = !player1turn; // flip the boolean flag to swap players move
                                        movesCounter++;

                                        if (movesCounter > MaxMoves)
                                        {
                                            Console.WriteLine("There are no more moves available - it is a DRAW!");
                                            record.Result = GameResult.draw;
                                            gameEnded = true;
                                        }
                                    }
                                }
                                else { Console.WriteLine("\nColumn full! Please choose column with available slot for a new piece!"); }
                            }
                            else { Console.WriteLine($"\nPlease choose one of the board columns (1-{board.Columns})"); }
                        }
                        else
                        { Console.WriteLine("Please choose a numeric value!"); }
                    }
                }
            }
        QuitGame:
            // add moves history with result and save
            record.MovesHistory = ConvertStackIntoQueue(movesHistory);
            Program.ReplaysList.Add(record);

            Console.WriteLine("\n>> GG! Good game!");
            UI.GoBackToMainMenu();

        }

        private void DisplayPlayerTurn()
        {
            Console.Write($"\nMove #{movesCounter} >> Now turn of: ");
            if (player1turn)
            { Console.WriteLine($"Player 1 ({board.Player1piece})"); }
            else
            { Console.WriteLine($"Player 2 ({board.Player2piece})"); }
        }

        private bool AddMoveEligibleForColumn(int column)
        {
            int row = board.NextAvailableRow(column);
            if (row != -1)
            {
                var move = new Move(column, row, player1turn ? 1 : 2); // adds 1 for player1 turn, 2 for player2
                board.AddMove(move);
                movesHistory.Push(move);
                return true;
            }
            return false;
        }


        // Warning: This method will destroy the stack, but will return the queue.
        private Queue<Move> ConvertStackIntoQueue(Stack<Move> stack)
        {
            stack.TrimExcess(); // this sets the Stack size/capacity to only used length of the underlying array

            var queue = new Queue<Move>();
            var tempArray = new Move[stack.Count];

            while (stack.Count > 0)
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
