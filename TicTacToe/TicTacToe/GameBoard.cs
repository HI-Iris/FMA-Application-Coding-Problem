using System;

namespace TicTacToe
{
    public class GameBoard
    {
        public string[,] Board { set; get; }
        public int PieceCount { set; get; }

        public GameBoard(int maxNumOfRowsX, int maxNumOfColsY, string defaultBoard)
        {
            Board = new string[maxNumOfRowsX, maxNumOfColsY];
            for (var i = 0; i < maxNumOfRowsX; i++)
            {
                for (var j = 0; j < maxNumOfColsY; j++)
                {
                    Board[i, j] = defaultBoard;
                }
            }
        }

        public void PrintBoard(string[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
