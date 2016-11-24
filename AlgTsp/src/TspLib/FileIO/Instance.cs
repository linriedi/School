using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TspLib.FiloIO
{ 
    public class Instance
    {
        private static int NAME_INDEX = 0, COMMENT_INDEX = 1;

        public string Name { get; private set; }

        public string Comment { get; private set; }

        public IEnumerable<Point> Points { get; private set; }

        public static Instance Load(string filePath)
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

        private Instance(String name, String comment, IEnumerable<Point> points)
        {
            this.Name = name;
            this.Comment = comment;
            this.Points = points;
        }
    }
}
