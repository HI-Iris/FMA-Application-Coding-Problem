using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Referee
    {
        /// <summary>
        /// Check if the input from a player is a valid command
        /// </summary>
        /// <param name="command"></param>
        /// <returns>1: valid coord; 2: end game; 3: invalid command</returns>
        public int IsValidCommand(string command)
        {
            if (Regex.IsMatch(command, @"^[1-3],[1-3]$"))
            {
                return 1;
            }
            return command.ToLower() == "q" ? 2 : 3;
        }

        //Check whether there is a piece placed on the entered coordinate, if not, return true to next step
        public bool CanPlace(GameBoard ticBoard, InputCoord ticCoord, List<Player> ticPlayers)
        {
            return ticBoard.Board[ticCoord.CoordX, ticCoord.CoordY] != ticPlayers[0].PlayerPiece && ticBoard.Board[ticCoord.CoordX, ticCoord.CoordY] != ticPlayers[1].PlayerPiece;
        }

        //Check whether a win situation occurred, return the status, if someone won, break the do-while loop
        public bool IsWin(string[,] currentBoard, int maxNumOfRowsX, int maxNumOfColsY, string defaultBoard)
        {
            //Iterate the two-dimensional array (currentBoard[x,y])            
            //Match current element with default value first, if matched, means this element has no piece placed, move to next element
            //Match current element with its next two elements in four directions(east, south, north east, south east)
            //If all three elements have same value, means the three same pieces form a line, someone wins
            //If no match, move to next element, and match again
            //During the matching, make sure that after the calculation the index is still within the range (x<maxNumOfRowsX && y<maxNumOfColsY && x>=0 && y>=0)
            for (var i = 0; i < maxNumOfRowsX; i++)
            {
                for (var j = 0; j < maxNumOfColsY; j++)
                {
                    if (currentBoard[i, j] == defaultBoard) continue;
                    //South, currentBoard[x,y], currentBoard[x+1,y] and currentBoard[x+2,y]
                    if (i + 2 < maxNumOfRowsX && currentBoard[i, j] == currentBoard[i + 1, j] && currentBoard[i, j] == currentBoard[i + 2, j])
                    {
                        return true;
                    }
                    //East, currentBoard[x,y], currentBoard[x,y+1] and currentBoard[x,y+2]
                    if (j + 2 < maxNumOfColsY && currentBoard[i, j] == currentBoard[i, j + 1] && currentBoard[i, j] == currentBoard[i, j + 2])
                    {
                        return true;
                    }
                    //South east, currentBoard[x,y], currentBoard[x+1, y+1] and currentBoard[x+2, y+2]
                    if (i + 2 < maxNumOfRowsX && j + 2 < maxNumOfColsY && currentBoard[i, j] == currentBoard[i + 1, j + 1] && currentBoard[i, j] == currentBoard[i + 2, j + 2])
                    {
                        return true;
                    }
                    //North east, currentBoard[x,y], currentBoard[x-1, y+1] and currentBoard[x-2, y+2]
                    if (i - 2 >= 0 && j + 2 < maxNumOfColsY && currentBoard[i, j] == currentBoard[i - 1, j + 1] && currentBoard[i, j] == currentBoard[i - 2, j + 2])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
