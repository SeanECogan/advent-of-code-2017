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
            int length = numericString.Length;

            for (int i = 0; i < numericString.Length; i++)
            {
                int nextCircularIndex = (i + 1) % length;

                if (numericString[i] == numericString[nextCircularIndex])
                {
                    sum += Convert.ToInt32(char.GetNumericValue(numericString[i]));
                }
            }

            return sum;
        }
    }
}