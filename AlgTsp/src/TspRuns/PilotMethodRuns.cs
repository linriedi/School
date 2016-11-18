using TspLib;
using TspLib.Algos;
using Xunit;

namespace TspRuns
{
    public class PilotMethodRuns
    {
        [Fact]
        public void PilotMethod_Berlin52()
        {
            var service = new TspService(new PilotMethod());
            service.Run("berlin52");
        }

        [Fact]
        public void PilotMethod_PilotTest()
        {
            var service = new TspService(new PilotMethod());
            service.Run("pilotTests");
        }
    }
}
