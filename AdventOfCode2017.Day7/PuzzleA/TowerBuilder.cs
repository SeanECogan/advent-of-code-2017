using AdventOfCode2017.Day7.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day7.PuzzleA
{
    public static class TowerBuilder
    {
        public static string FindBottomProgram(string filename)
        {
            string bottomProgram = "";

            var rawProgramDefinitions = File.ReadAllLines(filename);
            var rawProgramModels = new List<RawProgramModel>();

            foreach (var rawProgramDefinition in rawProgramDefinitions)
            {
                if (rawProgramDefinition.Contains("->"))
                {
                    // Program has children.
                    string[] programAndChildrenParts = rawProgramDefinition.Split("->".ToCharArray());

                    string programDefinition = programAndChildrenParts[0];

                    RawProgramModel tempRawProgram = GetRawProgramModelFromDefinition(programDefinition);

                    string childrenPart = programAndChildrenParts[2].Replace(" ", "");

                    string[] children = childrenPart.Split(',');

                    rawProgramModels.Add(new RawProgramModel(tempRawProgram.Name, tempRawProgram.Weight, children.ToList()));
                }
                else
                {
                    rawProgramModels.Add(GetRawProgramModelFromDefinition(rawProgramDefinition));
                }
            }

            var programModels = new List<ProgramModel>();

            foreach (var rawProgramModel in rawProgramModels)
            {
                // Attempt to get a parent for this program.
                var parent = rawProgramModels.FirstOrDefault(r => r.Children != null &&
                                                                  r.Children.Any(c => c == rawProgramModel.Name));

                if (parent != null)
                {
                    programModels.Add(new ProgramModel(rawProgramModel.Name, rawProgramModel.Weight, parent.Name));
                }
                else
                {
                    programModels.Add(new ProgramModel(rawProgramModel.Name, rawProgramModel.Weight, null));
                }
            }

            bottomProgram = programModels.FirstOrDefault(p => p.Parent == null).Name;

            return bottomProgram;
        }

        private static RawProgramModel GetRawProgramModelFromDefinition(string rawProgramDefinition)
        {
            string[] programParts = rawProgramDefinition.Split(' ');

            string programName = programParts[0];

            string programWeightString = programParts[1];

            int programWeight = GetProgramWeightFromString(programWeightString);

            return new RawProgramModel(programName, programWeight, null);
        }

        private static int GetProgramWeightFromString(string programWeightString)
        {
            programWeightString = programWeightString.Replace("(", "");
            programWeightString = programWeightString.Replace(")", "");

            return Convert.ToInt32(programWeightString);
        }
    }
}
