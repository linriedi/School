using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TspLib;
using TspLib.Algos.BeamSearch;
using Xunit;

namespace tests
{
    public class BeamServiceTests
    {
        [Fact]
        public void Sometest()
        {
            var service = new BeamService();

            var nextPoints = new Point[5];

            nextPoints[0] = new Point(2, 0, 10);
            nextPoints[1] = new Point(3, 0, 2);
            nextPoints[2] = new Point(4, 10, 0);
            nextPoints[3] = new Point(5, 1, 0);
            nextPoints[4] = new Point(6, 10, 10);

            var points = service.GetOptimalPoints(nextPoints);
        }
    }
}
