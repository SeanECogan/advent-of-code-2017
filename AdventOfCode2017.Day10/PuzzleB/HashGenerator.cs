using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day10.PuzzleB
{
    public static class HashGenerator
    {
        public static string GenerateHash(
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