using System.Windows;
using System.Windows.Input;

namespace PCcafe_food_order_App_client
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindowClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
