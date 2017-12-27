using System;

namespace AdventOfCode2017.Day20.Common
{
    public class Particle
    {
        public Particle(
            int id,
            string inputString)
        {
            Id = id;

            string[] inputParts = inputString.Split(' ');

            // Position
            string[] positionParts = inputParts[0].Replace("p=", "")
                                                  .Replace("<", "")
                                                  .Replace(">", "")
                                                  .Split(',');

            Position = new Tuple<int, int, int>(
                Convert.ToInt32(positionParts[0]),
                Convert.ToInt32(positionParts[1]),
                Convert.ToInt32(positionParts[2]));

            // Velocity
            string[] velocityParts = inputParts[1].Replace("v=", "")
                                                  .Replace("<", "")
                                                  .Replace(">", "")
                                                  .Split(',');

            Velocity = new Tuple<int, int, int>(
                Convert.ToInt32(velocityParts[0]),
                Convert.ToInt32(velocityParts[1]),
                Convert.ToInt32(velocityParts[2]));

            // Acceleration
            string[] accelerationParts = inputParts[2].Replace("a=", "")
                                                  .Replace("<", "")
                                                  .Replace(">", "")
                                                  .Split(',');

            Acceleration = new Tuple<int, int, int>(
                Convert.ToInt32(accelerationParts[0]),
                Convert.ToInt32(accelerationParts[1]),
                Convert.ToInt32(accelerationParts[2]));
        }

        public int Id { get; set; }
        public Tuple<int, int, int> Position { get; set; }
        public Tuple<int, int, int> Velocity { get; set; }
        public Tuple<int, int, int> Acceleration { get; set; }
    }
}