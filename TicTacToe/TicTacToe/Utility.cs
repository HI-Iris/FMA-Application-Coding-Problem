using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class Utility
    {
        //Check if the input from a player is a validated coordinate
        public static bool isValid(string command)
        {
            bool valid = Regex.IsMatch(command, @"^[1-3],[1-3]$");
            return valid;
        }
    }
}
