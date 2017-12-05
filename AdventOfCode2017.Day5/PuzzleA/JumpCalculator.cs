using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day5.PuzzleA
{
    public static class JumpCalculator
    {
        public static int CalculateJumpsToEscape(string filename)
        {
            int jumps = 0;

            int currentIndex = 0;

            var instructions = File.ReadAllLines(filename).Select(s => Convert.ToInt32(s)).ToArray();

            while (currentIndex < instructions.Length)
            {
                int nextJump = instructions[currentIndex];

                instructions[currentIndex]++;

                jumps++;

                currentIndex += nextJump;
            }

            return jumps;
        }
    }
}