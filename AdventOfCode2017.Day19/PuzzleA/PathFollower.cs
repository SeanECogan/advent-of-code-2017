using AdventOfCode2017.Day19.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day19.PuzzleA
{
    public static class PathFollower
    {
        public static string FollowPath(string filename)
        {
            List<string> pathDiagram = File.ReadAllLines(filename).ToList();

            string collectedLetters = string.Empty;

            Directions currentDirection = Directions.Down;
            int currentX = 0;
            int currentY = 0;

            // Find initial entry point.
            currentX = pathDiagram[0].IndexOf('|');

            bool canContinue = true;

            while (canContinue)
            {
                char currentPosition = pathDiagram[currentY][currentX];

                // Continue in current direction.
                if (currentPosition == '|' || currentPosition == '-')
                {
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
                // Need to turn.
                else if (currentPosition == '+')
                {
                    bool neighborFound = false;

                    // If we are heading up or down, we need to turn left or right.
                    if (currentDirection == Directions.Up || currentDirection == Directions.Down)
                    {
                        // Check right.
                        if (currentX < pathDiagram[currentY].Length - 1)
                        {
                            var rightNeighbor = pathDiagram[currentY][currentX + 1];

                            if (rightNeighbor != 32 &&
                                rightNeighbor != '|')
                            {
                                currentDirection = Directions.Right;
                                currentX++;

                                neighborFound = true;
                            }
                        }

                        // Check left.
                        if (currentX > 0 && !neighborFound)
                        {
                            var leftNeighbor = pathDiagram[currentY][currentX - 1];

                            if (leftNeighbor != 32 &&
                                leftNeighbor != '|')
                            {
                                currentDirection = Directions.Left;
                                currentX--;

                                neighborFound = true;
                            }
                        }
                    }
                    // If we are heading left or right, we need to turn up or down.
                    else if (currentDirection == Directions.Left || currentDirection == Directions.Right)
                    {
                        // Check down.
                        if (currentY < pathDiagram.Count - 1)
                        {
                            var downNeighbor = pathDiagram[currentY + 1][currentX];

                            if (downNeighbor != 32 &&
                                downNeighbor != '-')
                            {
                                currentDirection = Directions.Down;
                                currentY++;

                                neighborFound = true;
                            }
                        }

                        // Check up.
                        if (currentY > 0 && !neighborFound)
                        {
                            var upNeighbor = pathDiagram[currentY - 1][currentX];

                            if (upNeighbor != 32 &&
                                upNeighbor != '-')
                            {
                                currentDirection = Directions.Up;
                                currentY--;

                                neighborFound = true;
                            }
                        }
                    }

                    // If we found no neighbors, we cannot continue.
                    if (!neighborFound)
                    {
                        canContinue = false;
                    }
                }
                // Somehow off track.
                else if (currentPosition == 32)
                {
                    canContinue = false;
                }
                // Letter.
                else
                {
                    // Add letter.
                    collectedLetters += currentPosition;

                    // Then continue;
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
            }

            return collectedLetters;
        }
    }
}