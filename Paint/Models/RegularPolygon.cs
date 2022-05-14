using System.Windows;

namespace Paint.Models
{
    public class RegularPolygon : Figure
    {
        protected int CountOfEdges;
        protected double LengthOfEdge;


        public RegularPolygon(Point offset, int countOfEdges, double lengthOfEdge) : base(offset)
        {
            CountOfEdges = countOfEdges;
            LengthOfEdge = lengthOfEdge;
        }

    }
}
