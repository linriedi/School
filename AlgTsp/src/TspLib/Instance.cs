using System;
using System.Collections.Generic;

namespace TspLib
{
    public class Instance
    {
        public string Name { get; private set; }

        public string Comment { get; private set; }

        public IEnumerable<Point> Points { get; private set; }

        public Instance(String name, String comment, IEnumerable<Point> points)
        {
            this.Name = name;
            this.Comment = comment;
            this.Points = points;
        }
    }
}
