namespace AdventOfCode2017.Day9.PuzzleB
{
    public static class StreamProcessor
    {
        public static int CountGarbage(string inputStream)
        {
            int garbageCount = 0;
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
                            if (inGarbage)
                            {
                                garbageCount++;
                            }
                            break;

                        case '}': 
                            if (inGarbage)
                            {
                                garbageCount++;
                            }
                            break;

                        case '<':
                            if (!inGarbage)
                            {
                                inGarbage = true;
                            }
                            else
                            {
                                garbageCount++;
                            }
                            break;

                        case '>':
                            inGarbage = false;
                            break;

                        case '!':
                            skipNext = true;
                            break;

                        default:
                            if (inGarbage)
                            {
                                garbageCount++;
                            }
                            break;
                    }
                }
            }

            return garbageCount;
        }
    }
}