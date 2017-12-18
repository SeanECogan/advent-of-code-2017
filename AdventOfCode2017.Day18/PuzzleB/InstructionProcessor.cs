using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day18.PuzzleB
{
    public static class InstructionProcessor
    {
        public static long GetNumberOfValuesSent(string filename)
        {
            List<string> instructions = File.ReadAllLines(filename).ToList();

            Dictionary<int, Dictionary<string, long>> programRegisters = new Dictionary<int, Dictionary<string, long>>
            {
                { 0, new Dictionary<string, long>() { { "p", 0 } } },
                { 1, new Dictionary<string, long>() { { "p", 1 } } }
            };

            Dictionary<int, Queue<long>> programQueues = new Dictionary<int, Queue<long>>
            {
                { 0, new Queue<long>() },
                { 1, new Queue<long>() }
            };

            Dictionary<int, long> programIndices = new Dictionary<int, long>
            {
                { 0, 0 },
                { 1, 0 }
            };

            Dictionary<int, string> programWaiting = new Dictionary<int, string>
            {
                { 0, null },
                { 1, null }
            };

            Dictionary<int, int> programSent = new Dictionary<int, int>
            {
                { 0, 0 },
                { 1, 0 }
            };

            while (!programWaiting.Values.All(w => !string.IsNullOrEmpty(w)))
            {
                for (int i = 0; i < 2; i++)
                {
                    if (!string.IsNullOrWhiteSpace(programWaiting[i]))
                    {
                        List<string> instructionParts = programWaiting[i].Split(null).ToList();

                        if (programQueues[i].Any())
                        {
                            long rcvValue = programQueues[i].Dequeue();

                            programRegisters[i][instructionParts[1]] = rcvValue;

                            programWaiting[i] = null;
                        }
                    }
                    else
                    {
                        List<string> instructionParts = instructions[Convert.ToInt32(programIndices[i])].Split(null).ToList();

                        switch (instructionParts[0])
                        {
                            case "snd":
                                // Send message to other program's queue.
                                long sndValue;
                                bool sndIsNumeric = long.TryParse(instructionParts[1], out sndValue);

                                if (!sndIsNumeric)
                                {
                                    bool sndRegisterExists = programRegisters[i].TryGetValue(instructionParts[1], out long sndRegisterValue);

                                    if (sndRegisterExists)
                                    {
                                        sndValue = sndRegisterValue;
                                    }
                                }

                                if (i == 0)
                                {
                                    programQueues[1].Enqueue(sndValue);                                    
                                }
                                else
                                {
                                    programQueues[0].Enqueue(sndValue);
                                }

                                programSent[i]++;
                                break;

                            case "set":
                                // Set value of register.
                                long setValue;
                                bool setIsNumeric = long.TryParse(instructionParts[2], out setValue);

                                if (!setIsNumeric)
                                {
                                    bool setRegisterExists = programRegisters[i].TryGetValue(instructionParts[2], out long setRegisterValue);

                                    if (setRegisterExists)
                                    {
                                        setValue = setRegisterValue;
                                    }
                                }

                                programRegisters[i][instructionParts[1]] = setValue;
                                break;

                            case "add":
                                // Add value to register.
                                long addValue;
                                bool addIsNumeric = long.TryParse(instructionParts[2], out addValue);

                                if (!addIsNumeric)
                                {
                                    bool addRegisterExists = programRegisters[i].TryGetValue(instructionParts[2], out long addRegisterValue);

                                    if (addRegisterExists)
                                    {
                                        addValue = addRegisterValue;
                                    }
                                }

                                long addTargetRegisterValue;

                                bool addTargetRegisterExists = programRegisters[i].TryGetValue(instructionParts[1], out addTargetRegisterValue);

                                if (addTargetRegisterExists)
                                {
                                    programRegisters[i][instructionParts[1]] += addValue;
                                }
                                else
                                {
                                    programRegisters[i][instructionParts[1]] = addValue;
                                }
                                break;

                            case "mul":
                                // Multiply value and set in register.
                                long mulValue;
                                bool mulIsNumeric = long.TryParse(instructionParts[2], out mulValue);

                                if (!mulIsNumeric)
                                {
                                    bool mulRegisterExists = programRegisters[i].TryGetValue(instructionParts[2], out long mulRegisterValue);

                                    if (mulRegisterExists)
                                    {
                                        mulValue = mulRegisterValue;
                                    }
                                }

                                long mulTargetRegisterValue;

                                bool mulTargetRegisterExists = programRegisters[i].TryGetValue(instructionParts[1], out mulTargetRegisterValue);

                                if (mulTargetRegisterExists)
                                {
                                    programRegisters[i][instructionParts[1]] *= mulValue;
                                }
                                else
                                {
                                    programRegisters[i][instructionParts[1]] = 0;
                                }
                                break;

                            case "mod":
                                // Perform modulus arithmetic and set in register.
                                long modValue;
                                bool modIsNumeric = long.TryParse(instructionParts[2], out modValue);

                                if (!modIsNumeric)
                                {
                                    bool modRegisterExists = programRegisters[i].TryGetValue(instructionParts[2], out long modRegisterValue);

                                    if (modRegisterExists)
                                    {
                                        modValue = modRegisterValue;
                                    }
                                }

                                long modTargetRegisterValue;

                                bool modTargetRegisterExists = programRegisters[i].TryGetValue(instructionParts[1], out modTargetRegisterValue);

                                if (modTargetRegisterExists)
                                {
                                    programRegisters[i][instructionParts[1]] %= modValue;
                                }
                                else
                                {
                                    programRegisters[i][instructionParts[1]] = 0;
                                }
                                break;

                            case "rcv":
                                // Wait for other program here.
                                if (programQueues[i].Any())
                                {
                                    long rcvValue = programQueues[i].Dequeue();

                                    programRegisters[i][instructionParts[1]] = rcvValue;
                                }
                                else
                                {
                                    programWaiting[i] = instructions[Convert.ToInt32(programIndices[i])];
                                }
                                break;

                            case "jgz":
                                // Jump to the specified instruction.
                                long jgzCheckValue;
                                bool jgzCheckIsNumeric = long.TryParse(instructionParts[1], out jgzCheckValue);

                                if (!jgzCheckIsNumeric)
                                {
                                    bool jgzCheckRegisterExists = programRegisters[i].TryGetValue(instructionParts[1], out long jgzCheckRegisterValue);

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
                                        bool jgzRegisterExists = programRegisters[i].TryGetValue(instructionParts[2], out long jgzRegisterValue);

                                        if (jgzRegisterExists)
                                        {
                                            jgzValue = jgzRegisterValue;
                                        }
                                    }

                                    programIndices[i]--;
                                    programIndices[i] += jgzValue;
                                }
                                break;
                        }

                        programIndices[i]++;
                    }
                }
            }

            return programSent[1];
        }
    }
}