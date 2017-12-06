using AdventOfCode2017.Day6.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day6.Test.PuzzleB
{
    [TestClass]
    public class MemoryBankBalancerTest
    {
        [TestMethod]
        public void GetIterationsInLoop_TestSetup_Returns4()
        {
            string memoryBankString = "0 2 7 0";

            int expected = 4;

            int actual = MemoryBankBalancer.GetIterationsInLoop(memoryBankString);

            Assert.AreEqual(expected, actual);
        }
    }
}