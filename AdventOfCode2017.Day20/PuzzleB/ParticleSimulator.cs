using AdventOfCode2017.Day20.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day20.PuzzleB
{
    public static class ParticleSimulator
    {
        public static int FindNumberOfNonCollisions(string filename)
        {
            int ticksWithoutCollision = 0;

            List<Particle> particles = new List<Particle>();

            var particleLines = File.ReadAllLines(filename);

            for (int i = 0; i < particleLines.Length; i++)
            {
                particles.Add(new Particle(
                    i,
                    particleLines[i]));
            }

            while (ticksWithoutCollision < 5000)
            {
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
                }

                List<Particle> remainingParticles = new List<Particle>();                    

                foreach (var particle in particles)
                {
                    if (!particles.Any(p => p.Id != particle.Id &&
                                            p.Position.Item1 == particle.Position.Item1 &&
                                            p.Position.Item2 == particle.Position.Item2 &&
                                            p.Position.Item3 == particle.Position.Item3))
                    {
                        remainingParticles.Add(particle);
                    }
                }

                if (particles.Count == remainingParticles.Count)
                {
                    ticksWithoutCollision++;
                }
                else
                {
                    ticksWithoutCollision = 0;
                }

                particles = new List<Particle>(remainingParticles);
            }

            return particles.Count;
        }
    }
}