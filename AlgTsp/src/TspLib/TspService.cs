using System;
using System.Linq;
using TspLib.Algos;

namespace TspLib
{
    public class TspService
    {
        private static string workPath = @"C:\Users\linri\Desktop\Tsp\";
        private static string instancePath = workPath + @"TSP_Instances\";
        private static string htmlPath = workPath + @"TSP_Solutions\";

        private readonly ISolver solver;

        public TspService(ISolver solver)
        {
            this.solver = solver;
        }

        public void Run(string instanceName)
        {
            Console.WriteLine("Loading instance " + instanceName + "...");

            Instance instance = Instance.load(instancePath + instanceName);

            Console.WriteLine("Instance has " + instance.Points.Count() + " points.");

            Console.WriteLine("Start generating a solution...");
            var solution = this.solver.Solve(instance);

            Console.WriteLine("Solution for " + instanceName + " has length: " + Utils.euclideanDistance2D(solution.ToList()));
            Console.WriteLine();

            // Generate Visualization of Result, will be stored in directory pathToSolutions
            Printer.writeToSVG(instance, solution, htmlPath + this.solver.Id + "\\" + instanceName);
        }
    }
}
