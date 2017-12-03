using AdventOfCode2017.Day2.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day2.Test.PuzzleB
{
    [TestClass]
    public class FileParserTest
    {
        [TestMethod]
        public void ComputeFileChecksum_GivenTestFile_ReturnsSum()
        {
            string filename = @"Input\testb.txt";

            int expected = 9;

            int actual = FileParser.ComputeFileChecksum(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}