using AdventOfCode2017.Day7.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day7.Test.PuzzleB
{
    [TestClass]
    public class TowerBuilderTest
    {
        [TestMethod]
        public void FindBalancingWeight_GivenTestFile_Return60()
        {
            string filename = @"Input\testa.txt";

            int expected = 60;

            int actual = TowerBuilder.FindBalancingWeight(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}