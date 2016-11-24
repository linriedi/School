using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TspLib.Algos.BeamSearch
{
    public class BeamService : ISolver
    {
        private int beamDeph = 3;

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

            int i = 0;
            while(solution.ParitalSolutionList[0].Points.Count() < points.Count())
            {
                i++;
                solution = beam.GetNextSolutionSet(solution, points, beamDeph);
                Console.WriteLine("{0} of {1} done", i, points.Length);
            }

            return solution.BestSoltuion() ;
        }

        public IEnumerable<Point> Solve(IEnumerable<Point> points)
        {
            return GetOptimalPoints(points.ToArray());
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
