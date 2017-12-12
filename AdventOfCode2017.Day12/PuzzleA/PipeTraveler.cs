using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day12.PuzzleA
{
    public static class PipeTraveler
    {
        public static int FindConnectionsToZero(string filename)
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

            HashSet<int> pipesConnectedToZero = new HashSet<int>();

            foreach (var pipe in _pipes.Keys)
            {
                if (PipeConnectsToZero(pipe, new HashSet<int>()))
                {
                    pipesConnectedToZero.Add(pipe);
                }
            }

            return pipesConnectedToZero.Count;
        }

        private static bool PipeConnectsToZero(int pipe, HashSet<int> visitedPipes)
        {
            // Get connections for this pipe.
            List<int> connections = _pipes[pipe];

            if (connections.Any(c => c == 0))
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

                    if (unvisitedConnections.Any(c => PipeConnectsToZero(c, visitedPipes)))
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
    }
}