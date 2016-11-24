using System;
using System.Collections.Generic;
using System.Linq;

namespace TspLib.Algos.BeamSearch
{
    public class SolutionSet
    {
        public static int BeamWith = 11;
        
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

        internal void Attach(PartialSolutionTail[] tails)
        {
            for(int i = 0; i < tails.Count(); i++)
            {
                var tail = tails[i];
                this.ParitalSolutionList[i] = new PartialSolution(tail.Head, tail, i);
            }
        }

        internal Point[] BestSoltuion()
        {
            return this.ParitalSolutionList
                .OrderBy(p => p.DistanceClosed)
                .First()
                .Points;
        }
    }
}
