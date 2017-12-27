using AdventOfCode2017.Day22.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day22.Test.PuzzleA
{
    [TestClass]
    public class VirusTrackerTest
    {
        [TestMethod]
        public void CalculateBurstsWithInfection_GivenTestFileAnd7Interations_Returns5()
        {
            string filename = @"Input\testa.txt";
            int iterations = 7;

            int expected = 5;

            int actual = VirusTracker.CalculateBurstsWithInfection(filename, iterations);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateBurstsWithInfection_GivenTestFileAnd70Interations_Returns41()
        {
            string filename = @"Input\testa.txt";
            int iterations = 70;

            int expected = 41;

            int actual = VirusTracker.CalculateBurstsWithInfection(filename, iterations);

            Assert.AreEqual(expected, actual);
        }
    }
}