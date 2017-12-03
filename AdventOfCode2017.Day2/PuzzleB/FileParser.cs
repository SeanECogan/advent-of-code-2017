using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day2.PuzzleB
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

                int largerNumber = 0;
                int smallerNumber = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (largerNumber > 0)
                    {
                        continue;
                    }

                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (largerNumber > 0)
                        {
                            continue;
                        }

                        if (numbers[i] % numbers[j] == 0)
                        {
                            largerNumber = numbers[i];
                            smallerNumber = numbers[j];
                        }

                        if (numbers[j] % numbers[i] == 0)
                        {
                            largerNumber = numbers[j];
                            smallerNumber = numbers[i];
                        }
                    }
                }

                // Add the even division between the line's largest number and its
                // smallest to the checksum, where these numbers are evenly divisible.
                checksum += largerNumber / smallerNumber;
            }

            return checksum;
        }
    }
}