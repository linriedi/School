using System.Collections.Generic;

namespace TspLib.Algos.Interfaces
{
    public interface IPathFinder
    {
        PathResult Find(Point startPoint, IEnumerable<Point> points);
    }
}
