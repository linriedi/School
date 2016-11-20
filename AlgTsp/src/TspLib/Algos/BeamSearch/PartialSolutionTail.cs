namespace TspLib.Algos.BeamSearch
{
    public class PartialSolutionTail
    {
        public PartialSolution Head { get; private set; }

        public double Distance { get; private set; }

        public Point LastPoint { get; private set; }

        public PartialSolutionTail(PartialSolution partialSolution, Point point)
        {
            this.Head = partialSolution;

            var lastPoint = partialSolution.LastPoint;
            this.Distance = partialSolution.Distance + lastPoint.DistanceTo(point);

            this.LastPoint = point;
        }

        public PartialSolutionTail(PartialSolution partialSolution)
        {
            this.Head = partialSolution;
        }
    }
}
