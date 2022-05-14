using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models.CanvasFigure
{
    public class CanvasCircle: Circle, IDisplayable
    {
        public Shape CreateShape()
        {
            Shape shape = new System.Windows.Shapes.Ellipse();

            shape.Width = Radius * 2;
            shape.Height = Radius * 2;
            shape.StrokeThickness = Thickness;
            shape.Margin = new Thickness(Offset.X, Offset.Y, 0, 0);
            shape.Stroke = new SolidColorBrush(Color);

            return shape;
        }

        public CanvasCircle(Point offset, double raduis) : base(offset, raduis)
        {
            
        }
    }
}