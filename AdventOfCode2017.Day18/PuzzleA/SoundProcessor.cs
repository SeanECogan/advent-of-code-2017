using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day18.PuzzleA
{
    public static class SoundProcessor
    {
        public static long GetFirstRecoveredFrequency(string filename)
        {
            List<string> instructions = File.ReadAllLines(filename).ToList();

            Dictionary<string, long> registers = new Dictionary<string, long>();

            long lastSoundPlayed = -1;
            bool soundRecovered = false;

            for (long i = 0; i < instructions.Count; i++)
            {
                List<string> instructionParts = instructions[Convert.ToInt32(i)].Split(null).ToList();

                switch (instructionParts[0])
                {
                    case "snd":
                        // Play sound.
                        long sndValue;
                        bool sndIsNumeric = long.TryParse(instructionParts[1], out sndValue);

                        if (sndIsNumeric)
                        {
                            lastSoundPlayed = sndValue;
                        }
                        else
                        {
                            bool sndRegisterExists = registers.TryGetValue(instructionParts[1], out long sndRegisterValue);

                            if (sndRegisterExists)
                            {
                                lastSoundPlayed = sndRegisterValue;
                            }
                        }
                        break;

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

                    case "add":
                        // Add value to register.
                        long addValue;
                        bool addIsNumeric = long.TryParse(instructionParts[2], out addValue);

                        if (!addIsNumeric)
                        {
                            bool addRegisterExists = registers.TryGetValue(instructionParts[2], out long addRegisterValue);

                            if (addRegisterExists)
                            {
                                addValue = addRegisterValue;
                            }
                        }

                        long addTargetRegisterValue;

                        bool addTargetRegisterExists = registers.TryGetValue(instructionParts[1], out addTargetRegisterValue);

                        if (addTargetRegisterExists)
                        {
                            registers[instructionParts[1]] += addValue;
                        }
                        else
                        {
                            registers[instructionParts[1]] = addValue;
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

                    case "mod":
                        // Perform modulus arithmetic and set in register.
                        long modValue;
                        bool modIsNumeric = long.TryParse(instructionParts[2], out modValue);

                        if (!modIsNumeric)
                        {
                            bool modRegisterExists = registers.TryGetValue(instructionParts[2], out long modRegisterValue);

                            if (modRegisterExists)
                            {
                                modValue = modRegisterValue;
                            }
                        }

                        long modTargetRegisterValue;

                        bool modTargetRegisterExists = registers.TryGetValue(instructionParts[1], out modTargetRegisterValue);

                        if (modTargetRegisterExists)
                        {
                            registers[instructionParts[1]] %= modValue;
                        }
                        else
                        {
                            registers[instructionParts[1]] = 0;
                        }
                        break;

                    case "rcv":
                        // Recover last played sound in register.
                        long rcvValue;
                        bool rcvIsNumeric = long.TryParse(instructionParts[1], out rcvValue);

                        if (!rcvIsNumeric)
                        {
                            bool rcvRegisterExists = registers.TryGetValue(instructionParts[1], out long rcvRegisterValue);

                            if (rcvRegisterExists)
                            {
                                rcvValue = rcvRegisterValue;
                            }
                        }

                        if (rcvValue != 0)
                        {
                            soundRecovered = true;
                        }
                        break;

                    case "jgz":
                        // Jump to the specified instruction.
                        long jgzCheckValue;
                        bool jgzCheckIsNumeric = long.TryParse(instructionParts[1], out jgzCheckValue);

                        if (!jgzCheckIsNumeric)
                        {
                            bool jgzCheckRegisterExists = registers.TryGetValue(instructionParts[1], out long jgzCheckRegisterValue);

                            if (jgzCheckRegisterExists)
                            {
                                jgzCheckValue = jgzCheckRegisterValue;
                            }
                        }

                        if (jgzCheckValue > 0)
                        {
                            bool jgzValueIsNumeric = long.TryParse(instructionParts[2], out long jgzValue);

                            if (!jgzValueIsNumeric)
                            {
                                bool jgzRegisterExists = registers.TryGetValue(instructionParts[2], out long jgzRegisterValue);

                                if (jgzRegisterExists)
                                {
                                    jgzValue = jgzRegisterValue;
                                }
                            }

                            i--;
                            i += jgzValue;
                        }
                        break;
                }

                if (soundRecovered)
                {
                    break;
                }
            }

            return lastSoundPlayed;
        }
    }
}