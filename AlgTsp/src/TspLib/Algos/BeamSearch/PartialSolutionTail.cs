using System.Linq;

namespace TspLib.Algos.BeamSearch
{
    public class PartialSolutionTail
    {
        private double tailLenght;

        public PartialSolution Head { get; private set; }

        public double ClosedDistance
        {
            get
            {
                return tailLenght 
                    + this.Head.DistanceOpen
                    + this.LastPoint.DistanceTo(this.Head.Points.First());
            }
        }
               
        public double DistanceOpen
        {
            get
            {
                return this.tailLenght;
            }
        }

        public Point LastPoint { get; private set; }

        public Point[] Points { get; private set; }

        public PartialSolutionTail(PartialSolutionTail fromTail, Point point)
        {
            var points = fromTail.Points.ToList();
            if (points.Any() == false)
            {
                this.tailLenght += fromTail.Head.LastPoint.DistanceTo(point);
            }
            else
            {
                this.tailLenght = fromTail.tailLenght + fromTail.LastPoint.DistanceTo(point);
            }

            points.Add(point);
            this.Points = points.ToArray();

            this.Head = fromTail.Head;         
            this.LastPoint = point;
        }

        public PartialSolutionTail(PartialSolution partialSolution)
        {
            this.Head = partialSolution;
            this.Points = new Point[0];
        }
    }
}
