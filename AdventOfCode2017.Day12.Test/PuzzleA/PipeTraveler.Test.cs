using AdventOfCode2017.Day12.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day12.Test.PuzzleA
{
    [TestClass]
    public class PipeTravelerTest
    {
        [TestMethod]
        public void FindConnectionsToZero_GivenTestFile_Returns6()
        {
            string filename = @"Input\testa.txt";

            int expected = 6;

            int actual = PipeTraveler.FindConnectionsToZero(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}