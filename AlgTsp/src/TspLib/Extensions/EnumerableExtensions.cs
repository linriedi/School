using System.Collections.Generic;
using System.Linq;

namespace HeuLib.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> WithoudFirst<T>(this IEnumerable<T> input)
        {
            return input
                .Reverse()
                .Take(input.Count() - 1)
                .Reverse();
        }
    }
}
