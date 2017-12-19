using AdventOfCode2017.Day19.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day19.Test.PuzzleB
{
    [TestClass]
    public class PathFollowerTest
    {
        [TestMethod]
        public void CountSteps_GivenTestFile_38()
        {
            string filename = @"Input\testb.txt";

            int expected = 38;

            int actual = PathFollower.CountSteps(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}