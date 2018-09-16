using System;
using System.Threading;

namespace TicTacToe
{
    public class TicTacToe : ITicTacToe, IGame
    {
        //Number of rows
        private int MaxX { set; get; }
        //Number of columns
        private int MaxY { set; get; }
        //Check if someone won the game already
        private bool IsWin { set; get; }
        //X coordinate from player's input, range from 1 to MaxX
        private int CoordX { set; get; }
        //Y coordinate from player's input, range from 1 to MaxY
        private int CoordY { set; get; }
        //Define two players
        private int Player { set; get; }
        //The number of pieces on the board
        private int Count { set; get; }
        //Player's input
        private string Command { set; get; }
        //Game board
        private string[,] Board { set; get; }


        public TicTacToe()
        {
            MaxX = 3;
            MaxY = 3;
            IsWin = false;
            CoordX = -1;
            CoordY = -1;
            Player = 1;
            Count = 0;
            Board = new string[MaxX, MaxY];
            for (int i = 0; i < MaxX; i++)
            {
                for (int j = 0; j < MaxY; j++)
                {
                    Board[i, j] = ".";
                }
            }
        }

        //Start the game
        public void gameStart()
        {
            Console.WriteLine("Welcome to Tic Tac Toe! ");
            boardPrint();
            do
            {
                enterCommand();
                place(inputCoord());
                referee();
            } while (Count != MaxX * MaxY);
            Console.WriteLine("Draw!");
            gameEnd();
        }

        //End the game
        public void gameEnd()
        {
            Console.WriteLine();
            Console.WriteLine("Application will be closed in 5 seconds:");
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }

        //Print current board
        public void boardPrint()
        {
            Console.WriteLine();
            Console.WriteLine("Here's the current board:");
            for (int i = 0; i < MaxX; i++)
            {
                for (int j = 0; j < MaxY; j++)
                {
                    Console.Write(Board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //Promote player to enter the coordinate of piece
        public void enterCommand()
        {
            if (Player == 1)
                Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up:");
            else
                Console.WriteLine("Player 2 enter a coord x,y to place your O or enter 'q' to give up:");
            Command = Console.ReadLine();
        }

        //Check the command and place piece, if it is a valid coordinate and movement then place the piece, if not, promote the input again
        public bool inputCoord()
        {
            bool move = false;
            bool valid = Utility.isValid(Command);
            if (valid)
            {
                string[] coord = Command.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                CoordX = int.Parse(coord[0]) - 1;
                CoordY = int.Parse(coord[1]) - 1;
                move = moveAccepted();
            }
            else if (Command.ToLower() == "q")
            {
                Console.WriteLine();
                Console.WriteLine("Player " + Player + " give up, game over");
                gameEnd();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
            }
            return move;
        }

        //Check whether there is a piece placed on the entered coordinate, if not, place the piece
        public bool moveAccepted()
        {
            if (Board[CoordX, CoordY] == "X" || Board[CoordX, CoordY] == "O")
            {
                Console.WriteLine();
                Console.WriteLine("Oh no, a piece is already placed on this place! Try somewhere else...");
                Console.WriteLine();
                return false;
            }

            Console.WriteLine();
            Console.WriteLine("Move accepted");
            return true;
        }

        //Place the piece on board if the movement is acceptable, check if it is a draw situation
        public void place(bool moveAccepted)
        {
            if (!moveAccepted) return;
            switch (Player)
            {
                case 1:
                    Board[CoordX, CoordY] = "X";
                    Count++;
                    break;
                default:
                    Board[CoordX, CoordY] = "O";
                    Count++;
                    break;
            }

            Player = playerChange(Player);
            boardPrint();
        }

        //Change the player
        public int playerChange(int currentPlayer)
        {
            if (currentPlayer == 1) return 2;
            return 1;
        }

        //Check the winner of game
        public void referee()
        {
            for (int i = 0; i < MaxX; i++)
            {
                if (IsWin) break;
                for (int j = 0; j < MaxY; j++)
                {
                    if (Board[i, j] == ".") continue;

                    if ((i + 2 < MaxX && Board[i, j] == Board[i + 1, j] && Board[i, j] == Board[i + 2, j]) ||
                        (j + 2 < MaxY && Board[i, j] == Board[i, j + 1] && Board[i, j] == Board[i, j + 2]) ||
                        (i + 2 < MaxX && j + 2 < MaxY && Board[i, j] == Board[i + 1, j + 1] && Board[i, j] == Board[i + 2, j + 2]) ||
                        (i - 2 > 0 && j + 2 < MaxY && Board[i, j] == Board[i - 1, j + 1] && Board[i, j] == Board[i - 2, j + 2]))
                    {
                        IsWin = true;
                        break;
                    }
                }
            }
            if (!IsWin) return;
            Console.WriteLine("Well done you've won the game! ");
            gameEnd();
        }
    }
}

