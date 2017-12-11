using AdventOfCode2017.Day10.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day10.Test.PuzzleA
{
    [TestClass]
    public class HashGeneratorTest
    {
        [TestMethod]
        public void GenerateHashFromLengths_UsingFiveElementsAndTestLengths_Returns12()
        {
            int numberOfElements = 5;
            string testLengths = "3,4,1,5";

            int expected = 12;

            int actual = HashGenerator.GenerateHashFromLengths(
                numberOfElements, 
                testLengths);

            Assert.AreEqual(expected, actual);
        }
    }
}