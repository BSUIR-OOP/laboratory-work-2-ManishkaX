using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models.CanvasFigure
{
    public class CanvasEllipse: Ellipse, IDisplayable
    {
        public Shape CreateShape()
        {
            Shape shape = new System.Windows.Shapes.Ellipse();

            shape.Width = AxisX * 2;
            shape.Height = AxisY * 2;
            shape.Stroke = new SolidColorBrush(Color);
            shape.StrokeThickness = Thickness;
            shape.Margin = new Thickness(Offset.X, Offset.Y, 0, 0);

            return shape;
        }
        
        
        public CanvasEllipse(Point offset, double axisX, double axisY): base(offset, axisX, axisY)
        {
            
        }
    }
}