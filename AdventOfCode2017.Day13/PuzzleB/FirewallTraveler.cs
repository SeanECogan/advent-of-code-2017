using AdventOfCode2017.Day13.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day13.PuzzleB
{
    public static class FirewallTraveler
    {
        public static int FindShortestDelay(string filename)
        {
            List<string> layerStrings = File.ReadAllLines(filename).ToList();
            Dictionary<int, int> layerDefinitions = new Dictionary<int, int>();
            List<Scanner> scanners = new List<Scanner>();

            foreach (string layerString in layerStrings)
            {
                var layerParts = layerString.Split(':')
                                            .Select(p => Convert.ToInt32(p.Trim()))
                                            .ToList();

                layerDefinitions.Add(layerParts[0], layerParts[1]);

                scanners.Add(new Scanner(
                    layerParts[0],
                    0,
                    true));
            }

            int delay = 0;
            bool caughtOnIteration;

            do
            {               
                Console.Write($"\rAttempting after delay of {delay}...");

                caughtOnIteration = false;

                // Make new copy of scanner positions for this iteration.
                List<Scanner> iterationScanners = new List<Scanner>();
                
                foreach (var scanner in scanners)
                {
                    iterationScanners.Add(new Scanner(
                        scanner.Layer, 
                        scanner.Position, 
                        scanner.MovingUp));
                }

                // Attempt to pass through the firewall.
                for (int i = 0; i <= layerDefinitions.Keys.Max(); i++)
                {
                    if (!caughtOnIteration)
                    {
                        // Find scanner for this layer.
                        var layerScanner = iterationScanners.FirstOrDefault(s => s.Layer == i);

                        if (layerScanner != null)
                        {
                            // Collision with scanner.
                            if (layerScanner.Position == 0)
                            {
                                // Add layer depth * layer range to severity.
                                caughtOnIteration = true;
                            }
                        }

                        // Update scanner positions.
                        foreach (var scanner in iterationScanners.Where(s => s.Layer >= i))
                        {
                            if (scanner.MovingUp)
                            {
                                if (scanner.Position < layerDefinitions[scanner.Layer] - 1)
                                {
                                    scanner.Position++;
                                }
                                else
                                {
                                    scanner.MovingUp = false;
                                    scanner.Position--;
                                }
                            }
                            else
                            {
                                if (scanner.Position > 0)
                                {
                                    scanner.Position--;
                                }
                                else
                                {
                                    scanner.MovingUp = true;
                                    scanner.Position++;
                                }
                            }
                        }
                    }
                }

                // If this attempt did not work, update the delay by one and move
                // the 'real' scanners forward.
                if (caughtOnIteration)
                {
                    // Update scanner positions.
                    foreach (var scanner in scanners)
                    {
                        if (scanner.MovingUp)
                        {
                            if (scanner.Position < layerDefinitions[scanner.Layer] - 1)
                            {
                                scanner.Position++;
                            }
                            else
                            {
                                scanner.MovingUp = false;
                                scanner.Position--;
                            }
                        }
                        else
                        {
                            if (scanner.Position > 0)
                            {
                                scanner.Position--;
                            }
                            else
                            {
                                scanner.MovingUp = true;
                                scanner.Position++;
                            }
                        }
                    }

                    delay++;
                }
            }
            while (caughtOnIteration);

            return delay;
        }
    }
}