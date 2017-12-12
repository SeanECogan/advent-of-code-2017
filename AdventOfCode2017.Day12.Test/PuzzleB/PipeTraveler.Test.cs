using AdventOfCode2017.Day12.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day12.Test.PuzzleB
{
    [TestClass]
    public class PipeTravelerTest
    {
        [TestMethod]
        public void FindGroups_GivenTestFile_Returns2()
        {
            string filename = @"Input\testa.txt";

            int expected = 2;

            int actual = PipeTraveler.FindGroups(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}