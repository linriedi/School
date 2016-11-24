using System;
using System.Collections.Generic;
using System.Linq;
using HeuLib.Extensions;

namespace TspLib.Algos
{
    public class NearestNeighbour : IPathFinder
    {
        public PathResult Find(Point startPoint, IEnumerable<Point> points)
        {
            return GetDistanceToNearestNeightbourOfFirstElement(startPoint, points);
        }

        private static PathResult GetDistanceToNearestNeightbourOfFirstElement(Point currentPoint, IEnumerable<Point> points)
        {
            var sortedNextPoints = points
                .OrderBy(p => p.CalculateDistanceTo(currentPoint));

            var distance = sortedNextPoints
                    .First()
                    .CalculateDistanceTo(currentPoint);

            var nextPoints = sortedNextPoints.WithoudFirst();
            if (nextPoints.Any())
            {
                return GetDistanceToNearestNeightbourOfFirstElement(sortedNextPoints.First(), nextPoints)
                    .Plus(distance);
            }
            else
            {
                return new PathResult(distance, points.Single());
            }
        }
    }
}
