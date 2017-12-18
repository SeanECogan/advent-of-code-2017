using AdventOfCode2017.Day16.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day16.Test.PuzzleA
{
    [TestClass]
    public class ProgramTrackerTest
    {
        [TestMethod]
        public void TrackProgramPositions_TestSetup_Returnsbaedc()
        {
            string filename = @"Input\testa.txt";
            string initialPrograms = "abcde";

            string expected = "baedc";

            string actual = ProgramTracker.TrackProgramPositions(
                filename,
                initialPrograms);

            Assert.AreEqual(expected, actual);
        }
    }
}