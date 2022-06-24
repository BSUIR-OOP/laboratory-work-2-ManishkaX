using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models
{
    public class Segment : Figure, IDisplayable
    {
        private Point _firstPoint;
        private Point _secondPoint;

        public Segment(Point firstPoint, Point secondPoint) : base(firstPoint, secondPoint)
        {
            _firstPoint = firstPoint;
            _secondPoint = secondPoint;
        }
           

        public Shape CreateShape()
        {
            var shape = new Line
            {
                X1 = FirstPoint.X,
                X2 = SecondPoint.X,
                Y1 = FirstPoint.Y,
                Y2 = SecondPoint.Y,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = Thickness,
                Margin = new Thickness(0, 0, 0, 0)
            };


            return shape;
        }
        
        public static IDisplayable CreateSegment(Queue<Point> points) =>
            points.Count < 2 ? null : new Segment(points.Dequeue(), points.Dequeue());
    }
}
