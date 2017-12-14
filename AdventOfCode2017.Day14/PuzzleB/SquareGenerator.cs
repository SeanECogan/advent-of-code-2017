using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day14.PuzzleB
{
    public static class SquareGenerator
    {
        public static int FindUniqueRegions(string key)
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

            int currentRegion = 0;

            List<List<int>> regions = new List<List<int>>();

            foreach (var binaryString in binaryStrings)
            {
                List<int> emptyList = new List<int>();

                for (int i = 0; i < binaryString.Length; i++)
                {
                    emptyList.Add(0);
                }

                regions.Add(emptyList);
            }

            for (int i = 0; i < binaryStrings.Count; i++)
            {
                for (int j = 0; j < binaryStrings[i].Length; j++)
                {
                    if (binaryStrings[i][j] == '0')
                    {
                        regions[i][j] = 0;
                    }
                    else
                    {
                        if (regions[i][j] == 0)
                        {
                            currentRegion++;

                            foreach (var coordinates in FindAdjacentCoordinates(i, j, binaryStrings, new List<Tuple<int, int>>()))
                            {
                                regions[coordinates.Item1][coordinates.Item2] = currentRegion;
                            }
                        }
                    }
                }
            }

            return currentRegion;
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

        private static List<Tuple<int, int>> FindAdjacentCoordinates(
            int i, 
            int j, 
            List<string> binaryStrings,
            List<Tuple<int, int>> visitedCoordinates)
        {
            List<Tuple<int, int>> coordinates = new List<Tuple<int, int>>();

            if (visitedCoordinates.Any(c => c.Item1 == i && c.Item2 == j))
            {
                return coordinates;
            }

            visitedCoordinates.Add(new Tuple<int, int>(i, j));

            if (binaryStrings[i][j] == '0')
            {
                return coordinates;
            }

            if (binaryStrings[i][j] != '0')
            {
                coordinates.Add(new Tuple<int, int>(i, j));
            }

            // Top neighbor.
            if (i > 0)
            {
                coordinates.AddRange(FindAdjacentCoordinates(i - 1, j, binaryStrings, visitedCoordinates));
            }

            // Bottom neighbor.
            if (i + 1 < binaryStrings.Count)
            {
                coordinates.AddRange(FindAdjacentCoordinates(i + 1, j, binaryStrings, visitedCoordinates));
            }

            // Right neighbor.
            if (j + 1 < binaryStrings[i].Length)
            {
                coordinates.AddRange(FindAdjacentCoordinates(i, j + 1, binaryStrings, visitedCoordinates));
            }

            // Left neighbor.
            if (j > 0)
            {
                coordinates.AddRange(FindAdjacentCoordinates(i, j - 1, binaryStrings, visitedCoordinates));
            }

            return coordinates;
        }
    }
}
