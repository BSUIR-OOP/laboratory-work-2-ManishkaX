using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Paint.Models.CanvasFigure;

namespace Paint
{
    public delegate IDisplayable BuildFigure(Queue<Point> points);
    public class ViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<IDisplayable> _figures;
        public ObservableCollection<IDisplayable> Figures
        {
            get { return _figures; }
            set
            {
                _figures = value;
                NotifyPropertyChanged(nameof(Figures));
            }
        }

        private ObservableCollection<Point> _points;
        public ObservableCollection<Point> Points
        {
            get { return _points; }
            set
            {
                _points = value;
                NotifyPropertyChanged(nameof(Points));
            }
        }

        public ObservableCollection<ButtonWrapper> ButtonWrappers { get; }

        public ViewModel()
        {
            Points = new ObservableCollection<Point>();
            Points.CollectionChanged += (sender, args) => NotifyPropertyChanged(nameof(Points));
            
            ButtonWrappers = new ObservableCollection<ButtonWrapper>();
            AddButtonWrapper(FiguresFactory.CreateCircle, "Circle");
            AddButtonWrapper(FiguresFactory.CreateEllipse, "Ellipse");
            AddButtonWrapper(FiguresFactory.CreateRectangle, "Rectangle");
            AddButtonWrapper(FiguresFactory.CreateRegularPolygon, "RegularPolygon");
            AddButtonWrapper(FiguresFactory.CreateSegment, "Segment");
            AddButtonWrapper(FiguresFactory.CreateTriangle, "Triangle");
            
            Figures = new ObservableCollection<IDisplayable>();
            Figures.CollectionChanged += (sender, args) => NotifyPropertyChanged(nameof(Figures));

            Figures.Add(new CanvasCircle(new Point(100, 100), 40));
            Figures.Add(new CanvasEllipse(new Point(200, 200), 40, 20));
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
            IDisplayable figure = method(new Queue<Point>(Points));

            if (figure != null)
            {
                Figures.Add(figure);
                Points.Clear();
            }
        }
        public void AddButtonWrapper(BuildFigure method, string content)
        {
            ButtonWrappers.Add(new ButtonWrapper(new AddFigureCommand(AddFigure, method), content));
        }
    }
}