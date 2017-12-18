using AdventOfCode2017.Day18.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day18.Test.PuzzleB
{
    [TestClass]
    public class InstructionProcessorTest
    {
        [TestMethod]
        public void GetNumberOfValuesSent_GivenTestFile_Returns3()
        {
            string filename = @"Input\testb.txt";

            long expected = 3;

            long actual = InstructionProcessor.GetNumberOfValuesSent(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}