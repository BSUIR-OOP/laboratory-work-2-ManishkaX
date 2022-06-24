using System.Windows;
using System.Windows.Media;

namespace Paint.Models
{
    public abstract class Figure
    {
        protected Point FirstPoint;

        protected Point SecondPoint;
        
        protected Color Color { get; }

        protected double Thickness { get; }


        protected Figure(Point firstPoint, Point secondPoint)
        {
            Color = Color.FromRgb(255, 40, 40);
            Thickness = 5;
            
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
        }
        
    }
}
