﻿using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day20
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
            Console.WriteLine("--- Begin Day 20 - Puzzle A ---");
            Console.WriteLine();

            PerformanceTimer.Start();

            int result = PuzzleA.ParticleSimulator.FindClosestParticle(@"Input\puzzlea.txt");

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine($"Puzzle A result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }

        private static void RunPuzzleB()
        {
            // Intro message.
            Console.WriteLine("--- Begin Day 20 - Puzzle B ---");
            Console.WriteLine();

            PerformanceTimer.Start();

            int result = PuzzleB.ParticleSimulator.FindNumberOfNonCollisions(@"Input\puzzleb.txt");

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}