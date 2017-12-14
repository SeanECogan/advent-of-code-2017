using AdventOfCode2017.Day14.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day14.Test.PuzzleB
{
    [TestClass]
    public class SquareGeneratorTest
    {
        [TestMethod]
        public void FindUniqueRegions_GivenTestKey_Returns1242()
        {
            string key = "flqrgnkx";

            int expected = 1242;

            int actual = SquareGenerator.FindUniqueRegions(key);

            Assert.AreEqual(expected, actual);
        }
    }
}