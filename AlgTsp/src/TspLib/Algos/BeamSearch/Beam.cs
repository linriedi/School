using System.Collections.Generic;
using System.Linq;

namespace TspLib.Algos.BeamSearch
{
    public class Beam
    {
        public SolutionSet GetNextSolutionSet(SolutionSet solution, IEnumerable<Point> points, int beamDepth)
        {
            var tempPartialSolutions = Repete(solution.ParitalSolutionList, points, beamDepth);

            var ordered = tempPartialSolutions
                .OrderBy(ps => ps.Distance);

            return new SolutionSet(ordered);
        }

        private static IEnumerable<PartialSolution> Repete(IEnumerable<PartialSolution> partialSolutions, IEnumerable<Point> points, int beamDepth)
        {
            var newPartialSolutions = new List<PartialSolution>();
            var temp = new List<PartialSolution>();
            foreach (var solution in partialSolutions)
            {
                temp.AddRange(CreateNewPartialSolution(solution, points));
            }
            beamDepth--;
            if (beamDepth <= 0)
            {
                newPartialSolutions.AddRange(temp);
                return newPartialSolutions;
            }

            newPartialSolutions.AddRange(Repete(temp, points, beamDepth));
            return newPartialSolutions;
        }

        private static IEnumerable<PartialSolution> CreateNewPartialSolution(PartialSolution partialSolution, IEnumerable<Point> points)
        {
            var remainingPoints = points.Except(partialSolution.Points);
            var newPartialSolutions = new List<PartialSolution>();
            foreach (var point in remainingPoints)
            {
                newPartialSolutions.Add(new PartialSolution(partialSolution, point));
            }

            return newPartialSolutions;
        }
    }
}
