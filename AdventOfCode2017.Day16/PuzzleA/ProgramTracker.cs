using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day16.PuzzleA
{
    public static class ProgramTracker
    {
        public static string TrackProgramPositions(
            string filename,
            string initialPrograms)
        {
            string programs = initialPrograms;

            List<string> instructions = File.ReadAllText(filename).Trim().Split(',').ToList();
            
            foreach (var instruction in instructions)
            {
                switch (instruction[0])
                {
                    case 's':
                        // Spin.
                        int spinNumber = Convert.ToInt32(instruction.Substring(1));

                        int lastIndex = programs.Length - spinNumber;

                        string endPart = programs.Substring(lastIndex);
                        string beginningPart = programs.Substring(0, lastIndex);

                        programs = endPart + beginningPart;
                        break;

                    case 'x':
                        // Exchange.
                        List<string> positionParts = instruction.Substring(1)
                                                                .Split('/')
                                                                .ToList();

                        int firstPosition = Convert.ToInt32(positionParts[0]);
                        int secondPosition = Convert.ToInt32(positionParts[1]);

                        string firstCharacter = "" + programs[firstPosition];
                        string secondCharacter = "" + programs[secondPosition];

                        string newArrangement = string.Empty;

                        for (int i = 0; i < programs.Length; i++)
                        {
                            if (i == firstPosition)
                            {
                                newArrangement += secondCharacter;
                            }
                            else if (i == secondPosition)
                            {
                                newArrangement += firstCharacter;
                            }
                            else
                            {
                                newArrangement += programs[i];
                            }
                        }

                        programs = newArrangement;
                        break;

                    case 'p':
                        // Partner.
                        List<string> characterParts = instruction.Substring(1)
                                                                .Split('/')
                                                                .ToList();

                        int firstPartnerPosition = programs.IndexOf(characterParts[0]);
                        int secondPartnerPosition = programs.IndexOf(characterParts[1]);

                        string newPartnerArrangement = string.Empty;

                        for (int i = 0; i < programs.Length; i++)
                        {
                            if (i == firstPartnerPosition)
                            {
                                newPartnerArrangement += characterParts[1];
                            }
                            else if (i == secondPartnerPosition)
                            {
                                newPartnerArrangement += characterParts[0];
                            }
                            else
                            {
                                newPartnerArrangement += programs[i];
                            }
                        }

                        programs = newPartnerArrangement;
                        break;

                    default:
                        break;
                }
            }

            return programs;
        }
    }
}