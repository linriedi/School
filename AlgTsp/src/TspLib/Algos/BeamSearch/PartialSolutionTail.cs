namespace TspLib.Algos.BeamSearch
{
    public class PartialSolutionTail
    {
        public int IdOfHead { get; private set; }

        public double Distance { get; private set; }

        public Point LastPoint { get; private set; }

        public PartialSolutionTail(PartialSolution partialSolution, Point point)
        {
            this.IdOfHead = partialSolution.Id;

            var lastPoint = partialSolution.LastPoint;
            this.Distance = partialSolution.Distance + lastPoint.DistanceTo(point);

            this.LastPoint = point;
        }
    }
}
