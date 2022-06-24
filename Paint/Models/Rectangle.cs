using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models
{
    public class Rectangle : Figure, IDisplayable
    {
        private readonly double _width;
        private readonly double _height;

        private Rectangle(Point firstPoint, Point secondPoint) : base(firstPoint, secondPoint)
        {
            _width = Math.Abs(secondPoint.X - firstPoint.X);
            _height =Math.Abs(secondPoint.Y - firstPoint.Y);
        }
        
        public Shape CreateShape()
        {
            Shape shape = new System.Windows.Shapes.Rectangle();

            shape.Width = _width;
            shape.Height = _height;
            shape.Stroke = new SolidColorBrush(Color);
            shape.StrokeThickness = Thickness;
            shape.Margin = new Thickness(FirstPoint.X, FirstPoint.Y, 0, 0);

            return shape;
        }
        
        public static IDisplayable CreateRectangle(Queue<Point> points) =>
            points.Count < 2 ? null : new Rectangle(points.Dequeue(), points.Dequeue());
        
    }
}
