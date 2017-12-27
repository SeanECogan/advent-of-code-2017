using AdventOfCode2017.Day22.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day22.PuzzleB
{
    public static class VirusTracker
    {
        public static int CalculateBurstsWithInfection(
            string filename,
            int iterations)
        {
            int burstsWithInfection = 0;

            List<string> gridLines = File.ReadAllLines(filename).ToList();

            Dictionary<string, bool> infectedCells = new Dictionary<string, bool>();
            Dictionary<string, bool> weakenedCells = new Dictionary<string, bool>();
            Dictionary<string, bool> flaggedCells = new Dictionary<string, bool>();

            // Read in initial infected values.
            for (int i = 0; i < gridLines.Count; i++)
            {
                for (int j = 0; j < gridLines[i].Length; j++)
                {
                    if (gridLines[i][j] == '#')
                    {
                        infectedCells.Add(j + "," + i, true);
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
                infectedCells.TryGetValue(currentX + "," + currentY, out bool infectedCell);
                weakenedCells.TryGetValue(currentX + "," + currentY, out bool weakenedCell);
                flaggedCells.TryGetValue(currentX + "," + currentY, out bool flaggedCell);

                // If current node is infected, turn to the right and clean it.
                if (infectedCell)
                {
                    currentDirection = Turn(currentDirection, false);

                    infectedCells.Remove(currentX + "," + currentY);
                    flaggedCells.Add(currentX + "," + currentY, true);
                }
                else if (weakenedCell)
                {
                    weakenedCells.Remove(currentX + "," + currentY);
                    infectedCells.Add(currentX + "," + currentY, true);

                    burstsWithInfection++;
                }
                else if (flaggedCell)
                {
                    currentDirection = Reverse(currentDirection);

                    flaggedCells.Remove(currentX + "," + currentY);
                }
                else
                {
                    currentDirection = Turn(currentDirection, true);

                    weakenedCells.Add(currentX + "," + currentY, true);
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

        private static Directions Reverse(Directions currentDirection)
        {
            switch (currentDirection)
            {
                case Directions.Up:
                    return Directions.Down;

                case Directions.Down:
                    return Directions.Up;

                case Directions.Left:
                    return Directions.Right;

                case Directions.Right:
                    return Directions.Left;

                default:
                    return Directions.Up;
            }
        }
    }
}