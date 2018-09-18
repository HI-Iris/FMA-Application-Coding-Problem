using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Referee
    {
        //Check if the input from a player is a validated coordinate, range from 1-3
        public static bool IsValidCoord(string command)
        {
            return Regex.IsMatch(command, @"^[1-3],[1-3]$");
        }

        //Check whether there is a piece placed on the entered coordinate, if not, return true to next step
        public bool CanPlace(GameBoard ticBoard, List<Player> players)
        {
            if (ticBoard.Board[ticBoard.InputCoordX, ticBoard.InputCoordY] == players[0].PlayerPiece || ticBoard.Board[ticBoard.InputCoordX, ticBoard.InputCoordY] == players[1].PlayerPiece)
            {
                Console.WriteLine(ConstString.PlaceTaken);
                return false;
            }
            Console.WriteLine(ConstString.MoveAccepted);
            return true;
        }

        //Check whether a win situation occurred, return the status, if someone won, break the do-while loop
        public bool IsWin(string[,] currentBoard, int maxNumOfRowsX, int maxNumOfColsY)
        {
            for (var i = 0; i < maxNumOfRowsX; i++)
            {
                for (var j = 0; j < maxNumOfColsY; j++)
                {
                    if (currentBoard[i, j] == ConstString.DefaultBoard) continue;

                    if ((i + 2 < maxNumOfRowsX && currentBoard[i, j] == currentBoard[i + 1, j] && currentBoard[i, j] == currentBoard[i + 2, j]) ||
                        (j + 2 < maxNumOfColsY && currentBoard[i, j] == currentBoard[i, j + 1] && currentBoard[i, j] == currentBoard[i, j + 2]) ||
                        (i + 2 < maxNumOfRowsX && j + 2 < maxNumOfColsY && currentBoard[i, j] == currentBoard[i + 1, j + 1] && currentBoard[i, j] == currentBoard[i + 2, j + 2]) ||
                        (i - 2 >= 0 && j + 2 < maxNumOfColsY && currentBoard[i, j] == currentBoard[i - 1, j + 1] && currentBoard[i, j] == currentBoard[i - 2, j + 2]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
