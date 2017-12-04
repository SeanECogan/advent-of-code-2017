using AdventOfCode2017.Day4.PuzzleA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day4.Test.PuzzleA
{
    [TestClass]
    public class FileParserTest
    {
        [TestMethod]
        public void CountValidPassphrases_GivenTestFile_ReturnsTwo()
        {
            string filename = @"Input\testa.txt";

            int expected = 2;

            int actual = FileParser.CountValidPassphrases(filename);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PassphraseIsValid_ValidPassphrase_ReturnsTrue()
        {
            string passphrase = "aa bb cc dd ee";

            bool actual = FileParser.PassphraseIsValid(passphrase);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void PassphraseIsValid_PassphraseContainsDuplicates_ReturnsFalse()
        {
            string passphrase = "aa bb cc dd aa";

            bool actual = FileParser.PassphraseIsValid(passphrase);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void PassphraseIsValid_AnotherValidPassphrase_ReturnsTrue()
        {
            string passphrase = "aa bb cc dd aaa";

            bool actual = FileParser.PassphraseIsValid(passphrase);

            Assert.IsTrue(actual);
        }
    }
}