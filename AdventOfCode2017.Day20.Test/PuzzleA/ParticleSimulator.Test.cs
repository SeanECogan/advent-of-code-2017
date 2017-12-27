using AdventOfCode2017.Day20.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day20.Test.PuzzleA
{
    [TestClass]
    public class ParticleSimulatorTest
    {
        [TestMethod]
        public void FindClosestParticle_GivenTestFile_ReturnsParticle0()
        {
            string filename = @"Input\testa.txt";

            int expected = 0;

            int actual = ParticleSimulator.FindClosestParticle(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}