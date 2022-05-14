using System.Windows;

namespace Paint.Models
{
    public class Circle: Figure
    {
        protected readonly double Radius;

 
        public Circle(Point offset, double radius) : base(offset) => Radius = radius;

    }
}
