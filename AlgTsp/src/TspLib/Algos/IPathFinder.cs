using System.Collections.Generic;

namespace TspLib.Algos
{
    public interface IPathFinder
    {
        PathResult Find(Point startPoint, IEnumerable<Point> points);
    }
}
