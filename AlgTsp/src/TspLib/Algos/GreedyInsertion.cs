using System;
using System.Collections.Generic;
using System.Linq;

namespace TspLib.Algos
{
    public class GreedyInsertion : ISolver
    {
        public string Id
        {
            get
            {
                return "GreedyInsertion";
            }
        }

        public IEnumerable<Point> Solve(Instance instance)
        {
            Point[] points = instance.Points.ToArray();

            //TODO check if ok
            //Arrays.sort(points, (p1, p2) ->Integer.compare(p1.getId(), p2.getId()));
            points = points
                .OrderBy(p => p.Id)
                .ToArray();
            
            //Array with the indices of the next nodes
            int[] nextIndices = new int[points.Count()];

            //Initial partial tour 0 -> 1 -> 0
            nextIndices[0] = 1;

            //Find the best position to insert for each remaining point
            for (int i = 2; i < points.Count(); i++)
            {
                double lowestDistanceIncrease = Double.PositiveInfinity;
                int lowestDistanceIncreaseIdx = -1;

                for (int j = 0; j < i; j++)
                {
                    //Increased cost of tour if point i is inserted in place j
                    double distanceIncrease = Utils.euclideanDistance2D(points[j], points[i]) + Utils.euclideanDistance2D(points[i], points[nextIndices[j]]) - Utils.euclideanDistance2D(points[j], points[nextIndices[j]]);
                    if (distanceIncrease < lowestDistanceIncrease)
                    {
                        lowestDistanceIncrease = distanceIncrease;
                        lowestDistanceIncreaseIdx = j;
                    }
                }

                nextIndices[i] = nextIndices[lowestDistanceIncreaseIdx];
                nextIndices[lowestDistanceIncreaseIdx] = i;
            }

            //Walk along next indices to build solution.
            List<Point> solution = new List<Point>();
            int index = 0;
            for (int i = 0; i < points.Count(); i++)
            {
                solution.Add(points[index]);
                index = nextIndices[index];
            }

            return solution;
        }

    }

}
