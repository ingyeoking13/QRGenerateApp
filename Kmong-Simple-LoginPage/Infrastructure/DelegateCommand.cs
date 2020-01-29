using System;
using System.Windows.Input;

namespace Kmong_Simple_LoginPage.Infrastructure
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _Cmd;
        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<T> _cmd)
        {
            _Cmd = _cmd;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _Cmd.Invoke((T)parameter);
        }
    }
}
