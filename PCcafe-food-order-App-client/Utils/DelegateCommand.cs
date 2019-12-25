using System;
using System.Windows.Input;

namespace PCcafe_food_order_App_client.Utils
{
    class DelegateCommand : ICommand
    {
        Action<object> _executeMethod;
        Func<object, bool> _canExecuteMethod;

        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<object> executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public DelegateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod == null ? true : _canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
}
