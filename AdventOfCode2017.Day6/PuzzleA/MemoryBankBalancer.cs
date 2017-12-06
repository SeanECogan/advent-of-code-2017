using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day6.PuzzleA
{
    public static class MemoryBankBalancer
    {
        public static int GetIterationsBeforeDuplicateState(string memoryBankString)
        {
            int iterations = 0;

            List<int> memoryBanks = memoryBankString.Split(null)
                                                    .Select(b => Convert.ToInt32(b))
                                                    .ToList();

            bool anyDuplicates = false;

            HashSet<string> pastStates = new HashSet<string>();

            pastStates.Add(string.Join("", memoryBanks));

            while (!anyDuplicates)
            {
                iterations++;

                // Find index of highest number of blocks.
                int indexOfMax = GetIndexOfMostBlocks(memoryBanks);

                // Perform the redistribution.
                int blocksToDistribute = memoryBanks[indexOfMax];

                memoryBanks[indexOfMax] = 0;

                int indexOffset = 1;

                while (blocksToDistribute > 0)
                {
                    memoryBanks[(indexOfMax + indexOffset) % memoryBanks.Count]++;

                    blocksToDistribute--;
                    indexOffset++;
                }

                // Attempt to add the state to the pastStates set. 
                // If it fails, we have found a duplicate.
                if (!pastStates.Add(string.Join("", memoryBanks)))
                {
                    anyDuplicates = true;
                }
            }

            return iterations;
        }

        private static int GetIndexOfMostBlocks(List<int> memoryBanks)
        {
            int max = memoryBanks.Max();

            return memoryBanks.IndexOf(max);
        }
    }
}