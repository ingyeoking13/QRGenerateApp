using System;
using System.Windows;
using System.Windows.Controls;

namespace Kmong_Simple_LoginPage.View
{
    public partial class LoginView : UserControl
    {
        private Action _action {get;}
        public LoginView(Action action)
        {
            InitializeComponent();
            _action = action;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _action?.Invoke();
        }
    }
}
