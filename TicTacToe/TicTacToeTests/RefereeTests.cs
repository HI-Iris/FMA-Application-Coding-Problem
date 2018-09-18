using NUnit.Framework;
using TicTacToe;


namespace TicTacToeTests
{

    public class RefereeTests
    {
        //Left column same
        [TestCase("XOOX..X..", true)]
        //Middle column same
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

        public void IsWinTest(string boardString, bool isWin)
        {
            Referee ticReferee = new Referee();

            //To simplify the logic, use int to define the board size, rather than MaxX and MaxY
            string[,] myBoard = new string[3, 3];

            //Substring the string in TestCase, generate my board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    myBoard[i, j] = boardString.Substring(i * 3 + j, 1);
                }
            }
            //Function test
            bool result = ticReferee.IsWin(myBoard, 3, 3);
            //Result
            Assert.AreEqual(isWin, result);
        }

        [TestCase("1,1", true)]
        [TestCase("1,3", true)]
        [TestCase("3,2", true)]
        [TestCase("2,2", true)]
        [TestCase("4,4", false)]
        [TestCase("xyz", false)]
        [TestCase("11", false)]
        [TestCase("", false)]
        [TestCase("@#$", false)]
        public void IsValidCoordTest(string command, bool isValid)
        {
            var result = Referee.IsValidCoord(command);
            Assert.AreEqual(isValid, result);
        }
    }
}