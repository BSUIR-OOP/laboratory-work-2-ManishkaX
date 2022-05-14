using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint.Models.CanvasFigure
{
    public class CanvasRectangle: Rectangle, IDisplayable
    {
        public Shape CreateShape()
        {
            Shape shape = new System.Windows.Shapes.Rectangle();

            shape.Width = Width;
            shape.Height = Height;
            shape.Stroke = new SolidColorBrush(Color);
            shape.StrokeThickness = Thickness;
            shape.Margin = new Thickness(Offset.X, Offset.Y, 0, 0);

            return shape;
        }

        public CanvasRectangle(Point offset, double width, double height) : base(offset, width, height)
        {
            
        }
    }
}