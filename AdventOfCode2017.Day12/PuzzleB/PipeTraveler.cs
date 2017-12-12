using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day12.PuzzleB
{
    public static class PipeTraveler
    {
        public static int FindGroups(string filename)
        {
            _pipes = new Dictionary<int, List<int>>();

            foreach (var pipeDefinition in File.ReadAllLines(filename))
            {
                List<string> definitionParts = pipeDefinition
                    .Split(new string[] { "<->" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();

                _pipes.Add(
                    Convert.ToInt32(definitionParts[0]),
                    definitionParts[1].Split(',').Select(s => Convert.ToInt32(s.Trim())).ToList());
            }

            _groups = new List<HashSet<int>>();

            int counter = 1;
            Console.Clear();

            foreach (var pipe in _pipes.Keys)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Checking pipe {counter} of {_pipes.Keys.Count}...");

                bool connectionFound = false;

                foreach (var group in _groups)
                {
                    if (group.Any(g => PipeConnectsToOtherPipe(pipe, g, new HashSet<int>())))
                    {
                        group.Add(pipe);
                        connectionFound = true;
                    }
                }

                if (!connectionFound)
                {
                    _groups.Add(new HashSet<int>() { pipe });
                }

                counter++;
            }

            return _groups.Count;
        }

        private static bool PipeConnectsToOtherPipe(int pipe, int connectingPipe, HashSet<int> visitedPipes)
        {
            // Get connections for this pipe.
            List<int> connections = _pipes[pipe];

            if (connections.Any(c => c == connectingPipe))
            {
                return true;
            }
            else
            {
                // Get connections that have not been visited yet.
                List<int> unvisitedConnections = connections
                    .Where(c => c != pipe)
                    .Where(c => !visitedPipes.Any(v => v == c))
                    .ToList();

                if (!unvisitedConnections.Any())
                {
                    return false;
                }
                else
                {
                    foreach (var unvisitedConnection in unvisitedConnections)
                    {
                        visitedPipes.Add(unvisitedConnection);
                    }

                    if (unvisitedConnections.Any(c => PipeConnectsToOtherPipe(c, connectingPipe, visitedPipes)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private static Dictionary<int, List<int>> _pipes;
        private static List<HashSet<int>> _groups;
    }
}