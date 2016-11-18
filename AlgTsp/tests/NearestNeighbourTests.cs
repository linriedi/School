using System.Collections.Generic;
using TspLib;
using TspLib.Algos;
using Xunit;

namespace tests
{
    public class NearestNeighbourTests
    {
        [Fact]
        public void CalculateLength()
        {
            var first = new Point(2, 0, 2.5);
            var points = new List<Point>
            {
                new Point(4, 0, 1.5),
                new Point(3, 0, 0.5),
                new Point(1, 0.5, 2),
                new Point(5, 0.5, 1),
                new Point(6, 0.5, 0)
            };

            var lenght = NearestNeighbour.CalculateLength(first, points);
        }

        [Fact]
        public void CalculateLength_OnlyFew()
        {
            var first = new Point(2, 0, 2.5);
            var points = new List<Point>
            {
                new Point(1, 0.5, 2),
                new Point(4, 0, 1.5),
            };

            var lenght = NearestNeighbour.CalculateLength(first, points);
        }

        [Fact]
        public void CalculateLength_OnlyOne()
        {
            var first = new Point(2, 0, 2.5);
            var points = new List<Point>
            {
                new Point(1, 0.5, 2)
            };

            var lenght = NearestNeighbour.CalculateLength(first, points);
        }
    }
}
