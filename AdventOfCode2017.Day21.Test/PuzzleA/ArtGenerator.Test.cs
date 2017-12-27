using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017.Day21.PuzzleA;

namespace AdventOfCode2017.Day21.Test.PuzzleA
{
    [TestClass]
    public class ArtGeneratorTest
    {
        [TestMethod]
        public void FindNumberOfOnCells_GivenTestFile_Returns12()
        {
            string filename = @"Input\testa.txt";
            int iterations = 2;

            int expected = 12;

            int actual = ArtGenerator.FindNumberOfOnCells(
                filename,
                iterations);

            Assert.AreEqual(expected, actual);
        }
    }
}