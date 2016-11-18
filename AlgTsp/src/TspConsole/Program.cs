using System;
using System.Linq;
using TspLib;
using TspLib.Algos;

namespace TspConsole
{
    public class Program
    {
        private static string workPath = @"C:\Users\linri\Desktop\Tsp\";
        private static string instancePath = workPath + @"TSP_Instances\";
        private static string htmlPath = workPath + @"TSP_Solutions\";

        public static void Main(string[] args)
        {
            runSingleTSPInstance("berlin52");
            //runSingleTSPInstance("bier127");
            //runSingleTSPInstance("pr1002");
            //runSingleTSPInstance("pr2392");
            //runSingleTSPInstance("rl5915");
            //runSingleTSPInstance("sw24978");
            //runSingleTSPInstance("reseau_suisse");

            //runRandomInstances(20);
            Console.ReadLine();
        }

        private static void runSingleTSPInstance(String instanceName)
        {
            String solutionName = instanceName;

            String pathToInstances = "TSP_Instances";
            String pathToSolutions = "TSP_Solutions";

            String instanceFilenameExtension = ".tsp";
            String solutionFilenameExtension = ".html";

            String pathToInstance = pathToInstances + "\\" + instanceName + instanceFilenameExtension;
            String pathToSolution = pathToSolutions + "\\" + solutionName + solutionFilenameExtension;

            Console.WriteLine("Loading instance " + instanceName + "...");

            Instance instance = Instance.load(instancePath + instanceName);

            Console.WriteLine("Instance has " + instance.Points.Count() + " points.");

            Console.WriteLine("Start generating a solution...");
            var solution = new GreedyInsertion().Solve(instance);

            Console.WriteLine("Solution for " + instanceName + " has length: " + Utils.euclideanDistance2D(solution.ToList()));
            Console.WriteLine();

            // Generate Visualization of Result, will be stored in directory pathToSolutions
            Printer.writeToSVG(instance, solution, htmlPath + instanceName);
        }
    }
}
