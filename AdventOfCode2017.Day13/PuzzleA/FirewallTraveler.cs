using AdventOfCode2017.Day13.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day13.PuzzleA
{
    public static class FirewallTraveler
    {
        public static int CheckSeverityForPacket(string filename)
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

            int severity = 0;

            for (int i = 0; i <= layerDefinitions.Keys.Max(); i++)
            {
                // Find scanner for this layer.
                var layerScanner = scanners.FirstOrDefault(s => s.Layer == i);

                if (layerScanner != null)
                {
                    // Collision with scanner.
                    if (layerScanner.Position == 0)
                    {
                        // Add layer depth * layer range to severity.
                        severity += (i * layerDefinitions[i]);
                    }
                }

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
            }

            return severity;
        }
    }
}