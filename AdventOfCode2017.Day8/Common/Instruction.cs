using System;

namespace AdventOfCode2017.Day8.Common
{
    public sealed class Instruction
    {
        public Instruction(
            string registerToModify,
            RegisterOperations registerOperation,
            int operationAmount,
            string registerToCheck,
            RegisterComparisons registerComparison,
            int comparisonAmount)
        {
            if (string.IsNullOrEmpty(registerToModify))
            {
                throw new ArgumentNullException(nameof(registerToModify));
            }

            if (string.IsNullOrEmpty(registerToCheck))
            {
                throw new ArgumentNullException(nameof(registerToCheck));
            }

            this.RegisterToModify = registerToModify;
            this.RegisterOperation = registerOperation;
            this.OperationAmount = operationAmount;
            this.RegisterToCheck = registerToCheck;
            this.RegisterComparison = registerComparison;
            this.ComparisonAmount = comparisonAmount;
        }

        public string RegisterToModify { get; private set; }
        public RegisterOperations RegisterOperation { get; private set; }
        public int OperationAmount { get; private set; }
        public string RegisterToCheck { get; private set; }
        public RegisterComparisons RegisterComparison { get; private set; }
        public int ComparisonAmount { get; private set; }
    }
}