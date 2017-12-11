namespace AdventOfCode2017.Day9.PuzzleA
{
    public static class StreamProcessor
    {
        public static int ScoreGroups(string inputStream)
        {
            int score = 0;
            int currentLayer = 0;
            
            bool inGarbage = false;
            bool skipNext = false;

            foreach (var character in inputStream)
            {
                if (skipNext)
                {
                    skipNext = false;
                }
                else
                {
                    switch (character)
                    {
                        case '{':
                            if (!inGarbage)
                            {
                                currentLayer++;
                            }
                            break;

                        case '}':
                            if (!inGarbage)
                            {
                                score += currentLayer;
                                currentLayer--;
                            }
                            break;

                        case '<':
                            inGarbage = true;
                            break;

                        case '>':
                            inGarbage = false;
                            break;

                        case '!':
                            skipNext = true;
                            break;

                        default:
                            break;
                    }
                }
            }

            return score;
        }
    }
}