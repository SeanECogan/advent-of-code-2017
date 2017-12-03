using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017.Day1.PuzzleA;

namespace AdventOfCode2017.Day1.Test.PuzzleA
{
    [TestClass]
    public class NumericStringParserTest
    {
        [TestMethod]
        public void Parse_TwoPairsOfNumbers_ReturnsSum()
        {
            string numericString = "1122";
            var expected = 3;

            var actual = NumericStringParser.Parse(numericString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_AllNumbersSame_ReturnsSum()
        {
            string numericString = "1111";
            var expected = 4;

            var actual = NumericStringParser.Parse(numericString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_NoSameNumbers_ReturnsSum()
        {
            string numericString = "1234";
            var expected = 0;

            var actual = NumericStringParser.Parse(numericString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_FirstAndLastNumberSame_ReturnsSum()
        {
            string numericString = "91212129";
            var expected = 9;

            var actual = NumericStringParser.Parse(numericString);

            Assert.AreEqual(expected, actual);
        }
    }
}