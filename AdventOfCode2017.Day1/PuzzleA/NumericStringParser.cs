using System;

namespace AdventOfCode2017.Day1.PuzzleA
{
    public static class NumericStringParser
    {
        /// <summary>
        /// Finds the sum of all digits that match the next digit in the list.
        /// The list is circular, so the digit after the last digit is the first digit in the list.
        /// </summary>
        /// <param name="numericString">List of digits.</param>
        /// <returns>Sum of all digits that match the next digit in the list.</returns>
        public static int Parse(string numericString)
        {
            int sum = 0;

            for (int i = 0; i < numericString.Length; i++)
            {
                // Check for last index.
                if (i + 1 == numericString.Length)
                {
                    if (numericString[i] == numericString[0])
                    {
                        sum += Convert.ToInt32(char.GetNumericValue(numericString[i]));
                    }
                }
                else
                {
                    if (numericString[i] == numericString[i + 1])
                    {
                        sum += Convert.ToInt32(char.GetNumericValue(numericString[i]));
                    }
                }
            }

            return sum;
        }
    }
}