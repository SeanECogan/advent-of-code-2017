using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day21.Common
{
    public sealed class Instruction
    {
        public Instruction(string instructionString)
        {
            var instructionParts = instructionString.Replace("=>", "&")
                                                    .Split('&')
                                                    .Select(s => s.Trim())
                                                    .ToList();

            Input = instructionParts[0].Split('/').ToList();
            Output = instructionParts[1].Split('/').ToList();
        }

        public List<string> Input { get; private set; }
        public List<string> Output { get; private set; }
    }
}