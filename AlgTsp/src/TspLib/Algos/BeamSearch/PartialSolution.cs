using System;
using System.Linq;

namespace TspLib.Algos.BeamSearch
{
    public class PartialSolution
    {
        public Point[] Points { get; private set; }

        public double Distance { get; private set; }

        public PartialSolution(PartialSolution paritalSolution, Point point)
        {
            var points = paritalSolution.Points.ToList();
            points.Add(point);
            this.Points = points.ToArray();

            var length = this.Points.Length;
            this.Distance += this.Points[length - 2].DistanceTo(this.Points[length - 1]);
        }

        public PartialSolution(Point startPoint)
        {
            this.Points = new Point[1];
            this.Points[0] = startPoint;
        }
    }
}
