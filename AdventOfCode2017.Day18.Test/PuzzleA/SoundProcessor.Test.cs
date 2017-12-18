using AdventOfCode2017.Day18.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day18.Test.PuzzleA
{
    [TestClass]
    public class SoundProcessorTest
    {
        [TestMethod]
        public void GetFirstRecoveredFrequency_GivenTestFile_Returns4()
        {
            string filename = @"Input\testa.txt";

            long expected = 4;

            long actual = SoundProcessor.GetFirstRecoveredFrequency(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}