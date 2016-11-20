using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TspLib;
using TspLib.Algos.BeamSearch;
using Xunit;

namespace tests
{
    public class BeamTests
    {
        [Fact]
        public void CalculateLength()
        {
            var beam = new Beam();

            var startPoint = new Point(1, 0, 0);
            var startPointTwo = new Point(2, 1, 1);

            var nextPoints = new Point[3];

            nextPoints[0] = new Point(3, 0, 5);
            nextPoints[1] = new Point(4, 0, 2);
            nextPoints[2] = new Point(5, 5, 0);

            var paritalSolutions = new List<PartialSolution>
            {
                new PartialSolution(startPoint),
                new PartialSolution(startPointTwo)
            };

            var solution = beam.GetNextSolutionSet(new SolutionSet(paritalSolutions.ToArray(), 5), nextPoints, 1);

            Assert.Equal(nextPoints[3], solution.ParitalSolutionList[0].Points[1]);
            Assert.Equal(nextPoints[3], solution.ParitalSolutionList[1].Points[1]);
        }
    }
}
