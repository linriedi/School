using System.Collections.Generic;

namespace TspLib.Extensions
{
    public static class PointsExtensions
    {
        public static double EuclideanLength(this List<Point> points)
        {
            double totalDistance = 0;
            var currentPoint = points[0];
            for (int i = 1; i < points.Count; i++)
            {
                var nextPoint = points[i];
                totalDistance += currentPoint.CalculateDistanceTo(nextPoint);
                currentPoint = nextPoint;
            }

            totalDistance += currentPoint.CalculateDistanceTo(points[0]);
            return totalDistance;
        }
    }
}
