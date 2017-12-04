using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day4
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
            Console.WriteLine("--- Begin Day 4 - Puzzle A ---");

            PerformanceTimer.Start();

            int result = PuzzleA.FileParser.CountValidPassphrases(@"Input\puzzlea.txt");

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
            Console.WriteLine("--- Begin Day 4 - Puzzle B ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter puzzle input: ");
            string numericString = Console.ReadLine();

            PerformanceTimer.Start();

            int result = PuzzleB.FileParser.CountValidPassphrases(@"Input\puzzleb.txt");

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}