using System;
using System.Diagnostics;

namespace AdventOfCode2017.Common.Diagnostics
{
    public static class PerformanceTimer
    {
        public static void Start()
        {
            InitStopwatch();

            _stopWatch.Start();
        }

        public static void Stop()
        {
            InitStopwatch();

            if (_stopWatch.IsRunning)
            {
                _stopWatch.Stop();
            }
        }

        public static void Reset()
        {
            InitStopwatch();

            _stopWatch.Reset();
        }

        public static void LogTime()
        {
            InitStopwatch();

            var elapsedTime = _stopWatch.Elapsed;
            double totalMilliseconds = (double)elapsedTime.Ticks / (double)TimeSpan.TicksPerMillisecond;

            Console.WriteLine($"Execution Time: {totalMilliseconds}ms.");
        }

        private static void InitStopwatch()
        {
            if (_stopWatch == null)
            {
                _stopWatch = new Stopwatch();
            }
        }

        private static Stopwatch _stopWatch = new Stopwatch();
    }
}