using AdventOfCode2017.Day4.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day4.Test.PuzzleB
{
    [TestClass]
    public class FileParserTest
    {
        [TestMethod]
        public void CountValidPassphrases_GivenTestFile_ReturnsThree()
        {
            string filename = @"Input\testb.txt";

            int expected = 3;

            int actual = FileParser.CountValidPassphrases(filename);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("abcde fghij")]
        [DataRow("a ab abc abd abf abj")]
        [DataRow("iiii oiii ooii oooi oooo")]
        public void PassphraseIsValid_ValidPassphrase_ReturnsTrue(string passphrase)
        {
            bool actual = FileParser.PassphraseIsValid(passphrase);

            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("abcde xyz ecdab")]
        [DataRow("oiii ioii iioi iiio")]
        public void PassphraseIsValid_PassphraseContainsAnagrams_ReturnsFalse(string passphrase)
        {
            bool actual = FileParser.PassphraseIsValid(passphrase);

            Assert.IsFalse(actual);
        }
    }
}