namespace TspLib.Algos
{
    public class PathResult
    {
        public double Distance { get; private set; }
        public Point LastPoint { get; private set; }

        public Point FirstPoint { get; private set; }

        public PathResult(double distance, Point point)
        {
            this.Distance = distance;
            this.LastPoint = point;
        }

        public PathResult Plus(double distance)
        {
            this.Distance += distance;
            return this;
        }

        internal void AddFirstPoint(Point point)
        {
            this.FirstPoint = point; ;
        }
    }
}
