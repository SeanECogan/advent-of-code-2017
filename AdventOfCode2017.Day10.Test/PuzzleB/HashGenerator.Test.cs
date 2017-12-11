using AdventOfCode2017.Day10.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day10.Test.PuzzleB
{
    [TestClass]
    public class HashGeneratorTest
    {
        [TestMethod]
        public void GenerateHash_EmptyString()
        {
            string inputString = "";

            string expected = "a2582a3a0e66e6e86e3812dcb672a272";

            string actual = HashGenerator.GenerateHash(inputString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateHash_AoC_2017()
        {
            string inputString = "AoC 2017";

            string expected = "33efeb34ea91902bb2f59c9920caa6cd";

            string actual = HashGenerator.GenerateHash(inputString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateHash_1_2_3()
        {
            string inputString = "1,2,3";

            string expected = "3efbe78a8d82f29979031a4aa0b16a9d";

            string actual = HashGenerator.GenerateHash(inputString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateHash_1_2_4()
        {
            string inputString = "1,2,4";

            string expected = "63960835bcdc130f0b66d7ff4f6a5a8e";

            string actual = HashGenerator.GenerateHash(inputString);

            Assert.AreEqual(expected, actual);
        }
    }
}