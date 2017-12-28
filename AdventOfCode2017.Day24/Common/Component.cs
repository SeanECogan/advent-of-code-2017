using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day24.Common
{
    public sealed class Component
    {
        public Component(
            int id,
            string componentLine)
        {
            Id = id;
            Ports = componentLine.Split('/').Select(s => Convert.ToInt32(s)).ToList();
        }

        public override string ToString()
        {
            return string.Join("/", Ports);
        }

        public int Id { get; private set; }
        public List<int> Ports { get; private set; }
    }
}