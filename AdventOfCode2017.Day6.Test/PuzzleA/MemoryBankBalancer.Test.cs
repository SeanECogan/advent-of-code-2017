using AdventOfCode2017.Day6.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day6.Test.PuzzleA
{
    [TestClass]
    public class MemoryBankBalancerTest
    {
        [TestMethod]
        public void GetIterationsBeforeDuplicateState_TestSetup_Returns5()
        {
            string memoryBankString = "0 2 7 0";

            int expected = 5;

            int actual = MemoryBankBalancer.GetIterationsBeforeDuplicateState(memoryBankString);

            Assert.AreEqual(expected, actual);
        }
    }
}