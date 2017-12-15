using AdventOfCode2017.Day15.PuzzleB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2017.Day15.Test.PuzzleB
{
    [TestClass]
    public class GeneratorJudgeTest
    {
        [TestMethod]
        public void JudgeGenerators_AStartIs65_BStartIs8921_1056Iterations_1Pair()
        {
            int generatorAStartValue = 65;
            int generatorBStartValue = 8921;
            int numberOfIterations = 1056;

            int expected = 1;

            int actual = GeneratorJudge.JudgeGenerators(
                generatorAStartValue,
                generatorBStartValue,
                numberOfIterations);

            Assert.AreEqual(expected, actual);
        }
    }
}