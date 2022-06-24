using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Paint.Models;

namespace Paint
{
    public delegate IDisplayable BuildFigure(Queue<Point> points);
    public class ViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<IDisplayable> _figures;
        public ObservableCollection<IDisplayable> Figures
        {
            get => _figures;
            set
            {
                _figures = value;
                NotifyPropertyChanged(nameof(Figures));
            }
        }
        

        private ObservableCollection<Point> _points;
        public ObservableCollection<Point> Points
        {
            get => _points;
            set
            {
                _points = value;
                NotifyPropertyChanged(nameof(Points));
            }
        }

        private ObservableCollection<ButtonWrapper> _buttonWrappers;

        public ObservableCollection<ButtonWrapper> ButtonWrappers
        {
            get => _buttonWrappers;
            set
            {
                _buttonWrappers = value;
                NotifyPropertyChanged(nameof(ButtonWrappers));
            }
        }
        

        public ViewModel()
        {
            Points = new ObservableCollection<Point>();
            Points.CollectionChanged += (sender, args) => NotifyPropertyChanged(nameof(Points));
            
            ButtonWrappers = new ObservableCollection<ButtonWrapper>();
            AddButtonWrapper(Circle.CreateCircle, "Circle"); 
            AddButtonWrapper(MyEllipse.CreateEllipse, "Ellipse");
            AddButtonWrapper(Rectangle.CreateRectangle, "Rectangle");
            AddButtonWrapper(RegularPolygon.CreateRegularPolygon, "RegularPolygon");
            AddButtonWrapper(Segment.CreateSegment, "Segment");
            AddButtonWrapper(RightTriangle.CreateRightTriangle, "Triangle");
            
            Figures = new ObservableCollection<IDisplayable>();
            Figures.CollectionChanged += (sender, args) => NotifyPropertyChanged(nameof(Figures));
        }


        public void AddPoint(double x, double y)
        {
            Points.Add(new Point(x, y));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private void AddFigure(BuildFigure method)
        {
            var figure = method(new Queue<Point>(Points));

            if (figure == null) 
                return;
            
            Figures.Add(figure);
            Points.Clear();
        }
        public void AddButtonWrapper(BuildFigure method, string content)
        {
            ButtonWrappers.Add(new ButtonWrapper(new AddFigureCommand(AddFigure, method), content));
        }
    }
}