using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TspLib.Algos.BeamSearch
{
    public class BeamService : ISolver
    {
        private int beamDeph = 1;

        public string Id
        {
            get
            {
                return "Beam";
            }
        }

        public Point[] GetOptimalPoints(Point[] points)
        {
            Console.WriteLine("Start");
            var beam = new Beam();

            var solution = CreateFirstSolutionSet(points);
            for (int i = 0; i < points.Length - 1; i++)
            {
                solution = beam.GetNextSolutionSet(solution, points, beamDeph);
                Console.WriteLine("{0} of {1} done", i, points.Length);
            }

            return solution.BestSoltuion() ;
        }

        public IEnumerable<Point> Solve(Instance instance)
        {
            return GetOptimalPoints(instance.Points.ToArray());
        }

        private SolutionSet CreateFirstSolutionSet(Point[] points)
        {
            var partialSolutions = new PartialSolution[SolutionSet.BeamWith];
            for (int i = 0; i < SolutionSet.BeamWith; i++)
            {
                partialSolutions[i] = new PartialSolution(points[i]);
            }
            return new SolutionSet(partialSolutions, points.Length);
        }
    }
}
