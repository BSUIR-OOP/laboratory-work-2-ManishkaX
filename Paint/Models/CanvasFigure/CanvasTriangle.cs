using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models.CanvasFigure
{
    public class CanvasTriangle: Triangle, IDisplayable
    {
        public Shape CreateShape()
        {
            Polygon shape = new Polygon();
            
            foreach (var vertex in Vertices)
            {
                shape.Points.Add(vertex);
            }
            shape.Margin = new Thickness(0, 0, 0, 0);
            shape.Stroke = new SolidColorBrush(Color);
            shape.StrokeThickness = Thickness;
            
            
            return shape;
        }

        public CanvasTriangle(Point offset, Point p1, Point p2, Point p3) : base(offset, p1, p2, p3)
        {
            
        }
    }
}