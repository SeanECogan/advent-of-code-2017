using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunPuzzleA();

            Console.WriteLine("Press any key to begin Puzzle B");
            Console.Read();
            PerformanceTimer.Reset();

            RunPuzzleB();
        }

        private static void RunPuzzleA()
        {
            // Intro message.
            Console.WriteLine("--- Begin Day 19 - Puzzle A ---");

            PerformanceTimer.Start();

            string result = PuzzleA.PathFollower.FollowPath(@"Input\puzzlea.txt");

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle A result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }

        private static void RunPuzzleB()
        {
            // Intro message.
            Console.WriteLine("--- Begin Day 19 - Puzzle B ---");

            PerformanceTimer.Start();

            int result = PuzzleB.PathFollower.CountSteps(@"Input\puzzleb.txt");

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}