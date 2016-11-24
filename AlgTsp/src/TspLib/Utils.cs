using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TspLib
{
    public class Utils
    {
        /**
         * Get the Euclidean distance between two points in 2D.
         * 
         * @param a
         * @param b
         * @return
         */
        public static double euclideanDistance2D(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        /**
         * Get the cost for a whole trip using the Euclidean distance. The way from
         * the last point in the list to the start is included.
         * 
         * @param points
         * @return
         */
        public static double euclideanDistance2D(List<Point> points)
        {
            double totalDistance = 0;

            Point currentPoint = points[0];
            for (int i = 1; i < points.Count; i++)
            {
                Point nextPoint = points[i];
                totalDistance += euclideanDistance2D(currentPoint, nextPoint);
                currentPoint = nextPoint;
            }

            totalDistance += euclideanDistance2D(currentPoint, points[0]);

            return totalDistance;
        }

        /**
         * Get the point with the lowest id.
         * 
         * @param points
         * @return
         */
        public static Point getLowestIdPoint(IEnumerable<Point> points)
        {
            return points
                .OrderBy(p => p.Id)
                .First();
        }

        //       /**
        //* Generate a random instance.
        //* 
        //* @param name
        //*            The name of the generated instance.
        //* @param comment
        //*            The comment for the generated instance.
        //* @param numPoints
        //*            The amount of points to generate randomly.
        //* @return An instance with given name and comment and randomly distributed
        //*         points.
        //*/
        //public static Instance getRandomTspInstance(String name, String comment, int numPoints)
        //{
        //    int maxX = 2000;
        //    int maxY = 2000;

        //    Random rand = new SecureRandom();

        //    IEnumerable<Point> points = new HashSet<Point>(numPoints);
        //    int id = 0;

        //    for (int i = 0; i < numPoints; i++)
        //    {
        //        int x = rand.nextInt(maxX);
        //        int y = rand.nextInt(maxY);

        //        points.add(new Point(id, x, y));
        //        id += 1;
        //    }
        //    return new Instance(name, comment, points);
        //}

            //    
            //}

            //        /**
            //        * Get an iterator over all possible distinct permutations in
            //        * lexicographical order (by {@link Point} id) </br>
            //        * [1,3,2] -> [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
            //        * 
            //        * @param points
            //        *            The points to get permutations for.
            //        * @return An iterator over all possible permutations. Starts with the first
            //        *         permutation in lexicographical order.
            //        */
            //        public static Iterator<List<Point>> getAllPermutations(Collection<Point> points)
            //        {
            //        return new PermutationIterator(points);
            //        }

            /**
            * Get an iterator over all possible distinct permutations in
            * lexicographical order starting with the given permutation (by {@link Point} id) </br>
            * [1,3,2] -> [[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1],[1,2,3]]
            * 
            * @param points
            *            The points to get permutations for.
            * @return An iterator over all possible permutations. Starts with the given permutation.
            */
            //public static Iterator<List<Point>> getAllPermutations(List<Point> points)
            //{
            //return new PermutationIterator(points);
            //}

            ///**
            //* 
            //* @author Marek Arnold (arnd@zhaw.ch)
            //* 
            //*         Iterator over all possible permutations in lexicographical order.
            //*/
            //public static class PermutationIterator implements Iterator<List<Point>> {

            //private final List<Point> points;

            //private List<Point> nextPermutation;

            /**
             * Instantiate a new {@link Iterator} beginning with the first permutation in lexicographical order.
             * @param points The points to generate permutations for.
             */
            //public PermutationIterator(Collection<Point> points)
            //{
            //    this.points = new ArrayList<>(points);
            //    this.points.sort((p1, p2) ->Integer.compare(p1.getId(), p2.getId()));
            //    this.nextPermutation = this.points;
            //}

            /**
             * Instantiate an {@link Iterator} beginning with the given permutation.
             * @param points The points in the permutation to begin with.
             */
            //public PermutationIterator(List<Point> points)
            //{
            //    this.points = new ArrayList<>(points);
            //    this.nextPermutation = this.points;
            //}


            //        public boolean hasNext()
            //{
            //    return nextPermutation != null;
            //}


            //        public List<Point> next()
            //{
            //    List<Point> res = nextPermutation;
            //    nextPermutation = getNextPermutation(nextPermutation);

            //    //All permutations visited, therefore stop iterator.
            //    if (nextPermutation.equals(points))
            //    {
            //        nextPermutation = null;
            //    }

            //    return res;
            //}

            //private static List<Point> getNextPermutation(List<Point> points)
            //{
            //    List<Point> result = new ArrayList<>(points);

            //    int k = result.size() - 2;
            //    while (result.get(k).getId() >= result.get(k + 1).getId())
            //    {
            //        k--;
            //        if (k < 0)
            //        {
            //            result.sort((p1, p2) ->Integer.compare(p1.getId(), p2.getId()));
            //            return result;
            //        }
            //    }
            //    int l = result.size() - 1;
            //    while (result.get(k).getId() >= result.get(l).getId())
            //    {
            //        l--;
            //    }
            //    Point p = result.get(k);
            //    result.set(k, result.get(l));
            //    result.set(l, p);

            //    int length = result.size() - (k + 1);
            //    for (int i = 0; i < length / 2; i++)
            //    {

            //        p = result.get(k + 1 + i);
            //        result.set(k + 1 + i, result.get(result.size() - i - 1));
            //        result.set(result.size() - i - 1, p);
            //    }
            //    return result;
            //}
            //	}
        }
}
