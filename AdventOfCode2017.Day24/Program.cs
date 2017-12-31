using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day24
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
            Console.WriteLine("--- Begin Day 24 - Puzzle A ---");

            PerformanceTimer.Start();

            int result = PuzzleA.BridgeBuilder.DetermineStrengthOfStrongestBridge(@"Input\puzzlea.txt");

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
            Console.WriteLine("--- Begin Day 24 - Puzzle B ---");

            PerformanceTimer.Start();

            int result = PuzzleB.BridgeBuilder.DetermineStrengthOfLongestBridge(@"Input\puzzleb.txt");

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}