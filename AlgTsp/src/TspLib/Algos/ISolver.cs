using System.Collections.Generic;

namespace TspLib.Algos
{
    public interface ISolver
    {
        IEnumerable<Point> Solve(Instance instance);
    }
}
