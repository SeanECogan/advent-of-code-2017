using AdventOfCode2017.Common.Configuration;
using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day1
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
            Console.WriteLine("--- Begin Day 1 - Puzzle A ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter puzzle input: ");
            ConsoleHelper.SetBigConsoleReadLimit();
            string numericString = Console.ReadLine();

            PerformanceTimer.Start();

            int result = PuzzleA.NumericStringParser.Parse(numericString);

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
            Console.WriteLine("--- Begin Day 1 - Puzzle B ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter puzzle input: ");
            ConsoleHelper.SetBigConsoleReadLimit();
            string numericString = Console.ReadLine();

            PerformanceTimer.Start();

            int result = PuzzleB.NumericStringParser.Parse(numericString);

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}