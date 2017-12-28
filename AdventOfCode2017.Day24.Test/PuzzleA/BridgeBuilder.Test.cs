using AdventOfCode2017.Day24.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day24.Test.PuzzleA
{
    [TestClass]
    public class BridgeBuilderTest
    {
        [TestMethod]
        public void DetermineStrengthOfStrongestBridge_GivenTestFile_Returns31()
        {
            string filename = @"Input\testa.txt";

            int expected = 31;

            int actual = BridgeBuilder.DetermineStrengthOfStrongestBridge(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}
