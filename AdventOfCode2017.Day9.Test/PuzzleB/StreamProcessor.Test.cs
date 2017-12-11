using AdventOfCode2017.Day9.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day9.Test.PuzzleB
{
    [TestClass]
    public class StreamProcessorTest
    {
        [TestMethod]
        public void CountGarbage_NoCharacters_Returns0()
        {
            string inputStream = "<>";

            int expected = 0;

            int actual = StreamProcessor.CountGarbage(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountGarbage_RandomCharacters_Returns17()
        {
            string inputStream = "<random characters>";

            int expected = 17;

            int actual = StreamProcessor.CountGarbage(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountGarbage_ManyCarats_Returns3()
        {
            string inputStream = "<<<<>";

            int expected = 3;

            int actual = StreamProcessor.CountGarbage(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountGarbage_SomeCancelledCharacters_Returns2()
        {
            string inputStream = "<{!>}>";

            int expected = 2;

            int actual = StreamProcessor.CountGarbage(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountGarbage_OneCancelledCharacter_Returns0()
        {
            string inputStream = "<!!>";

            int expected = 0;

            int actual = StreamProcessor.CountGarbage(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountGarbage_AllCancelledCharacters_Returns0()
        {
            string inputStream = "<!!!>>";

            int expected = 0;

            int actual = StreamProcessor.CountGarbage(inputStream);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountGarbage_MiscCharacters_Returns10()
        {
            string inputStream = "<{o\"i!a,<{i<a>";

            int expected = 10;

            int actual = StreamProcessor.CountGarbage(inputStream);

            Assert.AreEqual(expected, actual);
        }
    }
}