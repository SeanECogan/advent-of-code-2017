using AdventOfCode2017.Day21.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day21.PuzzleA
{
    public static class ArtGenerator
    {
        public static int FindNumberOfOnCells(
            string filename,
            int iterations)
        {
            List<string> grid = new List<string>()
            {
                ".#.",
                "..#",
                "###"
            };

            _instructions = File.ReadAllLines(filename)
                                                  .Select(l => new Instruction(l))
                                                  .ToList();           

            for (int i = 0; i < iterations; i++)
            {
                List<string> newGrid = new List<string>();

                if (grid.Count % 2 == 0)
                {
                    for (int j = 0; j < grid.Count / 2; j++)
                    {
                        for (int k = 0; k < grid[0].Length; k += 2)
                        {
                            List<string> chunk = new List<string>();

                            chunk.Add(grid[j * 2].Substring(k, 2));
                            chunk.Add(grid[(j * 2) + 1].Substring(k, 2));

                            var chunkToAdd = ProcessChunk(chunk);

                            for (int x = 0; x < chunkToAdd.Count; x++)
                            {
                                if (newGrid.Count > (j * 3) + x)
                                {
                                    newGrid[(j * 3) + x] += chunkToAdd[x];
                                }
                                else
                                {
                                    newGrid.Add(chunkToAdd[x]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < grid.Count / 3; j++)
                    {
                        for (int k = 0; k < grid[0].Length; k += 3)
                        {
                            List<string> chunk = new List<string>();

                            chunk.Add(grid[(j * 3)].Substring(k, 3));
                            chunk.Add(grid[(j * 3) + 1].Substring(k, 3));
                            chunk.Add(grid[(j * 3) + 2].Substring(k, 3));

                            var chunkToAdd = ProcessChunk(chunk);
                            
                            for (int x = 0; x < chunkToAdd.Count; x++)
                            {
                                if (newGrid.Count > (j * 4) + x)
                                {
                                    newGrid[(j * 4) + x] += chunkToAdd[x];
                                }
                                else
                                {
                                    newGrid.Add(chunkToAdd[x]);
                                }
                            }
                        }
                    }
                }

                grid = new List<string>(newGrid);
            }

            return grid.Sum(g => g.Count(c => c == '#'));
        }

        private static List<string> ProcessChunk(List<string> chunk)
        {
            List<string> chunkToAdd = null;

            if (chunkToAdd == null)
            {
                var match = _instructions.FirstOrDefault(inst =>
                    Enumerable.SequenceEqual(
                        inst.Input,
                        chunk));

                if (match != null)
                {
                    chunkToAdd = new List<string>(match.Output);
                }
            }

            if (chunkToAdd == null)
            {
                var match = _instructions.FirstOrDefault(inst =>
                    Enumerable.SequenceEqual(
                        inst.Input,
                        FlipHorizontal(chunk)));

                if (match != null)
                {
                    chunkToAdd = new List<string>(match.Output);
                }
            }

            if (chunkToAdd == null)
            {
                var match = _instructions.FirstOrDefault(inst =>
                    Enumerable.SequenceEqual(
                        inst.Input,
                        FlipVertical(chunk)));

                if (match != null)
                {
                    chunkToAdd = new List<string>(match.Output);
                }
            }

            // For each rotation, check all flip permutations.
            for (int i = 1; i < 4; i++)
            {
                // Check no flip.
                if (chunkToAdd == null)
                {
                    var match = _instructions.FirstOrDefault(inst =>
                        Enumerable.SequenceEqual(
                            inst.Input,
                            Rotate(chunk, i)));

                    if (match != null)
                    {
                        chunkToAdd = new List<string>(match.Output);
                    }
                }

                if (chunkToAdd == null)
                {
                    var match = _instructions.FirstOrDefault(inst =>
                        Enumerable.SequenceEqual(
                            inst.Input,
                            FlipVertical(Rotate(chunk, i))));

                    if (match != null)
                    {
                        chunkToAdd = new List<string>(match.Output);
                    }
                }

                if (chunkToAdd == null)
                {
                    var match = _instructions.FirstOrDefault(inst =>
                        Enumerable.SequenceEqual(
                            inst.Input,
                            FlipHorizontal(Rotate(chunk, i))));

                    if (match != null)
                    {
                        chunkToAdd = new List<string>(match.Output);
                    }
                }

                if (chunkToAdd == null)
                {
                    var match = _instructions.FirstOrDefault(inst =>
                        Enumerable.SequenceEqual(
                            inst.Input,
                            Rotate(FlipVertical(chunk), i)));

                    if (match != null)
                    {
                        chunkToAdd = new List<string>(match.Output);
                    }
                }
                
                if (chunkToAdd == null)
                {
                    var match = _instructions.FirstOrDefault(inst =>
                        Enumerable.SequenceEqual(
                            inst.Input,
                            Rotate(FlipHorizontal(chunk), i)));

                    if (match != null)
                    {
                        chunkToAdd = new List<string>(match.Output);
                    }
                }
            }

            return chunkToAdd;
        }

        private static List<string> FlipVertical(List<string> chunk)
        {
            string top = chunk[0];
            string bottom = chunk[chunk.Count - 1];

            List<string> flippedChunk = new List<string>();

            flippedChunk.Add(bottom);

            if (chunk.Count > 2)
            {
                flippedChunk.Add(chunk[1]);
            }

            flippedChunk.Add(top);

            return flippedChunk;
        }

        private static List<string> FlipHorizontal(List<string> chunk)
        {
            List<string> flippedChunk = new List<string>();

            foreach (var line in chunk)
            {
                flippedChunk.Add(string.Join("", line.Reverse()));
            }

            return flippedChunk;
        }

        private static List<string> Rotate(
            List<string> chunk,
            int rotations)
        {
            List<string> rotatedChunk = chunk;

            for (int i = 0; i < rotations; i++)
            {
                rotatedChunk = RotateOnce(rotatedChunk);
            }
            
            return rotatedChunk;
        }

        private static List<string> RotateOnce(List<string> chunk)
        {
            List<string> rotatedChunk = new List<string>();

            if (chunk.Count % 2 == 0)
            {
                rotatedChunk.Add(chunk[1][0].ToString() + chunk[0][0].ToString());
                rotatedChunk.Add(chunk[1][1].ToString() + chunk[0][1].ToString());
            }
            else
            {
                rotatedChunk.Add(chunk[2][0].ToString() + chunk[1][0].ToString() + chunk[0][0].ToString());
                rotatedChunk.Add(chunk[2][1].ToString() + chunk[1][1].ToString() + chunk[0][1].ToString());
                rotatedChunk.Add(chunk[2][2].ToString() + chunk[1][2].ToString() + chunk[0][2].ToString());
            }

            return rotatedChunk;
        }

        private static List<Instruction> _instructions = new List<Instruction>();
    }
}