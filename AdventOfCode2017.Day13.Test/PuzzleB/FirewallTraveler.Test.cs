using AdventOfCode2017.Day13.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day13.Test.PuzzleB
{
    [TestClass]
    public class FirewallTravelerTest
    {
        [TestMethod]
        public void FindShortestDelay_GivenTestFile_Returns10()
        {
            string filename = @"Input\testb.txt";

            int expected = 10;

            int actual = FirewallTraveler.FindShortestDelay(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}