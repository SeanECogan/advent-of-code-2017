using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2017.Day4.PuzzleA
{
    public static class FileParser
    {
        public static int CountValidPassphrases(string filename)
        {
            int validPassphrases = 0;

            foreach (var fileline in File.ReadAllLines(filename))
            {
                if (PassphraseIsValid(fileline))
                {
                    validPassphrases++;
                }
            }

            return validPassphrases;
        }

        public static bool PassphraseIsValid(string passphrase)
        {
            HashSet<string> words = new HashSet<string>();

            foreach (var word in passphrase.Split(null))
            {
                // A duplicate word has been detected, so the passphrase
                // is not valid.
                if (!words.Add(word))
                {
                    return false;
                }
            }

            // No duplicates found, the passphrase is valid.
            return true;
        }
    }
}