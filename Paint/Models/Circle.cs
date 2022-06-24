using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models
{
    public class Circle: Figure, IDisplayable
    { 
        private readonly double _radius;
        private readonly Point _center;


        private Circle(Point firstPoint, Point secondPoint) : base(firstPoint,secondPoint)
        {
            var width = Math.Abs(secondPoint.X - firstPoint.X);
            var height = Math.Abs(secondPoint.Y - firstPoint.Y);
            
            _center.X = firstPoint.X + width / 2;
            _center.Y = firstPoint.Y + height / 2;

            _radius = (height > width) ? width / 2 : height / 2;
        }

        
        public Shape CreateShape()
        {
            Shape shape = new Ellipse();

            shape.Width = _radius * 2;
            shape.Height = _radius * 2;
            shape.StrokeThickness = Thickness;
            shape.Margin = new Thickness(FirstPoint.X, FirstPoint.Y, 0, 0);
            shape.Stroke = new SolidColorBrush(Color);

            return shape;
        }
        
        public static IDisplayable CreateCircle(Queue<Point> points) =>
             points.Count < 2 ? null : new Circle(points.Dequeue(), points.Dequeue());
    }
}
