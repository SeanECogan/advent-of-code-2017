using AdventOfCode2017.Day20.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day20.Test.PuzzleB
{
    [TestClass]
    public class ParticleSimulatorTest
    {
        [TestMethod]
        public void FindNumberOfNonCollisions_GivenTestFile_Returns1()
        {
            string filename = @"Input\testb.txt";

            int expected = 1;

            int actual = ParticleSimulator.FindNumberOfNonCollisions(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}