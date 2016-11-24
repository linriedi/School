namespace TspLib.Algos.BeamSearch
{
    public class BeamLevel
    {
        public Point[] GetBestPoint(Point startPoint, Point[] nextPossiblePoints, int beamWith)
        {
            var bestPoints = new DistanceAndPointIdArray(beamWith);
            for (int i = 0; i < nextPossiblePoints.Length; i++)
            {
                var point = nextPossiblePoints[i];
                var distance = point.CalculateDistanceTo(startPoint);
                bestPoints.InsertIfPossible(distance, point);
            }
            return bestPoints.CreatePointArray();
        }
             
        private class DistanceAndPointId
        {
            public Point Point { get; private set; }
            public double Distance { get; private set; }

            public DistanceAndPointId(Point point, double distance)
            {
                this.Point = point;
                this.Distance = distance;
            }
        }

        private class DistanceAndPointIdArray
        {
            private int emptyCellIndex;
            private readonly DistanceAndPointId[] list;

            public DistanceAndPointIdArray(int length)
            {
                this.list = new DistanceAndPointId[length];
            }

            public void InsertIfPossible(double distance, Point point)
            {
                if(emptyCellIndex < this.list.Length)
                {
                    this.list[emptyCellIndex] = new DistanceAndPointId(point, distance);
                    this.emptyCellIndex++;
                    return;
                }

                for (int i = 0; i < list.Length; i++)
                {
                    if (distance < list[i].Distance)
                    {
                        list[i] = new DistanceAndPointId(point, distance);
                        break;
                    }
                }
            }

            public Point[] CreatePointArray()
            {
                var points = new Point[list.Length];
                for (int i = 0; i < list.Length; i++)
                {
                    points[i] = list[i].Point;
                }
                return points;
            }
        }
    }
}
