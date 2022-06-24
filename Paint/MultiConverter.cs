using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using Paint.Models;
using Ellipse = System.Windows.Shapes.Ellipse;

namespace Paint
{
    public class MultiConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var shapeColl = new ObservableCollection<Shape>();
            foreach (var item in (ObservableCollection<IDisplayable>) values[0])
            {
                shapeColl.Add(item.CreateShape());
            }

            foreach (var item in (ObservableCollection<Point>) values[1])
            {
                var point = new Ellipse
                {
                    Width = 5,
                    Height = 5,
                    StrokeThickness = 0,
                    Margin = new Thickness(item.X - 2.5, item.Y - 2.5, 0, 0),
                    Fill = Brushes.Crimson
                };

                shapeColl.Add(point);
            }
            return shapeColl;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}