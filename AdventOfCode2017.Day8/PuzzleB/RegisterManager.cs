using AdventOfCode2017.Day8.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.Day8.PuzzleB
{
    public static class RegisterManager
    {
        public static int FindLargestValueEver(string filename)
        {
            Dictionary<string, int> registers = new Dictionary<string, int>();

            int largestValueEver = 0;

            var instructionStrings = File.ReadAllLines(filename);

            foreach (var instructionString in instructionStrings)
            {
                Instruction instruction = ParseInstructionString(instructionString);

                // Get register value.
                int registerValueToCompare;

                if (!registers.TryGetValue(instruction.RegisterToCheck, out registerValueToCompare))
                {
                    registers.Add(instruction.RegisterToCheck, 0);
                    registerValueToCompare = 0;
                }

                bool comparisonSucceeded = false;

                switch (instruction.RegisterComparison)
                {
                    case RegisterComparisons.LessThan:
                        if (registerValueToCompare < instruction.ComparisonAmount)
                        {
                            comparisonSucceeded = true;
                        }
                        break;

                    case RegisterComparisons.GreaterThan:
                        if (registerValueToCompare > instruction.ComparisonAmount)
                        {
                            comparisonSucceeded = true;
                        }
                        break;

                    case RegisterComparisons.LessThanOrEqualTo:
                        if (registerValueToCompare <= instruction.ComparisonAmount)
                        {
                            comparisonSucceeded = true;
                        }
                        break;

                    case RegisterComparisons.GreaterThanOrEqualTo:
                        if (registerValueToCompare >= instruction.ComparisonAmount)
                        {
                            comparisonSucceeded = true;
                        }
                        break;

                    case RegisterComparisons.EqualTo:
                        if (registerValueToCompare == instruction.ComparisonAmount)
                        {
                            comparisonSucceeded = true;
                        }
                        break;

                    case RegisterComparisons.NotEqualTo:
                        if (registerValueToCompare != instruction.ComparisonAmount)
                        {
                            comparisonSucceeded = true;
                        }
                        break;

                    default:
                        comparisonSucceeded = false;
                        break;
                }

                if (comparisonSucceeded)
                {
                    int registerValueToModify;

                    if (!registers.TryGetValue(instruction.RegisterToModify, out registerValueToModify))
                    {
                        registers.Add(instruction.RegisterToModify, 0);
                        registerValueToModify = 0;
                    }

                    switch (instruction.RegisterOperation)
                    {
                        case RegisterOperations.Increment:
                            registerValueToModify += instruction.OperationAmount;
                            break;

                        case RegisterOperations.Decrement:
                            registerValueToModify -= instruction.OperationAmount;
                            break;

                        default:
                            break;
                    }

                    registers[instruction.RegisterToModify] = registerValueToModify;

                    if (registerValueToModify > largestValueEver)
                    {
                        largestValueEver = registerValueToModify;
                    }
                }
            }

            return largestValueEver;
        }

        private static Instruction ParseInstructionString(string instructionString)
        {
            var instructionParts = instructionString.Split(null);

            string registerToModify = instructionParts[0];

            string operation = instructionParts[1];
            RegisterOperations registerOperation = operation == "inc" ? 
                RegisterOperations.Increment : 
                RegisterOperations.Decrement;

            int operationAmount = Convert.ToInt32(instructionParts[2]);

            string registerToCheck = instructionParts[4];

            string comparison = instructionParts[5];
            RegisterComparisons registerComparison;

            switch (comparison)
            {
                case "<":
                    registerComparison = RegisterComparisons.LessThan;
                    break;

                case ">":
                    registerComparison = RegisterComparisons.GreaterThan;
                    break;

                case "<=":
                    registerComparison = RegisterComparisons.LessThanOrEqualTo;
                    break;

                case ">=":
                    registerComparison = RegisterComparisons.GreaterThanOrEqualTo;
                    break;

                case "==":
                    registerComparison = RegisterComparisons.EqualTo;
                    break;

                case "!=":
                    registerComparison = RegisterComparisons.NotEqualTo;
                    break;

                default:
                    registerComparison = RegisterComparisons.EqualTo;
                    break;
            }

            int comparisonAmount = Convert.ToInt32(instructionParts[6]);

            return new Instruction(
                registerToModify,
                registerOperation,
                operationAmount,
                registerToCheck,
                registerComparison,
                comparisonAmount);
        }
    }
}