using System;
using System.Collections.Generic;

namespace AdventOfCode2017.Day7.Common
{
    public sealed class RawProgramModel
    {
        public RawProgramModel(
            string name,
            int weight,
            List<string> children)
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
            Children = children;
        }

        public string Name { get; private set; }
        public int Weight { get; private set; }

        public List<string> Children { get; private set; }
    }
}