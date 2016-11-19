using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TspLib.Algos.BeamSearch
{
    public class BeamService : ISolver
    {
        public string Id
        {
            get
            {
                return "Beam";
            }
        }

        public Point[] GetOptimalPoints(Point[] points)
        {
            var nofPoints = points.Length;
            var firstSolution = CreateFirstSolutionSet(points);
            IEnumerable<Point> remainingPoints = points;

            var beam = new Beam();
            var solution = firstSolution;
            Console.WriteLine("Start");

            for (int i = 0; i < nofPoints - 1; i++)
            {
                solution = beam.GetNextSolutionSet(solution, remainingPoints.ToArray(), 1);
                Console.WriteLine("{0} of {1} done", i, nofPoints);
            }

            return solution.BestSoltuion() ;
        }

        public IEnumerable<Point> Solve(Instance instance)
        {
            return GetOptimalPoints(instance.Points.ToArray());
        }

        private SolutionSet CreateFirstSolutionSet(Point[] points)
        {
            var partialSolutions = new PartialSolution[2];
            partialSolutions[0] = new PartialSolution(points[0]);
            partialSolutions[1] = new PartialSolution(points[1]);
            return new SolutionSet(partialSolutions);
        }
    }
}
