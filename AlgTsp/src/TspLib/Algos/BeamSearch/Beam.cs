using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TspLib.Algos.BeamSearch
{
    public class Beam
    {
        public SolutionSet GetNextSolutionSet(SolutionSet solution, IEnumerable<Point> points, int beamDepth)
        {
            var tails = new PartialSolutionTail[solution.ParitalSolutionList.Length];
            for(int i = 0; i < solution.ParitalSolutionList.Length; i++)
            {
                tails[i] = new PartialSolutionTail(solution.ParitalSolutionList[i]);
            }

            var tempPartialSolutions = Repete(tails, points, beamDepth);
            var ordered = tempPartialSolutions
                .OrderBy(ps => ps.Distance)
                .Take(SolutionSet.BeamWith);

            solution.Attach(ordered.ToArray());
            //solution.Set(ordered.ToArray());
            return solution;
        }

        private static IEnumerable<PartialSolutionTail> Repete(PartialSolutionTail[] tails, IEnumerable<Point> points, int beamDepth)
        {
            var newPartialSolutions = new List<PartialSolutionTail>();
            var temp = new List<PartialSolutionTail>();
            for (int i = 0; i < tails.Length; i++)
            {
                var tail = tails[i];
                var remainingPoints = points
                    .Except(tail.Head.Points)
                    .ToArray();
                temp.AddRange(CreateNewPartialSolution(tail.Head, remainingPoints));
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

        private static IEnumerable<PartialSolutionTail> CreateNewPartialSolution(PartialSolution partialSolution, Point[] points)
        {
            var newPartialSolutions = new PartialSolutionTail[points.Length];
            for(int i = 0; i < newPartialSolutions.Length; i++)
            {
                newPartialSolutions[i] = new PartialSolutionTail(partialSolution, points[i]);
            }
            return newPartialSolutions;
        }
    }
}
