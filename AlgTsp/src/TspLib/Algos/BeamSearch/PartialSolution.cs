using System;
using System.Linq;

namespace TspLib.Algos.BeamSearch
{
    public class PartialSolution
    {
        private PartialSolution partialSolutionToAttachTo;
        private PartialSolutionTail partialSolutionTail;
        private int i;

        public Point[] Points { get; private set; }

        public Point LastPoint { get; private set; }

        public double Distance { get; private set; }

        public int Id { get; private set; }

        public PartialSolution(PartialSolution paritalSolution, PartialSolutionTail partialSolutionTail, int id)
        {
            this.Id = id;

            var points = paritalSolution.Points.ToList();
            points.Add(partialSolutionTail.LastPoint);
            this.Points = points.ToArray();

            var length = this.Points.Length;
            this.Distance += this.Points[length - 2].DistanceTo(this.Points[length - 1]);

            this.LastPoint = partialSolutionTail.LastPoint;
        }

        public PartialSolution(Point startPoint)
        {
            this.Points = new Point[1];
            this.Points[0] = startPoint;

            this.LastPoint = startPoint;
        }
    }
}
