using System.Windows.Shapes;

namespace Paint.Models.CanvasFigure
{
    public interface IDisplayable
    {
        Shape CreateShape();
    }
}