using AdventOfCode2017.Day11.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day11.Test.PuzzleB
{
    [TestClass]
    public class HexPathFinderTest
    {
        [TestMethod]
        public void FindFurthestDistanceEver_AllNE_3Steps()
        {
            string directions = "ne,ne,ne";

            int expected = 3;

            int actual = HexPathFinder.FindFurthestDistanceEver(directions);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindFurthestDistanceEver_Cancelling_2Steps()
        {
            string directions = "ne,ne,sw,sw";

            int expected = 2;

            int actual = HexPathFinder.FindFurthestDistanceEver(directions);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindFurthestDistanceEver_Consolidating_2Steps()
        {
            string directions = "ne,ne,s,s";

            int expected = 2;

            int actual = HexPathFinder.FindFurthestDistanceEver(directions);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindFurthestDistanceEver_MoreConsolidating_3Steps()
        {
            string directions = "se,sw,se,sw,sw";

            int expected = 3;

            int actual = HexPathFinder.FindFurthestDistanceEver(directions);

            Assert.AreEqual(expected, actual);
        }
    }
}