using System;
using System.Linq;
using TspLib.Algos;
using TspLib.FiloIO;

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

            var instance = InstanceFactory.Load(instancePath + instanceName);

            Console.WriteLine("Instance has " + instance.Points.Count() + " points.");

            Console.WriteLine("Start generating a solution...");
            var solution = this.solver.Solve(instance.Points);

            Console.WriteLine("Solution for " + instanceName + " has length: " + Utils.euclideanDistance2D(solution.ToList()));
            Console.WriteLine();

            // Generate Visualization of Result, will be stored in directory pathToSolutions
            Printer.WriteToSVG(instance, solution, htmlPath + this.solver.Id + "\\" + instanceName);
        }
    }
}
