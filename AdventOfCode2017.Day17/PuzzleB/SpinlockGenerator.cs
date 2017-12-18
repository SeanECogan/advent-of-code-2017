namespace AdventOfCode2017.Day17.PuzzleB
{
    public static class SpinlockGenerator
    {
        public static int GetShortCircuitValue(int stepNumber)
        {
            int circularArrayCount = 1;

            int currentPosition = 0;

            int numberAfterZero = 0;

            for (int i = 1; i <= 50000000; i++)
            {
                int insertionIndex = (currentPosition + stepNumber) % circularArrayCount + 1;

                if (insertionIndex == 1)
                {
                    numberAfterZero = i;
                }

                circularArrayCount++;

                currentPosition = insertionIndex;
            }

            return numberAfterZero;
        }
    }
}