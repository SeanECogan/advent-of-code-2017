using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day23.PuzzleB
{
    public class InstructionProcessor
    {
        public static void WatchRegisters(string filename)
        {
            List<string> instructions = File.ReadAllLines(filename).ToList();

            Dictionary<string, long> registers = new Dictionary<string, long>
            {
                { "a", 1 },
                { "b", 0 },
                { "c", 0 },
                { "d", 0 },
                { "e", 0 },
                { "f", 0 },
                { "g", 0 },
                { "h", 0 },
            };

            Console.Clear();

            for (long i = 0; i < instructions.Count; i++)
            {
                Console.SetCursorPosition(0, 0);

                foreach (var kvp in registers)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                }

                List<string> instructionParts = instructions[Convert.ToInt32(i)].Split(null).ToList();

                switch (instructionParts[0])
                {
                    case "set":
                        // Set value of register.
                        long setValue;
                        bool setIsNumeric = long.TryParse(instructionParts[2], out setValue);

                        if (!setIsNumeric)
                        {
                            bool setRegisterExists = registers.TryGetValue(instructionParts[2], out long setRegisterValue);

                            if (setRegisterExists)
                            {
                                setValue = setRegisterValue;
                            }
                        }

                        registers[instructionParts[1]] = setValue;
                        break;

                    case "sub":
                        // Subtract value from register.
                        long subValue;
                        bool subIsNumeric = long.TryParse(instructionParts[2], out subValue);

                        if (!subIsNumeric)
                        {
                            bool subRegisterExists = registers.TryGetValue(instructionParts[2], out long subRegisterValue);

                            if (subRegisterExists)
                            {
                                subValue = subRegisterValue;
                            }
                        }

                        long subTargetRegisterValue;

                        bool subTargetRegisterExists = registers.TryGetValue(instructionParts[1], out subTargetRegisterValue);

                        if (subTargetRegisterExists)
                        {
                            registers[instructionParts[1]] -= subValue;
                        }
                        else
                        {
                            registers[instructionParts[1]] = subValue;
                        }
                        break;

                    case "mul":
                        // Multiply value and set in register.
                        long mulValue;
                        bool mulIsNumeric = long.TryParse(instructionParts[2], out mulValue);

                        if (!mulIsNumeric)
                        {
                            bool mulRegisterExists = registers.TryGetValue(instructionParts[2], out long mulRegisterValue);

                            if (mulRegisterExists)
                            {
                                mulValue = mulRegisterValue;
                            }
                        }

                        long mulTargetRegisterValue;

                        bool mulTargetRegisterExists = registers.TryGetValue(instructionParts[1], out mulTargetRegisterValue);

                        if (mulTargetRegisterExists)
                        {
                            registers[instructionParts[1]] *= mulValue;
                        }
                        else
                        {
                            registers[instructionParts[1]] = 0;
                        }
                        break;

                    case "jnz":
                        // Jump to the specified instruction.
                        long jnzCheckValue;
                        bool jnzCheckIsNumeric = long.TryParse(instructionParts[1], out jnzCheckValue);

                        if (!jnzCheckIsNumeric)
                        {
                            bool jnzCheckRegisterExists = registers.TryGetValue(instructionParts[1], out long jnzCheckRegisterValue);

                            if (jnzCheckRegisterExists)
                            {
                                jnzCheckValue = jnzCheckRegisterValue;
                            }
                        }

                        if (jnzCheckValue != 0)
                        {
                            bool jnzValueIsNumeric = long.TryParse(instructionParts[2], out long jnzValue);

                            if (!jnzValueIsNumeric)
                            {
                                bool jnzRegisterExists = registers.TryGetValue(instructionParts[2], out long jnzRegisterValue);

                                if (jnzRegisterExists)
                                {
                                    jnzValue = jnzRegisterValue;
                                }
                            }

                            i--;
                            i += jnzValue;
                        }
                        break;
                }
            }
        }

        public static int FindCompositesBetweenTwoNumbers(int firstNumber, int secondNumber)
        {
            int compositeCount = 0;

            // This is what the "assembly" code in the input is doing.
            // Every 17 numbers from b to c, it is checking to see if that number is
            // not prime. If it is not prime, then it increments the counter in h.
            for (int i = firstNumber; i <= secondNumber; i += 17)
            {
                for (int j = 2; j < Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        compositeCount++;
                        break;
                    }
                }
            }

            return compositeCount;
        }
    }
}