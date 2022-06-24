using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Paint
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }


        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var pos = e.MouseDevice.GetPosition(sender as Canvas);
            (DataContext as ViewModel).AddPoint(pos.X,pos.Y);

        }
    }
}