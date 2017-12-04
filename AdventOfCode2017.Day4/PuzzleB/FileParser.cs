using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day4.PuzzleB
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
                // First, alphebetize the string. Any anagrams will alphabetize
                // the same way.
                var alphebetizedWord = string.Concat(word.OrderBy(c => c));

                // A duplicate word has been detected, so the passphrase
                // is not valid.
                if (!words.Add(alphebetizedWord))
                {
                    return false;
                }
            }

            // No duplicates found, the passphrase is valid.
            return true;
        }
    }
}