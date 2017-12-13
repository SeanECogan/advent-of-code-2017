using AdventOfCode2017.Day13.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day13.Test.PuzzleA
{
    [TestClass]
    public class FirewallTravelerTest
    {
        [TestMethod]
        public void CheckSeverityForPacket_GivenTestFile_Returns24()
        {
            string filename = @"Input\testa.txt";

            int expected = 24;

            int actual = FirewallTraveler.CheckSeverityForPacket(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}