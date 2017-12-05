using AdventOfCode2017.Day5.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day5.Test.PuzzleB
{
    [TestClass]
    public class JumpCalculatorTest
    {
        [TestMethod]
        public void CalculateJumpsToEscape_GivenTestFile_Returns10Steps()
        {
            string filename = @"Input\testb.txt";

            int expected = 10;

            int actual = JumpCalculator.CalculateJumpsToEscape(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}