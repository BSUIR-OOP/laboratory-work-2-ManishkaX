using System;
using System.Windows.Input;

namespace Paint
{
    public class AddFigureCommand : ICommand
            {
                private readonly BuildFigure _delegate;

                private readonly Action<BuildFigure> _action;


                public AddFigureCommand(Action<BuildFigure> action, BuildFigure method)
                {
                    _action = action;
                    _delegate = method;
                }


                event EventHandler ICommand.CanExecuteChanged
                {
                    add { }

                    remove { }
                }

                bool ICommand.CanExecute(object parameter)
                {
                    return true;
                }

                void ICommand.Execute(object parameter)
                {
                    _action(_delegate);
                }
            }
        }