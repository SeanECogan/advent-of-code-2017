using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day16
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
            Console.WriteLine("--- Begin Day 16 - Puzzle A ---");

            PerformanceTimer.Start();

            string result = PuzzleA.ProgramTracker.TrackProgramPositions(
                @"Input\puzzlea.txt",
                "abcdefghijklmnop");

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
            Console.WriteLine("--- Begin Day 16 - Puzzle B ---");

            PerformanceTimer.Start();

            string result = PuzzleB.ProgramTracker.TrackProgramPositions(
                @"Input\puzzleb.txt",
                "abcdefghijklmnop");

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}