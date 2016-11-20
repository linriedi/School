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

            var points = new Point[4];

            points[0] = new Point(1, 0, 0);
            points[1] = new Point(2, 0, 1);
            points[2] = new Point(3, 1, 1);
            points[3] = new Point(4, 1, 0);

           fvar solution = service.GetOptimalPoints(points);
        }
    }
}
