using AdventOfCode2017.Day24.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day24.PuzzleA
{
    public static class BridgeBuilder
    {
        public static int DetermineStrengthOfStrongestBridge(string filename)
        {
            List<List<Component>> bridges = new List<List<Component>>();

            _components = new List<Component>();

            List<string> componentLines = File.ReadAllLines(filename).ToList();

            for (int i = 0; i < componentLines.Count; i++)
            {
                _components.Add(new Component(
                    i,
                    componentLines[i]));
            }

            bridges = FindPossibleBridges(new List<Component>(), 0);

            return bridges.Max(b => b.Sum(c => c.Ports.Sum()));
        }

        private static List<List<Component>> FindPossibleBridges(
            List<Component> currentComponents,
            int currentEndpoint)
        {
            List<List<Component>> bridges = new List<List<Component>>()
            {
                currentComponents
            };

            foreach (var component in _components.Where(c => c.Ports.Contains(currentEndpoint) &&
                                                             c.Ports.FirstOrDefault(p => p != currentEndpoint) != 0 &&
                                                             !currentComponents.Any(cc => cc.Id == c.Id)))
            {
                List<Component> newComponents = new List<Component>(currentComponents)
                {
                    component
                };

                bridges.AddRange(FindPossibleBridges(newComponents, component.Ports.FirstOrDefault(p => p != currentEndpoint)));
            }

            return bridges;
        }

        private static List<Component> _components = new List<Component>();
    }
}
