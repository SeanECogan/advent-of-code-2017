using AdventOfCode2017.Common.Diagnostics;
using System;

namespace AdventOfCode2017.Day15
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
            Console.WriteLine("--- Begin Day 15 - Puzzle A ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter Generator A Start Value: ");
            int generatorAStartValue = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Generator B Start Value: ");
            int generatorBStartValue = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number of Iterations: ");
            int numberOfIterations = Convert.ToInt32(Console.ReadLine());

            PerformanceTimer.Start();

            int result = PuzzleA.GeneratorJudge.JudgeGenerators(
                generatorAStartValue,
                generatorBStartValue,
                numberOfIterations);

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
            Console.WriteLine("--- Begin Day 15 - Puzzle B ---");
            Console.WriteLine();

            // Prompt for input.
            Console.Write("Enter Generator A Start Value: ");
            int generatorAStartValue = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Generator B Start Value: ");
            int generatorBStartValue = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number of Iterations: ");
            int numberOfIterations = Convert.ToInt32(Console.ReadLine());

            PerformanceTimer.Start();

            int result = PuzzleB.GeneratorJudge.JudgeGenerators(
                generatorAStartValue,
                generatorBStartValue,
                numberOfIterations);

            PerformanceTimer.Stop();

            // Display results.
            Console.WriteLine();
            Console.WriteLine($"Puzzle B result: {result}");
            PerformanceTimer.LogTime();

            Console.WriteLine();
        }
    }
}