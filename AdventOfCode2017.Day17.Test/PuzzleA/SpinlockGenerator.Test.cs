using AdventOfCode2017.Day17.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day17.Test.PuzzleA
{
    [TestClass]
    public class SpinlockGeneratorTest
    {
        [TestMethod]
        public void GetShortCircuitValue_StepNumberIs3_Returns638()
        {
            int stepNumber = 3;

            int expected = 638;

            int actual = SpinlockGenerator.GetShortCircuitValue(stepNumber);

            Assert.AreEqual(expected, actual);
        }
    }
}