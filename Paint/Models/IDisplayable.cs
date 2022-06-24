using System.Windows.Shapes;

namespace Paint.Models
{
    public interface IDisplayable
    {
        Shape CreateShape();
    }
}