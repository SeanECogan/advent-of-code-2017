using AdventOfCode2017.Day9.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day9.Test.PuzzleA
{
    [TestClass]
    public class StreamProcessorTest
    {
        [TestMethod]
        public void ScoreGroups_OneGroup_Returns1()
        {
            string inputStream = "{}";

            int expected = 1;

            int actual = StreamProcessor.ScoreGroups(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScoreGroups_ThreeNestedGroups_Returns6()
        {
            string inputStream = "{{{}}}";

            int expected = 6;

            int actual = StreamProcessor.ScoreGroups(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScoreGroups_ThreeNestedGroupsTwoAtSameLevel_Returns5()
        {
            string inputStream = "{{},{}}";

            int expected = 5;

            int actual = StreamProcessor.ScoreGroups(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScoreGroups_ManyNestedGroups_Returns16()
        {
            string inputStream = "{{{},{},{{}}}}";

            int expected = 16;

            int actual = StreamProcessor.ScoreGroups(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScoreGroups_OneGroupWithNestedGarbage_Returns1()
        {
            string inputStream = "{<a>,<a>,<a>,<a>}";

            int expected = 1;

            int actual = StreamProcessor.ScoreGroups(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScoreGroups_ManyNestedGroupsWithGarbage_Returns9()
        {
            string inputStream = "{{<ab>},{<ab>},{<ab>},{<ab>}}";

            int expected = 9;

            int actual = StreamProcessor.ScoreGroups(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScoreGroups_ManyNestedGroupsWithCancellingGarbage_Returns9()
        {
            string inputStream = "{{<!!>},{<!!>},{<!!>},{<!!>}}";

            int expected = 9;

            int actual = StreamProcessor.ScoreGroups(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScoreGroups_LotsOfCancelledGroups_Returns3()
        {
            string inputStream = "{{<a!>},{<a!>},{<a!>},{<ab>}}";

            int expected = 3;

            int actual = StreamProcessor.ScoreGroups(inputStream);

            Assert.AreEqual(expected, actual);
        }
    }
}