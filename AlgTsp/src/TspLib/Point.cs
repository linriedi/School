using System;

namespace TspLib
{
    public class Point
    {
        public int Id { get; private set; }

        private double x, y;

        internal double DistanceTo(Point otherPoint)
        {
            var deltaX = this.x - otherPoint.x;
            var deltaY = this.y - otherPoint.y;

            return Math.Sqrt(deltaX*deltaX + deltaY*deltaY);
        }

        /**
         * Instantiate a new point with the given coordinates.
         * @param id The id of this point. Ids among points of the same problem should be distinct.
         * @param x The x coordinate.
         * @param y The y coordinate.
         */
        public Point(int id, double x, double y)
        {
            this.Id = id;
            this.x = x;
            this.y = y;
        }
              
        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }
    }
}
