using Kmong_Simple_LoginPage.Infrastructure;
using Kmong_Simple_LoginPage.MessageDef;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Kmong_Simple_LoginPage.View
{
    public partial class LoginView : UserControl
    {
        private readonly EventAggregator eventAggregator;

        public LoginView(EventAggregator _eventAggregator)
        {
            InitializeComponent();
            eventAggregator = _eventAggregator;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            eventAggregator.GetEvent<GoToNextPage>().Publish();
        }
    }
}
