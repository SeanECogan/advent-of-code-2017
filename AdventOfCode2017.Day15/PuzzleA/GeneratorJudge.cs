using System;

namespace AdventOfCode2017.Day15.PuzzleA
{
    public static class GeneratorJudge
    {
        public static int JudgeGenerators(
            long generatorAStartValue,
            long generatorBStartValue,
            long numberOfIterations)
        {
            int matches = 0;

            long generatorAPrevValue = generatorAStartValue;
            long generatorBPrevValue = generatorBStartValue;

            for (int i = 0; i < numberOfIterations; i++)
            {
                generatorAPrevValue = GeneratorANextValue(generatorAPrevValue);
                generatorBPrevValue = GeneratorBNextValue(generatorBPrevValue);

                string aBinaryString = ConvertToBinary(generatorAPrevValue, 32);
                string bBinaryString = ConvertToBinary(generatorBPrevValue, 32);

                string aSecondHalf = aBinaryString.Substring(16);
                string bSecondHalf = bBinaryString.Substring(16);

                if (aSecondHalf == bSecondHalf)
                {
                    matches++;
                }
            }

            return matches;
        }

        private static long GeneratorANextValue(long prevValue)
        {
            return (prevValue * GENERATOR_A_FACTOR) % DIVIDING_FACTOR;
        }

        private static long GeneratorBNextValue(long prevValue)
        {
            return (prevValue * GENERATOR_B_FACTOR) % DIVIDING_FACTOR;
        }

        private static string ConvertToBinary(long value, int len)
        {
            return Convert.ToString(value, 2).PadLeft(len, '0');
        }

        private const long GENERATOR_A_FACTOR = 16807;
        private const long GENERATOR_B_FACTOR = 48271;
        private const long DIVIDING_FACTOR = 2147483647;
    }
}