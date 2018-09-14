using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game : IGame
    {
        private int flag { set; get; }
        private int coordX { set; get; }
        private int coordY { set; get; }
        private int player { set; get; }
        private int count { set; get; }
        private string[,] board { set; get; }

        public Game()
        {
            flag = 1;
            coordX = -1;
            coordY = -1;
            player = 1;
            count = 0;
            board = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ". ";
                }
            }
        }

        public void gameStart()
        {
            Console.WriteLine("Welcome to Tic Tac Toe! ");
            boardPrint();
            do
            {
                bool inputCheck = inputCoord();
                place(inputCheck);
                flag = referee();
            }
            while (flag == 1);
            if (count == 9 && flag == 2)
            {
                Console.WriteLine("Draw!");
            }
            else
            {
                Console.WriteLine("Well done you've won the game! ");
            }
            closeApp();
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
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }



        //Get the coordinate of piece
        public bool inputCoord()
        {
            coordX = -1;
            coordY = -1;
            bool move = false; ;
            if (player == 1)
            {
                Console.WriteLine("Player 1 enter a coord x,y to place your X or enter 'q' to give up:");
            }
            else
            {
                Console.WriteLine("Player 2 enter a coord x,y to place your O or enter 'q' to give up:");
            }
            string command = Console.ReadLine();
            bool valid = Utility.isValid(command);
            if (valid)
            {
                string[] coord = command.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                coordX = int.Parse(coord[0]) - 1;
                coordY = int.Parse(coord[1]) - 1;
                move = checkMove();
            }
            else if (command == "q" || command == "Q")
            {
                Console.WriteLine();
                Console.WriteLine("Player " + player + " give up, game over");
                closeApp();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
                move = false;

            }
            return move;
        }

        //Check if the movement is acceptable
        public bool checkMove()
        {
            if (board[coordX, coordY] == "X " || board[coordX, coordY] == "O ")
            {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...");
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

        //Place the piece on board if the movement is acceptable
        public void place(bool moveAccepted)
        {
            if (!moveAccepted) return;
            switch (player)
            {
                case 1:
                    board[coordX, coordY] = "X ";
                    count++;
                    break;
                default:
                    board[coordX, coordY] = "O ";
                    count++;
                    break;
            }
            if (count == 9)
            {
                flag = 2;
            }
            player = playerChange(player);
            boardPrint();
        }

        //Change the player
        public int playerChange(int currentP)
        {
            if (currentP == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        //Check the winner of game
        public int referee()
        {
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ". ")
            {
                flag = 3;
            }
            else if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[2, 0] != ". ")
            {
                flag = 3;
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != ". ")
                {
                    flag = 3;
                }
                else if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != ". ")
                {
                    flag = 3;
                }
            }
            return flag;
        }


        //Close application
        public void closeApp()
        {
            Console.WriteLine();
            Console.WriteLine("Application will be closed in 5 seconds:");
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }

        }
    }
}
