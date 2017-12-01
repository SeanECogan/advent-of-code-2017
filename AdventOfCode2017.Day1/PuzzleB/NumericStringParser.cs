using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017.Day1.PuzzleB
{
    public static class NumericStringParser
    {
        /// <summary>
        /// Finds the sum of all digits that match the halfway around the list from each other.
        /// The list is circular, so the digit after the last digit is the first digit in the list.
        /// </summary>
        /// <param name="numericString">List of digits.</param>
        /// <returns>Sum of all digits that match the next digit in the list.</returns>
        public static int Parse(string numericString)
        {
            int sum = 0;
            int length = numericString.Length;
            int halfway = length / 2;

            for (int i = 0; i < numericString.Length; i++)
            {
                int circularHalfway = (i + halfway) % length;

                if (numericString[i] == numericString[circularHalfway])
                {
                    sum += Convert.ToInt32(char.GetNumericValue(numericString[i]));
                }
            }

            return sum;
        }
    }
}
