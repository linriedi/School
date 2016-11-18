using System.Collections.Generic;
using TspLib;
using Xunit;

namespace tests
{
    public class PilotMethodTests
    {
        [Fact]
        public void CalculateLength()
        {
            var points = new List<Point>
            {
                new Point(3, 0, 0),
                new Point(6, 1, 0),
                new Point(4, 2, 0),
                new Point(1, 2, 2),
                new Point(5, 1, 2),
                new Point(2, 0, 2)
            };

            var test = new PilotMethod().Solve(new Instance("", "", points));
        }

        [Fact]
        public void CalculateLength_OnlyTwo()
        {
            var points = new List<Point>
            {
                new Point(4, 2, 0),
                new Point(1, 2, 2),
                new Point(5, 1, 2)
            };

            var test = new PilotMethod().Solve(new Instance("", "", points));
        }

        [Fact]
        public void CalculateLength_OnlyFour()
        {
            var points = new List<Point>
            {
                new Point(4, 2, 0),
                new Point(1, 2, 2),
                new Point(5, 1, 2),
                new Point(2, 1, 0)
            };

            var test = new PilotMethod().Solve(new Instance("", "", points));
        }
    }
}
