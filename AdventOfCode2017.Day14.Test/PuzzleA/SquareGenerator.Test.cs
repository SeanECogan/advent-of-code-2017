using AdventOfCode2017.Day14.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day14.Test.PuzzleA
{
    [TestClass]
    public class SquareGeneratorTest
    {
        [TestMethod]
        public void FindUsedSquares_GivenTestKey_Returns8108()
        {
            string key = "flqrgnkx";

            int expected = 8108;

            int actual = SquareGenerator.FindUsedSquares(key);

            Assert.AreEqual(expected, actual);
        }
    }
}