using AdventOfCode2017.Day24.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day24.Test.PuzzleB
{
    [TestClass]
    public class BridgeBuilderTest
    {
        [TestMethod]
        public void DetermineStrengthOfLongestBridge_GivenTestFile_Returns19()
        {
            string filename = @"Input\testb.txt";

            int expected = 19;

            int actual = BridgeBuilder.DetermineStrengthOfLongestBridge(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}
