using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day14.PuzzleA
{
    public static class SquareGenerator
    {
        public static int FindUsedSquares(string key)
        {
            List<string> hashes = new List<string>();

            for (int i = 0; i < 128; i++)
            {
                hashes.Add(GenerateHash(key + "-" + i));
            }

            List<string> binaryStrings = new List<string>();

            foreach (var hash in hashes)
            {
                binaryStrings.Add(string.Join(string.Empty,
                    hash.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))));
            }

            return binaryStrings.Sum(b => b.Count(c => c == '1'));
        }

        private static string GenerateHash(
            string input)
        {
            int skipValue = 0;
            int currentIndex = 0;

            List<int> lengthValues = input.Select(c => Convert.ToInt32(c)).ToList();
            lengthValues.AddRange(new List<int>() { 17, 31, 73, 47, 23 });

            List<int> elements = Enumerable.Range(0, 256).ToList();

            for (int round = 0; round < 64; round++)
            {
                foreach (var lengthValue in lengthValues)
                {
                    List<int> subset = new List<int>();

                    if (currentIndex + lengthValue < elements.Count)
                    {
                        subset = elements.Skip(currentIndex).Take(lengthValue).ToList();
                    }
                    else
                    {
                        int lengthAtStart = currentIndex + lengthValue - elements.Count;

                        List<int> endSubset = elements.Skip(currentIndex).Take(elements.Count - currentIndex).ToList();
                        List<int> startSubset = elements.Take(lengthAtStart).ToList();

                        subset.AddRange(endSubset);
                        subset.AddRange(startSubset);
                    }

                    subset.Reverse();

                    for (int i = 0; i < subset.Count; i++)
                    {
                        elements[(currentIndex + i) % elements.Count] = subset[i];
                    }

                    currentIndex = (currentIndex + lengthValue + skipValue) % elements.Count;
                    skipValue++;
                }
            }

            List<int> denseHash = new List<int>();

            for (int i = 0; i < elements.Count; i += 16)
            {
                int denseHashEntry = 0;

                foreach (var element in elements.Skip(i).Take(16))
                {
                    denseHashEntry = denseHashEntry ^ element;
                }

                denseHash.Add(denseHashEntry);
            }

            string hash = string.Empty;

            foreach (int element in denseHash)
            {
                hash += element.ToString("X2").ToLower();
            }

            return hash;
        }
    }
}
