using AdventOfCode2017.Day3.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day3.Test.PuzzleB
{
    [TestClass]
    public class SpiralCalculatorTest
    {
        [TestMethod]
        public void GetLargerThan_25_26()
        {
            int number = 25;
            int expected = 26;

            int actual = SpiralCalculator.GetLargerThan(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLargerThan_122_133()
        {
            int number = 122;
            int expected = 133;

            int actual = SpiralCalculator.GetLargerThan(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLargerThan_330_351()
        {
            int number = 330;
            int expected = 351;

            int actual = SpiralCalculator.GetLargerThan(number);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLargerThan_747_806()
        {
            int number = 747;
            int expected = 806;

            int actual = SpiralCalculator.GetLargerThan(number);

            Assert.AreEqual(expected, actual);
        }
    }
}