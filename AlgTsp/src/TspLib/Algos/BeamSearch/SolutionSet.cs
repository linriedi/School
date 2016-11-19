using System;
using System.Collections.Generic;
using System.Linq;

namespace TspLib.Algos.BeamSearch
{
    public class SolutionSet
    {
        private static int BeamWith = 2;
        
        public PartialSolution[] ParitalSolutionList { get; private set;}
                
        public SolutionSet(PartialSolution[] ordered, int maxSolutionLength)
        {
            this.ParitalSolutionList = new PartialSolution[BeamWith];
            this.Set(ordered);
        }

        internal void Set(PartialSolution[] partialSolutions)
        {
            for(int i = 0; i < BeamWith; i++)
            {
                this.ParitalSolutionList[i] = partialSolutions[i];
            }
        }

        internal Point[] BestSoltuion()
        {
            return this.ParitalSolutionList
                .OrderBy(p => p.Distance)
                .First()
                .Points;
        }
    }
}
