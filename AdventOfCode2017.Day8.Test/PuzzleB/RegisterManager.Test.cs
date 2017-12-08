using AdventOfCode2017.Day8.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day8.Test.PuzzleB
{
    [TestClass]
    public class RegisterManagerTest
    {
        [TestMethod]
        public void FindLargestValueEver_WithTestFile_Returns1()
        {
            string filename = @"Input\testb.txt";

            int expected = 10;

            int actual = RegisterManager.FindLargestValueEver(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}