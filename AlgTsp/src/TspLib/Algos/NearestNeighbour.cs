using System.Collections.Generic;
using System.Linq;
using HeuLib.Extensions;

namespace TspLib.Algos
{
    public class NearestNeighbour
    {
        public static NNResult CalculateLength(Point startPoint, IEnumerable<Point> points)
        {
            return GetDistanceToNearestNeightbourOfFirstElement(startPoint, points);
        }

        private static NNResult GetDistanceToNearestNeightbourOfFirstElement(Point currentPoint, IEnumerable<Point> points)
        {
            var sortedNextPoints = points
                .OrderBy(p => p.DistanceTo(currentPoint));

            var distance = sortedNextPoints
                    .First()
                    .DistanceTo(currentPoint);

            var nextPoints = sortedNextPoints.WithoudFirst();
            if (nextPoints.Any())
            {
                return GetDistanceToNearestNeightbourOfFirstElement(sortedNextPoints.First(), nextPoints)
                    .Plus(distance);
            }
            else
            {
                return new NNResult(distance, points.Single());
            }
        }
    }
}
