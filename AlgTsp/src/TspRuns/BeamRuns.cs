using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TspLib;
using TspLib.Algos.BeamSearch;
using Xunit;

namespace TspRuns
{
    public class BeamRuns
    {
        [Fact]
        public void BeamService()
        {
            var service = new TspService(new BeamService());
            service.Run("pr2392");
        }
    }
}
