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

            foreach (var pipe in _pipes.Keys)
            {
                if (!_groups.Any(gr => gr.Any(g => g == pipe)))
                {
                    var pipeConnections = GetAllPipeConnections(pipe, new HashSet<int>());
                    pipeConnections.Add(pipe);
                    _groups.Add(pipeConnections);
                }
            }

            return _groups.Count;
        }

        private static HashSet<int> GetAllPipeConnections(int pipe, HashSet<int> visitedPipes)
        {
            // Get connections for this pipe.
            List<int> connections = _pipes[pipe];

            // Get connections that have not been visited yet.
            List<int> unvisitedConnections = connections
                .Where(c => c != pipe)
                .Where(c => !visitedPipes.Any(v => v == c))
                .ToList();

            if (!unvisitedConnections.Any())
            {
                return visitedPipes;
            }
            else
            {
                foreach (var unvisitedConnection in unvisitedConnections)
                {
                    visitedPipes.Add(unvisitedConnection);
                }

                foreach (var unvisitedConnection in unvisitedConnections)
                {
                    foreach (var connection in GetAllPipeConnections(unvisitedConnection, visitedPipes))
                    {
                        visitedPipes.Add(connection);
                    }
                }

                return visitedPipes;
            }
        }

        private static Dictionary<int, List<int>> _pipes;
        private static List<HashSet<int>> _groups;
    }
}