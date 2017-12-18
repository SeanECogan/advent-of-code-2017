using System.Collections.Generic;

namespace AdventOfCode2017.Day17.PuzzleA
{
    public static class SpinlockGenerator
    {
        public static int GetShortCircuitValue(int stepNumber)
        {
            List<int> circularArray = new List<int>(2017)
            {
                0
            };

            int currentPosition = 0;

            for (int i = 1; i <= 2017; i++)
            {
                int insertionIndex = (currentPosition + stepNumber) % circularArray.Count + 1;

                if (insertionIndex < circularArray.Count)
                {
                    circularArray.Insert(insertionIndex, i);
                }
                else
                {
                    circularArray.Add(i);
                }

                currentPosition = insertionIndex;
            }

            return circularArray[currentPosition + 1];
        }
    }
}