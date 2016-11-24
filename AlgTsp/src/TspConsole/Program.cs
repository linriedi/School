using System;
using TspLib;
using TspLib.Algos;

namespace TspConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new TspService(new GreedyInsertion());
            service.Run("berlin52");

            Console.ReadLine();
        }
    }
}
