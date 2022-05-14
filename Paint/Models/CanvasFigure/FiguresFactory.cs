using System;
using System.Collections;
using System.Collections.Generic;
using Paint.Models.CanvasFigure;
using Point = System.Windows.Point;

namespace Paint
{
    public static class FiguresFactory
    {
        public static IDisplayable CreateCircle(Queue<Point> points)
        {
            if (points.Count < 2)
            {
                return null;
            }

            var center = points.Dequeue();
            var point = points.Dequeue();
            var radius = Math.Round(Math.Sqrt(Math.Pow((center.X - point.X), 2) + Math.Pow((center.Y - point.Y), 2)));
            CanvasCircle circle = new CanvasCircle(point, radius);
            
            return circle;
        }

        public static IDisplayable CreateEllipse(Queue<Point> points)
        {
            if (points.Count < 2)
            {
                return null;
            }
            
            var point = points.Dequeue();
            var axises = points.Dequeue();
            CanvasEllipse ellipse = new CanvasEllipse(point, axises.X, axises.Y);
            
            return ellipse;
        }

        public static IDisplayable CreateRectangle(Queue<Point> points)
        {
            if (points.Count < 2)
            {
                return null;
            }

            var firstPoint = points.Dequeue();
            var secondPoint= points.Dequeue();
            CanvasRectangle rectangle = new CanvasRectangle(firstPoint, secondPoint.X, secondPoint.Y);

            return rectangle;
        }

        public static IDisplayable CreateSegment(Queue<Point> points)
        {
            if (points.Count < 2)
            {
                return null;
            }

            var firstPoint = points.Dequeue();
            var secondPoint = points.Dequeue();
            CanvasSegment segment = new CanvasSegment(firstPoint, secondPoint);

            return segment;
        }

        public static IDisplayable CreateTriangle(Queue<Point> points)
        {
            if (points.Count < 3)
            {
                return null;
            }
            var firstPoint = points.Dequeue();
            var secondPoint = points.Dequeue();
            var thirdPoint = points.Dequeue();
            var fourthPoint = points.Dequeue();
            CanvasTriangle triangle = new CanvasTriangle(firstPoint, secondPoint, thirdPoint, fourthPoint);

            return triangle;
        }

        public static IDisplayable CreateRegularPolygon(Queue<Point> points)
        {
            if (points.Count < 2)
            {
                return null;
            }
           
            var count = points.Count;
            var point = points.Dequeue();
            var secondPoint = points.Dequeue();
            var lenght = Math.Round(Math.Sqrt(Math.Pow((point.X - secondPoint.X), 2) + Math.Pow((point.Y - secondPoint.Y), 2)));
            
            CanvasRegularPolygon regularPolygon = new CanvasRegularPolygon(point, count, lenght);

            return regularPolygon;
        }
    }
}