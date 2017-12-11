using AdventOfCode2017.Day11.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day11.Test.PuzzleA
{
    [TestClass]
    public class HexPathFinderTest
    {
        [TestMethod]
        public void FindShortestSteps_AllNE_3Steps()
        {
            string directions = "ne,ne,ne";

            int expected = 3;

            int actual = HexPathFinder.FindShortestSteps(directions);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindShortestSteps_Cancelling_0Steps()
        {
            string directions = "ne,ne,sw,sw";

            int expected = 0;

            int actual = HexPathFinder.FindShortestSteps(directions);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindShortestSteps_Consolidating_2Steps()
        {
            string directions = "ne,ne,s,s";

            int expected = 2;

            int actual = HexPathFinder.FindShortestSteps(directions);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindShortestSteps_MoreConsolidating_3Steps()
        {
            string directions = "se,sw,se,sw,sw";

            int expected = 3;

            int actual = HexPathFinder.FindShortestSteps(directions);

            Assert.AreEqual(expected, actual);
        }
    }
}