using System.Windows;
using System.Windows.Media;

namespace Paint.Models
{
    public abstract class Figure
    {
        protected Point Offset;


        public Color Color { get; set; }

        public double Thickness { get; set; }


        protected Figure(Point offset)
        {
            Color = Color.FromRgb(255, 40, 40);
            Thickness = 5;
            Offset = offset;
        }
        
    }
}
