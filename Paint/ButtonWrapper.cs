using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Paint
{
    public class ButtonWrapper : INotifyPropertyChanged
    {
        private ICommand _command;

        public ICommand Command
        {
            get => _command;
            set
            {
                _command = value;
                NotifyPropertyChanged(nameof(Command));
            }
        }

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                NotifyPropertyChanged(nameof(Content));
            }
        }


        public ButtonWrapper(AddFigureCommand command, string content)
        {
            Command = command;
            Content = content;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}