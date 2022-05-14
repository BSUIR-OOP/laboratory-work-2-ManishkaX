using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models.CanvasFigure
{
    public class CanvasSegment: Segment, IDisplayable
    {

        

        public Shape CreateShape()
        {
            Shape shape = new Line();

            shape.Width =  Math.Abs(Offset.X - Point.X);
            shape.Height = Math.Abs(Offset.Y - Point.Y);
            shape.Stroke = new SolidColorBrush(Color);
            shape.StrokeThickness = Thickness;
            shape.Margin = new Thickness(Offset.X, Offset.Y, 0, 0);

            return shape;
        }
        
        public CanvasSegment(Point offset, Point point) : base(offset, point)
        {
            
        }
    }
}