using NUnit.Framework;

namespace TicTacToeTests
{
    [TestFixture()]
    public class UtilityTests
    {
        [Test()]
        [TestCase("1,1", true)]
        [TestCase("1,3", true)]
        [TestCase("4,4", false)]
        [TestCase("xyz", false)]
        [TestCase("11", false)]
        public void isValidTest(string command, bool expectIsValid)
        {
            var result = TicTacToe.Utility.isValid(command);
            Assert.AreEqual(expectIsValid, result);
        }
    }
}