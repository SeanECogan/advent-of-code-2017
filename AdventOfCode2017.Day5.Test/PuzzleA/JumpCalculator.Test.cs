using AdventOfCode2017.Day5.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day5.Test.PuzzleA
{
    [TestClass]
    public class JumpCalculatorTest
    {
        [TestMethod]
        public void CalculateJumpsToEscape_GivenTestFile_Returns5Steps()
        {
            string filename = @"Input\testa.txt";

            int expected = 5;

            int actual = JumpCalculator.CalculateJumpsToEscape(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}