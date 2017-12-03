using AdventOfCode2017.Common.Misc;
using System;

namespace AdventOfCode2017.Day3.PuzzleA
{
    public static class SpiralCalculator
    {
        public static int CalculateDistance(int number)
        {
            int distance = 0;

            SpiralDirection currentDirection = SpiralDirection.Right;
            int currentRing = 0;
            int currentX = 0;
            int currentY = 0;

            for (int i = 1; i < number; i++)
            {
                switch (currentDirection)
                {
                    case SpiralDirection.Up:
                        if (currentY < currentRing)
                        {
                            currentY++;
                        }
                        else
                        {
                            currentDirection = SpiralDirection.Left;
                            currentX--;
                        }
                        break;

                    case SpiralDirection.Left:
                        if (currentX > -currentRing)
                        {
                            currentX--;
                        }
                        else
                        {
                            currentDirection = SpiralDirection.Down;
                            currentY--;
                        }
                        break;

                    case SpiralDirection.Down:
                        if (currentY > -currentRing)
                        {
                            currentY--;
                        }
                        else
                        {
                            currentDirection = SpiralDirection.Right;
                            currentX++;
                        }
                        break;
                    
                    case SpiralDirection.Right:
                        if (currentX < currentRing)
                        {
                            currentX++;
                        }
                        else
                        {
                            currentRing++;
                            currentX = currentRing;
                            currentDirection = SpiralDirection.Up;
                        }
                        break;
                }
            }

            distance = Math.Abs(currentX) + Math.Abs(currentY);

            return distance;
        }
    }
}