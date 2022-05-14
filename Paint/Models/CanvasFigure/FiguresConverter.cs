using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Shapes;

namespace Paint.Models.CanvasFigure
{
    public class FiguresConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<Shape> shapeColl = new ObservableCollection<Shape>();
            foreach (var item in value as ObservableCollection<IDisplayable>)
            {
                shapeColl.Add(item.CreateShape());
            }

            return shapeColl;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}