using System;

namespace TspLib
{
    public class Point
    {
        public int Id { get; private set; }

        public double X { get; private set; }

        public double Y { get; private set; }

        public Point(int id, double x, double y)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
        }

        public double CalculateDistanceTo(Point otherPoint)
        {
            var deltaX = this.X - otherPoint.X;
            var deltaY = this.Y - otherPoint.Y;

            return Math.Sqrt(deltaX*deltaX + deltaY*deltaY);
        }
    }
}
