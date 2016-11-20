using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        private static IEnumerable<PartialSolution> Repete(PartialSolution[] partialSolutions, IEnumerable<Point> points, int beamDepth)
        {
            var newPartialSolutions = new List<PartialSolution>();
            var temp = new List<PartialSolution>();
            for (int i = 0; i < partialSolutions.Length; i++)
            {
                var solution = partialSolutions[i];
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

            newPartialSolutions.AddRange(Repete(temp.ToArray(), points, beamDepth));
            return newPartialSolutions;
        }

        private static IEnumerable<PartialSolution> CreateNewPartialSolution(PartialSolution partialSolution, Point[] points)
        {
            var newPartialSolutions = new PartialSolution[points.Length];
            Parallel.For(0, newPartialSolutions.Length, i =>
            {
                newPartialSolutions[i] = new PartialSolution(partialSolution, points[i]);
            });
            return newPartialSolutions;
        }
    }
}
