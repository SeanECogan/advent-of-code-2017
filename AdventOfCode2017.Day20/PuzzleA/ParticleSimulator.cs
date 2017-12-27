using AdventOfCode2017.Day20.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.Day20.PuzzleA
{
    public static class ParticleSimulator
    {
        public static int FindClosestParticle(string filename)
        {
            int closestParticleId = -1;
            int lastClosestParticleId = -1;
            int closestConstant = 0;

            List<Particle> particles = new List<Particle>();

            var particleLines = File.ReadAllLines(filename);

            for (int i = 0; i < particleLines.Length; i++)
            {
                particles.Add(new Particle(
                    i,
                    particleLines[i]));
            }

            while (closestConstant < 5000)
            {
                long closestDistance = long.MaxValue;

                foreach (var particle in particles)
                {
                    particle.Velocity = new Tuple<int, int, int>(
                        particle.Velocity.Item1 + particle.Acceleration.Item1,
                        particle.Velocity.Item2 + particle.Acceleration.Item2,
                        particle.Velocity.Item3 + particle.Acceleration.Item3);

                    particle.Position = new Tuple<int, int, int>(
                        particle.Position.Item1 + particle.Velocity.Item1,
                        particle.Position.Item2 + particle.Velocity.Item2,
                        particle.Position.Item3 + particle.Velocity.Item3);

                    int distance = Math.Abs(particle.Position.Item1) +
                                   Math.Abs(particle.Position.Item2) +
                                   Math.Abs(particle.Position.Item3);

                    if (distance < closestDistance)
                    {
                        closestParticleId = particle.Id;
                        closestDistance = distance;
                    }
                }

                if (closestParticleId == lastClosestParticleId)
                {
                    closestConstant++;
                }
                else
                {
                    closestConstant = 0;
                }

                lastClosestParticleId = closestParticleId;
            }

            return closestParticleId;
        }
    }
}