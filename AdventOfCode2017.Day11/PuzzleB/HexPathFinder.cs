using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day11.PuzzleB
{
    public static class HexPathFinder
    {
        public static int FindFurthestDistanceEver(string directions)
        {
            Dictionary<string, int> directionCounts = new Dictionary<string, int>();

            List<string> allDirections = directions.Split(',').ToList();

            int furthestDistance = 0;

            Console.Clear();

            for (int i = 0; i < allDirections.Count; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Checking distance for step {i + 1} of {allDirections.Count}...");

                int distance = ReduceDirections(allDirections.Take(i + 1).ToList()).Count;

                if (distance > furthestDistance)
                {
                    furthestDistance = distance;
                }
            }

            return furthestDistance;
        }

        private static List<string> ReduceDirections(List<string> directions)
        {
            List<string> reducedDirections = new List<string>();

            // Do reducing.
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "n":
                        if (reducedDirections.Any(d => d == "se"))
                        {
                            reducedDirections.Remove("se");
                            reducedDirections.Add("ne");
                        }
                        else if (reducedDirections.Any(d => d == "s"))
                        {
                            reducedDirections.Remove("s");
                        }
                        else if (reducedDirections.Any(d => d == "sw"))
                        {
                            reducedDirections.Remove("sw");
                            reducedDirections.Add("nw");
                        }
                        else
                        {
                            reducedDirections.Add("n");
                        }
                        break;

                    case "ne":
                        if (reducedDirections.Any(d => d == "s"))
                        {
                            reducedDirections.Remove("s");
                            reducedDirections.Add("se");
                        }
                        else if (reducedDirections.Any(d => d == "sw"))
                        {
                            reducedDirections.Remove("sw");
                        }
                        else if (reducedDirections.Any(d => d == "nw"))
                        {
                            reducedDirections.Remove("nw");
                            reducedDirections.Add("n");
                        }
                        else
                        {
                            reducedDirections.Add("ne");
                        }
                        break;

                    case "se":
                        if (reducedDirections.Any(d => d == "sw"))
                        {
                            reducedDirections.Remove("sw");
                            reducedDirections.Add("s");
                        }
                        else if (reducedDirections.Any(d => d == "nw"))
                        {
                            reducedDirections.Remove("nw");
                        }
                        else if (reducedDirections.Any(d => d == "n"))
                        {
                            reducedDirections.Remove("n");
                            reducedDirections.Add("ne");
                        }
                        else
                        {
                            reducedDirections.Add("se");
                        }
                        break;

                    case "s":
                        if (reducedDirections.Any(d => d == "nw"))
                        {
                            reducedDirections.Remove("nw");
                            reducedDirections.Add("sw");
                        }
                        else if (reducedDirections.Any(d => d == "n"))
                        {
                            reducedDirections.Remove("n");
                        }
                        else if (reducedDirections.Any(d => d == "ne"))
                        {
                            reducedDirections.Remove("ne");
                            reducedDirections.Add("se");
                        }
                        else
                        {
                            reducedDirections.Add("s");
                        }
                        break;

                    case "sw":
                        if (reducedDirections.Any(d => d == "n"))
                        {
                            reducedDirections.Remove("n");
                            reducedDirections.Add("nw");
                        }
                        else if (reducedDirections.Any(d => d == "ne"))
                        {
                            reducedDirections.Remove("ne");
                        }
                        else if (reducedDirections.Any(d => d == "se"))
                        {
                            reducedDirections.Remove("se");
                            reducedDirections.Add("s");
                        }
                        else
                        {
                            reducedDirections.Add("sw");
                        }
                        break;

                    case "nw":
                        if (reducedDirections.Any(d => d == "ne"))
                        {
                            reducedDirections.Remove("ne");
                            reducedDirections.Add("n");
                        }
                        else if (reducedDirections.Any(d => d == "se"))
                        {
                            reducedDirections.Remove("se");
                        }
                        else if (reducedDirections.Any(d => d == "s"))
                        {
                            reducedDirections.Remove("s");
                            reducedDirections.Add("sw");
                        }
                        else
                        {
                            reducedDirections.Add("sw");
                        }
                        break;

                    default:
                        break;
                }
            }

            if (reducedDirections.Count == directions.Count)
            {
                return reducedDirections;
            }
            else
            {
                return ReduceDirections(reducedDirections);
            }
        }
    }
}