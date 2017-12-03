using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2017.Day1.PuzzleB;

namespace AdventOfCode2017.Day1.Test.PuzzleB
{
    [TestClass]
    public class NumericStringParserTest
    {
        [TestMethod]
        public void Parse_TwoPairsOfNumbers_ReturnsSum()
        {
            string numericString = "1212";
            var expected = 6;

            var actual = NumericStringParser.Parse(numericString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_NoNumbersMatch_ReturnsSum()
        {
            string numericString = "1221";
            var expected = 0;

            var actual = NumericStringParser.Parse(numericString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_OneMatch_ReturnsSum()
        {
            string numericString = "123425";
            var expected = 4;

            var actual = NumericStringParser.Parse(numericString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_MoreMatches_ReturnsSum()
        {
            string numericString = "123123";
            var expected = 12;

            var actual = NumericStringParser.Parse(numericString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Parse_EvenMoreMatches_ReturnsSum()
        {
            string numericString = "12131415";
            var expected = 4;

            var actual = NumericStringParser.Parse(numericString);

            Assert.AreEqual(expected, actual);
        }
    }
}