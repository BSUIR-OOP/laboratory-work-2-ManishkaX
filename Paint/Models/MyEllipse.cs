using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Paint.Models
{
    public class MyEllipse : Figure, IDisplayable
    {
        private readonly double _axisX;
        private readonly double _axisY;


        private MyEllipse(Point firstPoint, Point secondPoint) : base(firstPoint, secondPoint)
        {
            _axisX = Math.Abs((secondPoint.X - firstPoint.X) / 2);
            _axisY = Math.Abs((secondPoint.Y - firstPoint.Y) / 2);
        }
        
        public Shape CreateShape()
        {
            Shape shape = new Ellipse();

            shape.Width = _axisX * 2;
            shape.Height = _axisY * 2;
            shape.Stroke = new SolidColorBrush(Color);
            shape.StrokeThickness = Thickness;
            shape.Margin = new Thickness(FirstPoint.X, FirstPoint.Y, 0, 0);

            return shape;
        }
        
        public static IDisplayable CreateEllipse(Queue<Point> points) =>
             points.Count < 2 ? null : new MyEllipse(points.Dequeue(), points.Dequeue());
    }
}
