using System.Collections.Generic;

namespace TspLib.Algos
{
    public interface ISolver
    {
        string Id { get; }

        IEnumerable<Point> Solve(Instance instance);
    }
}
