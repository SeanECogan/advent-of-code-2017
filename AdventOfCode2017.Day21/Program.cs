﻿using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day21
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
            Console.WriteLine("--- Begin Day 21 - Puzzle A ---");
            Console.WriteLine();

            PerformanceTimer.Start();

            int result = PuzzleA.ArtGenerator.FindNumberOfOnCells(
                @"Input\puzzlea.txt",
                5);

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine($"Puzzle A result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }

        private static void RunPuzzleB()
        {
            // Intro message.
            Console.WriteLine("--- Begin Day 21 - Puzzle B ---");
            Console.WriteLine();

            PerformanceTimer.Start();

            int result = PuzzleA.ArtGenerator.FindNumberOfOnCells(
                @"Input\puzzlea.txt",
                18);

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}