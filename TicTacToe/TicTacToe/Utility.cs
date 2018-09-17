using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Utility
    {
        //Check if the input from a player is a validated coordinate
        public static bool IsCoord(string command)
        {
            return Regex.IsMatch(command, @"^[1-3],[1-3]$");
        }
    }
}
