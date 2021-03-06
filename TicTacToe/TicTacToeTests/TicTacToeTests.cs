﻿using NUnit.Framework;


namespace TicTacToeTests
{
    [TestFixture()]
    public class TicTacToeTests
    {
        //Left column same
        [TestCase("XOOX..X..", true)]
        //Middle column same
        [TestCase(".X..XOOX.", true)]
        //Right column same
        [TestCase("O.X.OX..X", true)]
        //Top row same
        [TestCase("XXXOO....", true)]
        //Middle row same
        [TestCase(".O.XXXO..", true)]
        //Bottom row same
        [TestCase("..OO..XXX", true)]
        //Diagonal left, X win
        [TestCase("X.XOX.XOO", true)]
        //Diagonal left, O win
        [TestCase(".XO.OXO.X", true)]
        //Diagonal right, X win
        [TestCase("X.O.XOO.X", true)]
        //Diagonal right, O win
        [TestCase("OXXXO...O", true)]
        //Draw
        [TestCase("XXOOOXXXO", false)]
        //Draw
        [TestCase("XOOOXXXOO", false)]
        //Draw
        [TestCase("XOXXXOOXO", false)]
        //Draw
        [TestCase("XXOOXXXOO", false)]
        //Draw
        [TestCase("XXOOOXXOX", false)]

        public void RefereeTest(string boardString, bool isWin)
        {
            var ticTest = new TicTacToe.TicTacToe();

            //To simplify the logic, use int to define the board size, rather than MaxX and MaxY
            var myBoard = new string[3, 3];

            //Substring the string in TestCase, generate my board
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    myBoard[i, j] = boardString.Substring(i * 3 + j, 1);
                }
            }

            //Function test
            var result = ticTest.Referee(myBoard);

            //Result
            Assert.AreEqual(isWin, result);
        }
    }
}