namespace TspLib.Algos
{
    public class NNResult
    {
        public double Distance { get; private set; }
        public Point LastPoint { get; private set; }

        public Point FirstPoint { get; private set; }

        public NNResult(double distance, Point point)
        {
            this.Distance = distance;
            this.LastPoint = point;
        }

        public NNResult Plus(double distance)
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
