using System;

namespace AdventOfCode2017.Day13.Common
{
    public class Scanner
    {
        public Scanner(
            int layer,
            int position,
            bool movingUp)
        {
            if (layer < 0)
            {
                throw new ArgumentException($"{nameof(layer)} must be at least 0.");
            }

            if (position < 0)
            {
                throw new ArgumentException($"{nameof(layer)} must be at least 0.");
            }

            this.Layer = layer;
            this.Position = position;
            this.MovingUp = movingUp;
        }

        public int Layer { get; private set; }
        public int Position { get; set; }
        public bool MovingUp { get; set; }

        public override string ToString()
        {
            return string.Format("Layer: {0} | Position: {1} | Direction: {2}",
                this.Layer,
                this.Position,
                this.MovingUp ? "Up" : "Down");
        }
    }
}