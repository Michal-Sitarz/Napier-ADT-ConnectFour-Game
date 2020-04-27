using System;
using System.Collections.Generic;
using System.Threading;

namespace Napier_ConnectFour_Csharp
{
    public class Game
    {
        private Board board;
        private GameRecord record;

        private readonly bool undoMovesAllowed;
        private readonly int MaxMoves;
        private int movesCounter = 1;
        private Stack<Move> movesHistory;
        private bool gameEnded = false;
        bool player1turn = true;

        public Game(bool allowUndo = true, int boardRows = 5, int boardColumns = 7, int samePiecesToWin = 4)
        {
            undoMovesAllowed = allowUndo;
            board = new Board(boardColumns, boardRows, samePiecesToWin);
            MaxMoves = boardColumns * boardRows;
        }

        public void Start()
        {
            movesHistory = new Stack<Move>();

            record = new GameRecord();
            record.Date = DateTime.Now.Date;

            record.BoardColumns = board.Columns;
            record.BoardRows = board.Rows;
            record.ConnectedPiecesToWin = board.ConnectedPiecesToWin;

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
                    else if (undoMovesAllowed && key.Key == ConsoleKey.Backspace)
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
                        if (int.TryParse(key.KeyChar.ToString(), out int chosenColumnNumber)) // assigns number on success
                        {
                            if (chosenColumnNumber > 0 && chosenColumnNumber <= board.Columns)
                            {
                                chosenColumnNumber--; // column's index -1, as chosen column number (displayed for user) is 1 bigger than corresponding array index, e.g. first column (1) has index [0]
                                if (AddMoveEligibleForColumn(chosenColumnNumber))
                                {
                                    // move added -> continue with the game
                                    columnNumberOK = true;

                                    // check here for winning conditions
                                    if (board.hasWinningMove(movesHistory.Peek()))
                                    {
                                        board.DisplayBoard(); // <<<<<<< swap for "flashy" display board after implementation <<<<<<<

                                        int winner = player1turn ? 1 : 2;
                                        Console.WriteLine("\n *** Well done Player {0} ({1})!!! You won!!! Well done! ***\n", winner, player1turn ? board.Player1piece : board.Player2piece);
                                        Thread.Sleep(2000); // suspend any execution for 2 sec to let winning player ENJOY the moment (and prevent hassy quit of the game by pressing any keys) 
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
            record.MovesHistory = ConvertStackIntoQueueLikeArray(movesHistory);

            Program.ReplaysList.Add(record);

            Console.WriteLine("\n>> GG! Good game!\n Press any key to continue to Main Menu...");
            Console.ReadKey();
            UI.DisplayMainMenu();

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


        // Warning: This method will destroy the stack, but will return the queue-like array.
        private Move[] ConvertStackIntoQueueLikeArray(Stack<Move> stack)
        {
            stack.TrimExcess(); // this sets the Stack size/capacity to only used length of the underlying array

            var queueLikeArray = new Move[stack.Count];

            while (stack.Count > 0)
            {
                queueLikeArray[stack.Count - 1] = stack.Pop();
            }
            return queueLikeArray;
        }
    }
}
