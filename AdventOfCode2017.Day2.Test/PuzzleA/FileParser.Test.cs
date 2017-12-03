using AdventOfCode2017.Day2.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day2.Test.PuzzleA
{
    [TestClass]
    public class FileParserTest
    {
        [TestMethod]
        public void ComputeFileChecksum_GivenTestFile_ReturnsSum()
        {
            string filename = @"Input\testa.txt";

            int expected = 18;

            int actual = FileParser.ComputeFileChecksum(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}