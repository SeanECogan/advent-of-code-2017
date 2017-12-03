using AdventOfCode2017.Day3.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day3.Test.PuzzleA
{
    [TestClass]
    public class SpiralCalculatorTest
    {
        [TestMethod]
        public void CalculateDistance_Square1_DistanceIsZero()
        {
            int number = 1;
            int expected = 0;

            int actual = SpiralCalculator.CalculateDistance(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateDistance_Square12_DistanceIsThree()
        {
            int number = 12;
            int expected = 3;

            int actual = SpiralCalculator.CalculateDistance(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateDistance_Square23_DistanceIsTwo()
        {
            int number = 23;
            int expected = 2;

            int actual = SpiralCalculator.CalculateDistance(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateDistance_Square1024_DistanceIsThirtyOne()
        {
            int number = 1024;
            int expected = 31;

            int actual = SpiralCalculator.CalculateDistance(number);

            Assert.AreEqual(expected, actual);
        }
    }
}