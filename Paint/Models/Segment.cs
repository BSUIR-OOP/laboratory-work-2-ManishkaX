using System;
using System.Windows;

namespace Paint.Models
{
    public class Segment : Figure
    {
        protected Point Point;

        public Segment(Point offset, Point point) : base(offset) =>
            Point = point;


    }
}
