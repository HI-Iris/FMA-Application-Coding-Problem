using NUnit.Framework;

namespace TicTacToeTests
{
    [TestFixture()]
    public class UtilityTests
    {
        [TestCase("1,1", true)]
        [TestCase("1,3", true)]
        [TestCase("4,4", false)]
        [TestCase("xyz", false)]
        [TestCase("11", false)]
        public void IsCoordTest(string command, bool expectIsValid)
        {
            var result = TicTacToe.Utility.IsCoord(command);
            Assert.AreEqual(expectIsValid, result);
        }
    }
}