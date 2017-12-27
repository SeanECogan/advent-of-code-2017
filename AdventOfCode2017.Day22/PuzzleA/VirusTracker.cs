using AdventOfCode2017.Day22.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day22.PuzzleA
{
    public static class VirusTracker
    {
        public static int CalculateBurstsWithInfection(
            string filename,
            int iterations)
        {
            int burstsWithInfection = 0;

            List<string> gridLines = File.ReadAllLines(filename).ToList();

            List<Tuple<int, int>> infectedCells = new List<Tuple<int, int>>();

            // Read in initial infected values.
            for (int i = 0; i < gridLines.Count; i++)
            {
                for (int j = 0; j < gridLines[i].Length; j++)
                {
                    if (gridLines[i][j] == '#')
                    {
                        infectedCells.Add(new Tuple<int, int>(j, i));
                    }
                }
            }

            // Find middle cell.
            int middle = gridLines.Count / 2;
            Directions currentDirection = Directions.Up;
            int currentX = middle;
            int currentY = middle;

            for (int i = 0; i < iterations; i++)
            {
                var infectedCell = infectedCells.FirstOrDefault(c => c.Item1 == currentX && c.Item2 == currentY);

                // If current node is infected, turn to the right and clean it.
                if (infectedCell != null)
                {
                    currentDirection = Turn(currentDirection, false);

                    infectedCells.Remove(infectedCell);
                }
                // If not, turn to the left and infect it.
                else
                {
                    currentDirection = Turn(currentDirection, true);

                    infectedCells.Add(new Tuple<int, int>(currentX, currentY));

                    burstsWithInfection++;
                }

                // Move forward.
                switch (currentDirection)
                {
                    case Directions.Up:
                        currentY--;
                        break;

                    case Directions.Down:
                        currentY++;
                        break;

                    case Directions.Left:
                        currentX--;
                        break;

                    case Directions.Right:
                        currentX++;
                        break;
                }
            }

            return burstsWithInfection;
        }

        private static Directions Turn(
            Directions currentDirection,
            bool turnLeft)
        {
            switch (currentDirection)
            {
                case Directions.Up:
                    return turnLeft ? Directions.Left : Directions.Right;

                case Directions.Down:
                    return turnLeft ? Directions.Right : Directions.Left;

                case Directions.Left:
                    return turnLeft ? Directions.Down : Directions.Up;

                case Directions.Right:
                    return turnLeft ? Directions.Up : Directions.Down;

                default:
                    return Directions.Up;
            }
        }
    }
}