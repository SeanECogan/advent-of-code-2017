using System;

namespace AdventOfCode2017.Day7.Common
{
    public sealed class ProgramModel
    {
        public ProgramModel(
            string name,
            int weight,
            string parent)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (weight <= 0)
            {
                throw new ArgumentException($"{nameof(weight)} cannot be less than or equal to 0.");
            }

            Name = name;
            Weight = weight;
            Parent = parent;
        }

        public string Name { get; private set; }
        public int Weight { get; private set; }

        public string Parent { get; private set; }
    }
}