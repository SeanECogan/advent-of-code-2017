﻿using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day6
{
    public static class Program
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
            Console.WriteLine("--- Begin Day 6 - Puzzle A ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter puzzle input: ");
            string memoryBankString = Console.ReadLine();

            PerformanceTimer.Start();

            int result = PuzzleA.MemoryBankBalancer.GetIterationsBeforeDuplicateState(memoryBankString);

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
            Console.WriteLine("--- Begin Day 6 - Puzzle B ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter puzzle input: ");
            string memoryBankString = Console.ReadLine();

            PerformanceTimer.Start();

            int result = PuzzleB.MemoryBankBalancer.GetIterationsInLoop(memoryBankString);

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}