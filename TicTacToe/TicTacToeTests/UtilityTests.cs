using NUnit.Framework;
using TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeTests
{
    [TestFixture()]
    public class UtilityTests
    {
        [Test()]
        [TestCase("1,1", true)]
        [TestCase("4,4", false)]
        [TestCase("xyz", false)]
        [TestCase("11", false)]
        public void isValidTest(string command, bool expectIsValid)
        {
            var result = global::TicTacToe.Utility.isValid(command);
            Assert.AreEqual(expectIsValid, result);
        }
    }
}