using AdventOfCode2017.Day7.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day7.Test.PuzzleA
{
    [TestClass]
    public class TowerBuilderTest
    {
        [TestMethod]
        public void FindBottomProgram_GivenTestFile_Returnstknk()
        {
            string filename = @"Input\testa.txt";

            string expected = "tknk";

            string actual = TowerBuilder.FindBottomProgram(filename);

            Assert.AreEqual(expected, actual);
        }
    }
}