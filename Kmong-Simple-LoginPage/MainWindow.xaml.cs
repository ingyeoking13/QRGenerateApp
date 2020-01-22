using Kmong_Simple_LoginPage.Infrastructure;
using Kmong_Simple_LoginPage.View;
using Kmong_Simple_LoginPage.ViewModel;
using System.Windows;

namespace Kmong_Simple_LoginPage
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EventAggregator eventAggregator = new EventAggregator();
            DataContext = new MainWindowViewModel(eventAggregator);
        }
    }
}
