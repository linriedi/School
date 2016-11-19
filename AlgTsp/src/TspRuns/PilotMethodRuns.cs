﻿using tests.Infrastructure;
using TspLib;
using TspLib.Algos;
using Xunit;

namespace TspRuns
{
    public class PilotMethodRuns : TestsBase
    {
        public PilotMethodRuns()
        {
            this.Container.Register<IPathFinder, NearestNeighbour>();
            this.Container.Register<ISolver, PilotMethod>();
        }

        [Fact]
        public void PilotMethod_Berlin52()
        {
            var service = new TspService(this.Container.Resolve<ISolver>());
            service.Run("berlin52");
        }

        [Fact]
        public void PilotMethod_PilotTest()
        {
            var service = new TspService(this.Container.Resolve<ISolver>());

            service.Run("pilotTests");
        }
    }
}
