using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        public static void Main(string[] args)
        {
            var myGame = new TicTacToe();
            myGame.gameStart();
        }
    }
}
