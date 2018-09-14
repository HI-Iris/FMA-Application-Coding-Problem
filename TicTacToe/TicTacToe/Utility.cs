using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Utility
    {
        //Check if the input from a player is a validated coordinate
        public static bool isValid(string command)
        {
            bool valid = Regex.IsMatch(command, @"^[1-3],[1-3]$");
            return valid;
        }        
    }
}
