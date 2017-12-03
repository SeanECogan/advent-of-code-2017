using AdventOfCode2017.Common.Misc;
using System;
using System.Collections.Generic;

namespace AdventOfCode2017.Day3.PuzzleB
{
    public static class SpiralCalculator
    {
        public static int GetLargerThan(int number)
        {
            int currentNumber = 1;
            _numbers = new Dictionary<Tuple<int, int>, int>();

            SpiralDirection currentDirection = SpiralDirection.Right;
            int currentRing = 0;
            int currentX = 0;
            int currentY = 0;

            while (currentNumber <= number)
            {
                // Add current number to dictionary.
                _numbers.Add(new Tuple<int, int>(currentX, currentY), currentNumber);

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

                currentNumber = GetSumOfNeighborsForCurrentNumber(currentX, currentY);
            }

            return currentNumber;
        }
        
        /// <summary>
        /// Attempts to get all numbers surrounding the position specified.
        /// This could definitely be refactored.
        /// </summary>
        /// <param name="currentX">X position in the spiral.</param>
        /// <param name="currentY">Y position in the spiral.</param>
        /// <returns>New number to add.</returns>
        private static int GetSumOfNeighborsForCurrentNumber(int currentX, int currentY)
        {
            int sum = 0;

            int topLeft = 0;

            if (_numbers.TryGetValue(new Tuple<int, int>(currentX - 1, currentY + 1), out topLeft))
            {
                sum += topLeft;
            }

            int top = 0;

            if (_numbers.TryGetValue(new Tuple<int, int>(currentX, currentY + 1), out top))
            {
                sum += top;
            }

            int topRight = 0;

            if (_numbers.TryGetValue(new Tuple<int, int>(currentX + 1, currentY + 1), out topRight))
            {
                sum += topRight;
            }

            int left = 0;

            if (_numbers.TryGetValue(new Tuple<int, int>(currentX - 1, currentY), out left))
            {
                sum += left;
            }

            int right = 0;

            if (_numbers.TryGetValue(new Tuple<int, int>(currentX + 1, currentY), out right))
            {
                sum += right;
            }

            int bottomLeft = 0;

            if (_numbers.TryGetValue(new Tuple<int, int>(currentX - 1, currentY - 1), out bottomLeft))
            {
                sum += bottomLeft;
            }

            int bottom = 0;

            if (_numbers.TryGetValue(new Tuple<int, int>(currentX, currentY - 1), out bottom))
            {
                sum += bottom;
            }

            int bottomRight = 0;

            if (_numbers.TryGetValue(new Tuple<int, int>(currentX + 1, currentY - 1), out bottomRight))
            {
                sum += bottomRight;
            }

            return sum;
        }

        private static Dictionary<Tuple<int, int>, int> _numbers;
    }
}