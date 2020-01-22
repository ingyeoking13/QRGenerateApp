using Kmong_Simple_LoginPage.View;
using System.Windows;

namespace Kmong_Simple_LoginPage
{
    public partial class MainWindow : Window
    {
        public object BCurrentView { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ;
            BCurrentView = new LoginView(GoNextPage);
        }

        public void GoNextPage()
        {
            BCurrentView = new PageOne();
        }

    }
}
