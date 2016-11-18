using TspLib;
using TspLib.Algos;
using Xunit;

namespace TspRuns
{
    public class GreedyInsertionRuns
    {
        [Fact]
        public void GreedyInsertion_PilotTests()
        {
            var service = new TspService(new GreedyInsertion());
            service.Run("pilotTests");
        }
        
        [Fact]
        public void GreedyInsertion_Berlin52()
        {
            var service = new TspService(new GreedyInsertion());
            service.Run("berlin52");
        }

        [Fact]
        public void GreedyInsertion_Bier127()
        {
            var service = new TspService(new GreedyInsertion());
            service.Run("bier127");
        }

        [Fact]
        public void GreedyInsertion_Pr1002()
        {
            var service = new TspService(new GreedyInsertion());
            service.Run("pr1002");
        }

        [Fact]
        public void GreedyInsertion_Pr2392()
        {
            var service = new TspService(new GreedyInsertion());
            service.Run("pr2392");
        }

        [Fact]
        public void GreedyInsertion_Rl5915()
        {
            var service = new TspService(new GreedyInsertion());
            service.Run("rl5915");
        }

        [Fact]
        public void GreedyInsertion_Sw24978()
        {
            var service = new TspService(new GreedyInsertion());
            service.Run("sw24978");
        }

        [Fact]
        public void GreedyInsertion_Reseau_suisse()
        {
            var service = new TspService(new GreedyInsertion());
            service.Run("reseau_suisse");
        }
    }
}
