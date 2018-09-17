using System;
using System.Threading;

namespace TicTacToe
{
    public class TicTacToe : ITicTacToe, IGame
    {
        //Number of rows
        private int MaxX { get; }
        //Number of columns
        private int MaxY { get; }
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
        private string[,] Board { get; }

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
                    Board[i, j] = ConstString.DefaultBoard;
                }
            }
        }

        //Start the game
        public void GameStart()
        {

            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            BoardPrint();
            do
            {
                var isValidCoord = EnterCommand();
                var canPlace = GetCoord(isValidCoord);
                if (canPlace)
                    Place();
                IsWin = Referee(Board);
                if (IsWin) break;
            } while (Count != MaxX * MaxY);

            Console.WriteLine(IsWin ? "Well done you've won the game!\n" : "Draw!\n");

            GameEnd();
        }

        //End the game
        public void GameEnd()
        {
            Console.WriteLine("Application will be closed in 5 seconds:");
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }

        //Print current board
        public void BoardPrint()
        {
            Console.WriteLine("Here's the current board:");
            for (int i = 0; i < MaxX; i++)
            {
                for (int j = 0; j < MaxX; j++)
                {
                    Console.Write(Board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //Promote player to enter the coordinate of piece
        public bool EnterCommand()
        {
            Console.WriteLine((Player == 1) ? "Player 1 enter a coord x,y to place your X or enter 'q' to give up:" : "Player 2 enter a coord x,y to place your O or enter 'q' to give up:");
            Command = Console.ReadLine();
            Console.WriteLine();
            return Utility.IsCoord(Command);
        }

        //Check the command and place piece, if it is a valid coordinate and movement then place the piece, if not, promote the input again
        public bool GetCoord(bool isValidCoord)
        {
            var canPlace = false;
            if (isValidCoord)
            {
                var coord = Command.Split(',');
                CoordX = int.Parse(coord[0]) - 1;
                CoordY = int.Parse(coord[1]) - 1;
                canPlace = CanPlace();
            }
            else if (Command.ToLower() == "q")
            {
                Console.WriteLine("Player " + Player + " give up, game over");
                GameEnd();
            }
            else
            {
                Console.WriteLine("Invalid input.\n");
            }
            return canPlace;
        }

        //Check whether there is a piece placed on the entered coordinate, if not, return true to next step
        public bool CanPlace()
        {
            if (Board[CoordX, CoordY] == ConstString.PlayerOneId || Board[CoordX, CoordY] == ConstString.PlayerTwoId)
            {
                Console.WriteLine("Oh no, a piece is already placed on this place! Try somewhere else...\n");
                return false;
            }
            Console.WriteLine("Move accepted\n");
            return true;
        }

        //Place the piece on board if the movement is acceptable
        //Or return to do-while loop, promote player to input a command again
        //When movement accepted, place the piece, change player, count the number of pieces on board and print board
        //When count = 9, draw situation occurred, break the do-while loop
        public void Place()
        {
            switch (Player)
            {
                case 1:
                    Board[CoordX, CoordY] = ConstString.PlayerOneId;
                    Count++;
                    break;
                default:
                    Board[CoordX, CoordY] = ConstString.PlayerTwoId;
                    Count++;
                    break;
            }
            PlayerChange();
            BoardPrint();
        }

        //Change the player
        public void PlayerChange()
        {
            Player = (Player == 1) ? 2 : 1;
        }

        //Pass the current board to referee(), check whether a win situation occurred, return the status, if someone won, break the do-while loop
        public bool Referee(string[,] currentBoard)
        {
            for (int i = 0; i < MaxX; i++)
            {
                for (int j = 0; j < MaxY; j++)
                {
                    if (currentBoard[i, j] == ConstString.DefaultBoard) continue;

                    if ((i + 2 < MaxX && currentBoard[i, j] == currentBoard[i + 1, j] && currentBoard[i, j] == currentBoard[i + 2, j]) ||
                        (j + 2 < MaxY && currentBoard[i, j] == currentBoard[i, j + 1] && currentBoard[i, j] == currentBoard[i, j + 2]) ||
                        (i + 2 < MaxX && j + 2 < MaxY && currentBoard[i, j] == currentBoard[i + 1, j + 1] && currentBoard[i, j] == currentBoard[i + 2, j + 2]) ||
                        (i - 2 >= 0 && j + 2 < MaxY && currentBoard[i, j] == currentBoard[i - 1, j + 1] && currentBoard[i, j] == currentBoard[i - 2, j + 2]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

