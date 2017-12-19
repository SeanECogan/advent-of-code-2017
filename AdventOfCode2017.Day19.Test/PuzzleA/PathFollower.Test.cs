using AdventOfCode2017.Day19.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day19.Test.PuzzleA
{
    [TestClass]
    public class PathFollowerTest
    {
        [TestMethod]
        public void FollowPath_GivenTestFile_ReturnsABCDEF()
        {
            string filename = @"Input\testa.txt";

            string expected = "ABCDEF";

            string actual = PathFollower.FollowPath(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}