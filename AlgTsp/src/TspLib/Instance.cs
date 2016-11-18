using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TspLib
{ 
    public class Instance
    {
        private static int NAME_INDEX = 0, COMMENT_INDEX = 1;
        private string name;
	    private string comment;

	    public IEnumerable<Point> Points { get; private set; }

        /**
         * Load a TSP instance from a given file.
         * 
         * @param filePath
         *            The path to the file.
         * @return The loaded TSP instance.
         * @throws IOException
         *             If an exception occurs while reading the file.
         */
        public static Instance load(string filePath)
        {
            
            var lines = File.ReadAllLines(filePath + ".tsp", System.Text.Encoding.UTF8);
            var header = lines.Take(2).ToArray();
                      
            var pointLines = lines
                .Reverse()
                .Take(lines.Count() - 2)
                .Reverse();

            var points = new List<Point>();
            foreach (var pointLine in pointLines)
            {
                var splitted = pointLine.Split('\t');
                points.Add(new Point(
                    int.Parse(splitted[0]),
                    int.Parse(splitted[1]),
                    int.Parse(splitted[2])));
            }
            
            var name = header[NAME_INDEX].Split('\t')[1];
            var comment = header[COMMENT_INDEX].Split('\t')[1];

            return new Instance(name, comment, points);
            }

        /**
         * Create a new TSP instance.
         * 
         * @param name
         *            The name of this instance.
         * @param comment
         *            A comment about this instance.
         * @param points
         *            The points.
         */
        public Instance(String name, String comment, IEnumerable<Point> points)
        {
            this.name = name;
            this.comment = comment;
            this.Points = points;
        }

        public String getName()
        {
            return name;
        }

        public String getComment()
        {
            return comment;
        }
    }
}
