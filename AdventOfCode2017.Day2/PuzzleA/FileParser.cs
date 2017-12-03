using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day2.PuzzleA
{
    public static class FileParser
    {
        public static int ComputeFileChecksum(string filename)
        {
            int checksum = 0;

            var fileLines = File.ReadAllLines(filename);

            foreach (var line in fileLines)
            {
                var numbers = line.Split(null)
                                  .Select(n => Convert.ToInt32(n))
                                  .ToArray();

                int largestNumber = numbers.Max();
                int smallestNumber = numbers.Min();

                // Add the difference between the line's largest number and its
                // smallest to the checksum.
                checksum += largestNumber - smallestNumber;
            }

            return checksum;
        }
    }
}