using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TspLib.FiloIO
{
    public class Printer
    {
        public static void WriteToSVG(Instance instance, IEnumerable<Point> solution, string filePath)
        {
            var solutionPoint = solution.ToList();

            double margin = 100;
            double minX = double.MaxValue;
            double minY = double.MaxValue;
            double maxX = 0;
            double maxY = 0;

            foreach(var point in solutionPoint)
            {
                maxX = Math.Max(maxX, point.X);
                maxY = Math.Max(maxY, point.Y);

                minX = Math.Min(minX, point.X);
                minY = Math.Min(minY, point.Y);
            }

            double xTransform = margin - minX;
            double yTransform = margin - minY;

            int height = (int)(maxY + margin + yTransform), width = (int)(maxX + xTransform + margin);
            var builder = new StringBuilder();
                        
            builder.AppendLine("<html>");
            builder.AppendLine("<head>");
            builder.AppendLine("<style>");
            builder.AppendLine(".hoverbg {background:rgba(255,255,255,0.3);}");
            builder.AppendLine(".hoverbg:hover {background:rgba(255,255,255,1.0);}");
            builder.AppendLine("</style>");
            builder.AppendLine("<title>" + instance.Name + "</title>");
            builder.AppendLine("</head>");
            builder.AppendLine("<body>");
            builder.AppendLine("<div class=\"hoverbg\" style=\"position:absolute; top:10;left:10; z-index:100;\">");
            builder.AppendLine("<p style=\"font-size:30px\">" + instance.Name + "</p>");
            builder.AppendLine("<p style=\"font-size:15px\">" + instance.Comment + "</p>");
            builder.AppendLine("<p style=\"font-size:30px\">Total distance: " + ((int)(Utils.euclideanDistance2D(solutionPoint) * 10) / 10.0) + "</p>");
            builder.AppendLine("</div>");
            builder.AppendLine("<svg viewBox=\"0 0 " + width + " " + height + "\" style=\"position:absolute; top:0; left:0; bottom:0; right:0; z-index:1;\">");

            foreach (var point in solutionPoint)
            {
                var x = (int)(point.X + xTransform);
                var y = (int)(point.Y + yTransform);

                builder.AppendLine("<circle cx=\"" + x + "\" cy=\"" + y + "\" r=\"10\" stroke=\"black\" stroke-width=\"1\" fill=\"black\"/>");
            }

            Point currentPoint = solutionPoint[0];
            for (int i = 1; i < solutionPoint.Count; i++)
            {
                Point nextPoint = solutionPoint[i];
                WriteSVGLine(currentPoint, nextPoint, builder, xTransform, yTransform);
                currentPoint = nextPoint;
            }


            WriteSVGLine(currentPoint, solutionPoint[0], builder, xTransform, yTransform);

            builder.AppendLine("</svg>");
            builder.AppendLine("</body>");
            builder.AppendLine("</html>");

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            var file = File.Create(filePath + ".html");
            using (var logWriter = new StreamWriter(file))
            {
                logWriter.Write(builder);
            };
        }
              
        private static void WriteSVGLine(Point a, Point b, StringBuilder builder, double xTransform, double yTransform)
        {
            builder.AppendLine("<line x1=\"" + (int)(a.X + xTransform) + "\" y1=\"" + (int)(a.Y + yTransform) + "\" x2=\"" + (int)(b.X + xTransform) + "\" y2=\"" + (int)(b.Y + yTransform) + "\" style=\"stroke:rgb(255,0,0);stroke-width:5\"/>");
        }
    }
}
	
	