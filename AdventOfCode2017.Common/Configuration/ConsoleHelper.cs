using System;
using System.IO;

namespace AdventOfCode2017.Common.Configuration
{
    public static class ConsoleHelper
    {
        public static void SetBigConsoleReadLimit()
        {
            byte[] inputBuffer = new byte[4096];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));            
        }
    }
}