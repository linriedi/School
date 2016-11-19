using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeuLib.Extensions;

namespace TspLib.Algos
{
    public class PilotMethod : ISolver
    {
        private readonly IPathFinder pathFinder;

        public PilotMethod(IPathFinder pathFinder)
        {
            this.pathFinder = pathFinder;
        }

        public string Id
        {
            get
            {
                return "PilotMethod";
            }
        }

        public IEnumerable<Point> Solve(Instance instance)
        {
            var sortedPoints = instance
                .Points
                .OrderBy(p => p.Id);

            var startPoint = sortedPoints.First();
            var nextPoints = sortedPoints
                .WithoudFirst();

            var list = this.NewMethod(startPoint, startPoint, nextPoints);
            list.Add(startPoint);
            list.Reverse();
            return list;
        }

        private List<Point> NewMethod(Point startPoint, Point currentPoint, IEnumerable<Point> fromSecond)
        {
            var results = new List<PathResult>();
            Parallel.ForEach(fromSecond, point =>
            {
                var result = this.pathFinder.Find(point, fromSecond.Except(new List<Point> { point }));

                //TODO experiment if needed or not
                //result.Plus(result.LastPoint.DistanceTo(startPoint));

                result.AddFirstPoint(point);
                results.Add(result);
            });

            var nextPoint = results
                .OrderBy(r => r.Distance)
                .First()
                .FirstPoint;
                        
            var nextPoints = fromSecond.Except(new List<Point> { nextPoint });
            if (nextPoints.Count() > 1)
            {
                var list = this.NewMethod(startPoint, nextPoint, nextPoints);
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
