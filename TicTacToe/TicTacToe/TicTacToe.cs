using System;
using System.Threading;

namespace TicTacToe
{
    public class TicTacToe : ITicTacToe, IGame
    {
        private bool IsWin { set; get; }
        //X coordinate, from 1 to 3
        private int CoordX { set; get; }
        //Y coordinate, from 1 to 3
        private int CoordY { set; get; }
        //Two players
        private int Player { set; get; }
        //The number of pieces on the board
        private int Count { set; get; }
        //Player's input
        private string Command { set; get; }
        //Game board
        private string[,] Board { set; get; }

        public TicTacToe()
        {
            IsWin = false;
            CoordX = -1;
            CoordY = -1;
            Player = 1;
            Count = 0;
            Board = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = ". ";
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
                bool inputCheck = inputCoord();
                place(inputCheck);
                referee();
            }
            while (Count != 9);
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
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //Promote player to enter the coordinate of piece
        public void enterCommand()
        {
            if (Player == 1)
            {
                Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up:");
            }
            else
            {
                Console.WriteLine("Player 2 enter a coord x,y to place your O or enter 'q' to give up:");
            }
            Command = Console.ReadLine();
        }

        //Check

        //Check the command and place piece, if it is a valid coordinate and movement then place the piece, if not, promote the input again
        public bool inputCoord()
        {
            CoordX = -1;
            CoordY = -1;
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
            if (Board[CoordX, CoordY] == "X " || Board[CoordX, CoordY] == "O ")
            {
                Console.WriteLine();
                Console.WriteLine("Oh no, a piece is already at this place! Try somewhere else...");
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Move accepted");
                return true;
            }
        }

        //Place the piece on board if the movement is acceptable, count the numbers of pieces on board
        public void place(bool moveAccepted)
        {
            if (!moveAccepted) return;
            switch (Player)
            {
                case 1:
                    Board[CoordX, CoordY] = "X ";
                    Count++;
                    break;
                default:
                    Board[CoordX, CoordY] = "O ";
                    Count++;
                    break;
            }
            Player = playerChange(Player);
            boardPrint();
        }

        //Change the player
        public int playerChange(int currentPlayer)
        {
            if (currentPlayer == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        //Check the winner of game
        public void referee()
        {
            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[0, 0] != ". ")
            {
                IsWin = true;
            }
            else if (Board[2, 0] == Board[1, 1] && Board[1, 1] == Board[0, 2] && Board[2, 0] != ". ")
            {
                IsWin = true;
            }
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2] && Board[i, 0] != ". ")
                {
                    IsWin = true;
                }
                else if (Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i] && Board[0, i] != ". ")
                {
                    IsWin = true;
                }
            }
            if (IsWin)
            {
                Console.WriteLine("Well done you've won the game! ");
                gameEnd();
            }
        }

    }
}
