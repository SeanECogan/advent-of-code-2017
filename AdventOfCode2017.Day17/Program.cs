using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day17
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunPuzzleA();

            Console.WriteLine("Press any key to begin Puzzle B");
            Console.ReadLine();
            PerformanceTimer.Reset();

            RunPuzzleB();
        }

        private static void RunPuzzleA()
        {
            // Intro message.
            Console.WriteLine("--- Begin Day 17 - Puzzle A ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter puzzle input: ");
            int stepValue = Convert.ToInt32(Console.ReadLine());

            PerformanceTimer.Start();

            int result = PuzzleA.SpinlockGenerator.GetShortCircuitValue(stepValue);

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
            Console.WriteLine("--- Begin Day 17 - Puzzle B ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter puzzle input: ");
            int stepNumber = Convert.ToInt32(Console.ReadLine());

            PerformanceTimer.Start();

            int result = PuzzleB.SpinlockGenerator.GetShortCircuitValue(stepNumber);

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}