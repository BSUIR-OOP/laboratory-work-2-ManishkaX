using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models
{
    public class RegularPolygon : Figure, IDisplayable
    {
        private readonly int _countOfEdges;

        private readonly Point _center;
        private readonly double _radius;

        private RegularPolygon(Point firstPoint, Point secondPoint) : base(firstPoint, secondPoint)
        {
            var width = Math.Abs(secondPoint.X - firstPoint.X);
            var height = Math.Abs(secondPoint.Y - firstPoint.Y);
            
            _center.X = firstPoint.X + width / 2;
            _center.Y = firstPoint.Y + height / 2;

            _radius = (height > width) ? width / 2 : height / 2;
            
            var random = new Random();
             _countOfEdges = random.Next(3, 15);
        }
        
        public Shape CreateShape()
        {
            var shape = new Polygon
            {
                Margin = new Thickness(0, 0, 0, 0),
                StrokeThickness = Thickness,
                Stroke = new SolidColorBrush(Color)
            };

            for (var i = 0; i < _countOfEdges; ++i)
            {
                var x = _radius * Math.Cos(Math.PI / _countOfEdges * (2 * i + 1));
                var y = _radius * Math.Sin(Math.PI / _countOfEdges * (2 * i + 1));
                shape.Points.Add(new Point(x + _center.X, y + _center.Y));
            }

            return shape;
        }
        
        public static IDisplayable CreateRegularPolygon(Queue<Point> points) =>
             points.Count < 2 ? null : new RegularPolygon(points.Dequeue(), points.Dequeue());
        
    }
}
