using System.Collections.Generic;
using System.Linq;
using HeuLib.Extensions;

namespace TspLib.Algos
{
    public class PilotMethod : ISolver
    {
        public IEnumerable<Point> Solve(Instance instance)
        {
            var sortedPoints = instance
                .Points
                .OrderBy(p => p.Id);

            var startPoint = sortedPoints.First();
            var nextPoints = sortedPoints
                .WithoudFirst();

            var list = NewMethod(startPoint, startPoint, nextPoints);
            list.Add(startPoint);
            list.Reverse();
            return list;
        }

        private static List<Point> NewMethod(Point startPoint, Point currentPoint, IEnumerable<Point> fromSecond)
        {
            var results = new List<NNResult>();
            foreach (var point in fromSecond)
            {
                var result = NearestNeighbour.CalculateLength(point, fromSecond.Except(new List<Point> { point }));
                result.Plus(result.LastPoint.DistanceTo(startPoint));
                result.AddFirstPoint(point);
                results.Add(result);
            }

            var nextPoint = results
                .OrderBy(r => r.Distance)
                .First()
                .FirstPoint;
                        
            var nextPoints = fromSecond.Except(new List<Point> { nextPoint });
            if (nextPoints.Count() > 1)
            {
                var list = NewMethod(startPoint, nextPoint, nextPoints);
                list.Add(nextPoint);
                return list;
            }
            else
            {
                return new List<Point> { nextPoints.Single(), nextPoint };
            }
        }
    }
}
