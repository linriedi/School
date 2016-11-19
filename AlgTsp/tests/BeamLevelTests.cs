using TspLib;
using TspLib.Algos.BeamSearch;
using Xunit;

namespace tests
{
    public class BeamLevelTests
    {
        [Fact]
        public void CalculateLength()
        {
            var beam = new BeamLevel();

            var startPoint = new Point(1, 0, 0);
            var nextPoints = new Point[4];

            nextPoints[0] = new Point(2, 0, 10);
            nextPoints[1] = new Point(3, 0, 2);
            nextPoints[2] = new Point(4, 10, 0);
            nextPoints[3] = new Point(5, 1, 0);

            var bestPoints = beam.GetBestPoint(startPoint, nextPoints, 2);

            Assert.Equal(nextPoints[3], bestPoints[0]);
            Assert.Equal(nextPoints[1], bestPoints[1]);
        }
    }
}
