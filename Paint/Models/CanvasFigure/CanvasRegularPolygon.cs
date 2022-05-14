using System;
using System.Windows.Shapes;
using Point = System.Windows.Point;

namespace Paint.Models.CanvasFigure
{
    public class CanvasRegularPolygon: RegularPolygon, IDisplayable
    {
        public Shape CreateShape()
        {
            var shape = new Polygon();
            
            var n = CountOfEdges;
            double l = LengthOfEdge;

            var rad = l / (2 * Math.Sin(Math.PI / n));
            for (var i = 0; i < n; ++i)
            {
                var x = rad * Math.Cos(Math.PI / n * (2 * i + 1));
                var y = rad * Math.Sin(Math.PI / n * (2 * i + 1));
                shape.Points.Add(new Point(x + Offset.X, y + Offset.Y));
            }

            return shape;
        }

        public CanvasRegularPolygon(Point offset, int countOfEdges, double lengthOfEdge) : base(offset, countOfEdges, lengthOfEdge)
        {
            
        }
    }
}