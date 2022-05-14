using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using Paint.Models.CanvasFigure;

namespace Paint
{
    public class MultiConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<Shape> shapeColl = new ObservableCollection<Shape>();
            foreach (var item in values[0] as ObservableCollection<IDisplayable>)
            {
                shapeColl.Add(item.CreateShape());
            }

            foreach (var item in values[1] as ObservableCollection<Point>)
            {
                Ellipse points = new Ellipse();
                points.Width = 5;
                points.Height = 5;
                points.StrokeThickness = 0;
                points.Margin = new Thickness(item.X - 2.5, item.Y - 2.5, 0, 0);
                points.Fill = Brushes.Crimson;
                
                shapeColl.Add(points);
            }
            return shapeColl;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}