using System.Windows;

namespace Paint.Models
{
    public class Triangle : Figure
    {
        protected Point[] Vertices;


        public Triangle(Point offset, Point p1, Point p2, Point p3) : base(offset)
        {
            Vertices = new Point[]{p1, p2, p3};
            //Array.Sort(_vertices, (p1, p2) => p1.Item1.CompareTo(p2.Item1));
        }
    }
}

