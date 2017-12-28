using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day23.PuzzleA
{
    public class InstructionProcessor
    {
        public static long GetTimesMulWasUsed(string filename)
        {
            List<string> instructions = File.ReadAllLines(filename).ToList();

            Dictionary<string, long> registers = new Dictionary<string, long>();

            int mulTimes = 0;

            for (long i = 0; i < instructions.Count; i++)
            {
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

                        mulTimes++;
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

            return mulTimes;
        }
    }
}