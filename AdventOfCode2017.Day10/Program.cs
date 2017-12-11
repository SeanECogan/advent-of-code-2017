using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day10
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
            Console.WriteLine("--- Begin Day 1 - Puzzle A ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter number of elements: ");
            int numberOfElements = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter puzzle input: ");
            string lengths = Console.ReadLine();

            PerformanceTimer.Start();

            int result = PuzzleA.HashGenerator.GenerateHashFromLengths(
                numberOfElements,
                lengths);

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
            string inputString = Console.ReadLine();

            PerformanceTimer.Start();

            string result = PuzzleB.HashGenerator.GenerateHash(inputString);

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}