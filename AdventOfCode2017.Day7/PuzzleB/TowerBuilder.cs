using AdventOfCode2017.Day7.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2017.Day7.PuzzleB
{
    public static class TowerBuilder
    {
        public static int FindBalancingWeight(string filename)
        {
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

            var bottomProgram = programModels.FirstOrDefault(p => p.Parent == null);

            var weights = FindWeightsOfChildren(bottomProgram, programModels);

            return NewWeight;
        }

        public static int NewWeight = -1;

        private static List<int> FindWeightsOfChildren(ProgramModel currentProgram, List<ProgramModel> allPrograms)
        {
            List<int> weights = new List<int>();

            foreach (var program in allPrograms.Where(p => p.Parent != null && p.Parent == currentProgram.Name))
            {
                int currentWeight = program.Weight + FindWeightsOfChildren(program, allPrograms).Sum();

                if (weights.Count > 1 &&
                    !weights.All(w => w == currentWeight)
                    && NewWeight != -1)
                {
                    NewWeight = program.Weight + (weights[0] - currentWeight);
                }

                weights.Add(currentWeight);
            }

            return weights;
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
