using System;
using System.Linq;
using TspLib;
using TspLib.Algos;
using TspLib.Algos.BeamSearch;

namespace TspConsole
{
    public class Program
    {
        private static string workPath = @"C:\Users\linri\Desktop\Tsp\";
        private static string instancePath = workPath + @"TSP_Instances\";
        private static string htmlPath = workPath + @"TSP_Solutions\";

        public static void Main(string[] args)
        {
            //runSingleTSPInstance("berlin52");
            //runSingleTSPInstance("bier127", new PilotMethod(new NearestNeighbour()));
            //runSingleTSPInstance("pr1002", new PilotMethod(new NearestNeighbour()));
            //runSingleTSPInstance("pr2392");
            //runSingleTSPInstance("rl5915");
            //runSingleTSPInstance("sw24978");
            //runSingleTSPInstance("reseau_suisse");

            //Beam
            runSingleTSPInstance("berlin52", new BeamService());
            //runSingleTSPInstance("bier127", new BeamService());
            //runSingleTSPInstance("pr1002", new BeamService());
            //runSingleTSPInstance("pr2392", new BeamService());
            //runSingleTSPInstance("rl5915", new BeamService());
            //runSingleTSPInstance("sw24978");
            //runSingleTSPInstance("reseau_suisse", new BeamService());

            //runRandomInstances(20);
            Console.ReadLine();
        }

        private static void runSingleTSPInstance(string instanceName, ISolver solver)
        {
            Console.WriteLine("Loading instance " + instanceName + "...");

            Instance instance = Instance.load(instancePath + instanceName);

            Console.WriteLine("Instance has " + instance.Points.Count() + " points.");

            Console.WriteLine("Start generating a solution...");
            var solution = solver.Solve(instance);

            Console.WriteLine("Solution for " + instanceName + " has length: " + Utils.euclideanDistance2D(solution.ToList()));
            Console.WriteLine();

            // Generate Visualization of Result, will be stored in directory pathToSolutions
            Printer.writeToSVG(instance, solution, htmlPath + solver.Id + "\\" + instanceName);
        }
    }
}
