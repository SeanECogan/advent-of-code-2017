using AdventOfCode2017.Day22.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day22.Test.PuzzleB
{
    [TestClass]
    public class VirusTrackerTest
    {
        [TestMethod]
        public void CalculateBurstsWithInfection_GivenTestFileAnd100Interations_Returns26()
        {
            string filename = @"Input\testb.txt";
            int iterations = 100;

            int expected = 26;

            int actual = VirusTracker.CalculateBurstsWithInfection(filename, iterations);

            Assert.AreEqual(expected, actual);
        }        
    }
}