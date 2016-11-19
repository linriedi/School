using System;
using System.Collections.Generic;
using System.Linq;

namespace TspLib.Algos.BeamSearch
{
    public class SolutionSet
    {
        private static int BeamWith = 2;
        
        public PartialSolution[] ParitalSolutionList { get; private set;}
                
        public SolutionSet(IEnumerable<PartialSolution> ordered)
        {
            this.ParitalSolutionList = ordered.Take(BeamWith).ToArray();
        }

        internal IEnumerable<Point> GetAllPoints()
        {
            var list = new List<Point>();
            foreach (var partiallist in ParitalSolutionList)
            {
                list.AddRange(partiallist.Points);
            }
            return list;
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
