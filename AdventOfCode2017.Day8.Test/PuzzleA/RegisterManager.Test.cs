using AdventOfCode2017.Day8.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day8.Test.PuzzleA
{
    [TestClass]
    public class RegisterManagerTest
    {
        [TestMethod]
        public void FindLargestValue_WithTestFile_Returns1()
        {
            string filename = @"Input\testa.txt";

            int expected = 1;

            int actual = RegisterManager.FindLargestValue(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}