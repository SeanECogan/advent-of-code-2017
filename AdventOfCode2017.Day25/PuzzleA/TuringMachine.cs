using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day25.PuzzleA
{
    public static class TuringMachine
    {
        public static long GetDiagnosticChecksum(long steps)
        {
            Dictionary<long, int> tape = new Dictionary<long, int>();
            long cursor = 0;
            char state = 'A';

            for (int i = 0; i < steps; i++)
            {
                // Get current value.
                if (!tape.TryGetValue(cursor, out int cursorValue))
                {
                    cursorValue = 0;
                    tape[cursor] = 0;
                }

                if (cursorValue == 0)
                {
                    switch (state)
                    {
                        case 'A':
                            tape[cursor] = 1;
                            cursor++;
                            state = 'B';
                            break;

                        case 'B':
                            tape[cursor] = 1;
                            cursor--;
                            state = 'A';
                            break;

                        case 'C':
                            tape[cursor] = 1;
                            cursor++;
                            state = 'A';
                            break;

                        case 'D':
                            tape[cursor] = 1;
                            cursor--;
                            state = 'E';
                            break;

                        case 'E':
                            tape[cursor] = 1;
                            cursor++;
                            state = 'F';
                            break;

                        case 'F':
                            tape[cursor] = 1;
                            cursor++;
                            state = 'A';
                            break;
                    }
                }
                else
                {
                    switch (state)
                    {
                        case 'A':
                            tape[cursor] = 0;
                            cursor--;
                            state = 'C';
                            break;

                        case 'B':
                            tape[cursor] = 1;
                            cursor++;
                            state = 'C';
                            break;

                        case 'C':
                            tape[cursor] = 0;
                            cursor--;
                            state = 'D';
                            break;

                        case 'D':
                            tape[cursor] = 1;
                            cursor--;
                            state = 'C';
                            break;

                        case 'E':
                            tape[cursor] = 1;
                            cursor++;
                            state = 'A';
                            break;

                        case 'F':
                            tape[cursor] = 1;
                            cursor++;
                            state = 'E';
                            break;
                    }
                }
            }

            return tape.Values.Sum();
        }
    }
}