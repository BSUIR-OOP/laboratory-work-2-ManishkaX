using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models
{
    public class RightTriangle : Figure, IDisplayable
    {
        private readonly PointCollection _vertices;


        public RightTriangle(Point firstPoint, Point secondPoint) : base(firstPoint, secondPoint)
        {
            var thirdPoint = new Point(secondPoint.X, firstPoint.Y);

            _vertices = new PointCollection
            {
                firstPoint,
                thirdPoint,
                secondPoint
            };
        }
        
        public Shape CreateShape()
        {
            var shape = new Polygon
            {
                Margin = new Thickness(0, 0, 0, 0),
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = Thickness
            };

            foreach (var vertex in _vertices)
            {
                shape.Points.Add(vertex);
            }
            
            return shape;
        }
        
        public static IDisplayable CreateRightTriangle(Queue<Point> points) =>
            points.Count < 2 ? null : new RightTriangle(points.Dequeue(), points.Dequeue());
    }
}

