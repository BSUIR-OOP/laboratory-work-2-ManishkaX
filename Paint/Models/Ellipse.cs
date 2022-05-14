using System.Windows;

namespace Paint.Models
{
    public class Ellipse : Figure
    {
        protected double AxisX;
        protected double AxisY;


        public Ellipse(Point offset, double axisX, double axisY) : base(offset)
        {
            AxisX = axisX;
            AxisY = axisY;
        }
    }
}
