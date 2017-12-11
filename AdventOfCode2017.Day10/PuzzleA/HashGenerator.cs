using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day10.PuzzleA
{
    public static class HashGenerator
    {
        public static int GenerateHashFromLengths(
            int numberOfElements,
            string lengths)
        {
            int skipValue = 0;
            int currentIndex = 0;

            List<int> elements = Enumerable.Range(0, numberOfElements).ToList();
            List<int> lengthValues = lengths.Split(',').Select(s => Convert.ToInt32(s)).ToList();

            foreach (var lengthValue in lengthValues)
            {
                // Skip any lengths that are larger than the list of elements.
                if (lengthValue > numberOfElements)
                {
                    continue;
                }

                List<int> subset = new List<int>();

                if (currentIndex + lengthValue < numberOfElements)
                {
                    subset = elements.Skip(currentIndex).Take(lengthValue).ToList();
                }
                else
                {
                    int lengthAtStart = currentIndex + lengthValue - numberOfElements;

                    List<int> endSubset = elements.Skip(currentIndex).Take(numberOfElements - currentIndex).ToList();
                    List<int> startSubset = elements.Take(lengthAtStart).ToList();

                    subset.AddRange(endSubset);
                    subset.AddRange(startSubset);
                }

                subset.Reverse();

                for (int i = 0; i < subset.Count; i++)
                {
                    elements[(currentIndex + i) % numberOfElements] = subset[i];
                }

                currentIndex = (currentIndex + lengthValue + skipValue) % numberOfElements;
                skipValue++;
            }

            return elements[0] * elements[1];
        }
    }
}