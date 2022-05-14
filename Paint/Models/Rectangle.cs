using System.Windows;

namespace Paint.Models
{
    public class Rectangle : Figure
    {
        protected double Width;
        protected double Height;

        public Rectangle(Point offset, double width, double height) : base(offset)
        {
            Width = width;
            Height = height;
        }
    }
}
