using System;
using System.Collections.Generic;
using System.Linq;

namespace TspLib
{
    public class Utils
    {
        public static double euclideanDistance2D(List<Point> points)
        {
            double totalDistance = 0;

            Point currentPoint = points[0];
            for (int i = 1; i < points.Count; i++)
            {
                Point nextPoint = points[i];
                totalDistance += currentPoint.CalculateDistanceTo(nextPoint);
                currentPoint = nextPoint;
            }

            totalDistance += currentPoint.CalculateDistanceTo(points[0]);

            return totalDistance;
        }
    }
}
