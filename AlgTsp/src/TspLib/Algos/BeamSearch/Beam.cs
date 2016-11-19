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

            solution.Set(ordered.ToArray());
            return solution;
        }

        private static IEnumerable<PartialSolution> Repete(IEnumerable<PartialSolution> partialSolutions, IEnumerable<Point> points, int beamDepth)
        {
            var newPartialSolutions = new List<PartialSolution>();
            var temp = new List<PartialSolution>();
            foreach (var solution in partialSolutions)
            {
                var remainingPoints = points
                    .Except(solution.Points)
                    .ToArray();
                temp.AddRange(CreateNewPartialSolution(solution, remainingPoints));
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

        private static IEnumerable<PartialSolution> CreateNewPartialSolution(PartialSolution partialSolution, Point[] points)
        {
            var newPartialSolutions = new PartialSolution[points.Length];
            for(int i = 0; i < newPartialSolutions.Length; i++)
            {
                newPartialSolutions[i] = new PartialSolution(partialSolution, points[i]);
            }
            return newPartialSolutions;
        }
    }
}
