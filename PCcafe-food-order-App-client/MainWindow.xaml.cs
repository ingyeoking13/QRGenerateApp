using PCcafe_food_order_App_client.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace PCcafe_food_order_App_client
{
    public partial class MainWindow : Window
    {
        //private List<OrderItem> totalSelectedItem = new List<OrderItem>();
        public void changeObserver(List<OrderItem> items)
        {
            //totalSelectedItem = items;
            totalSelectedItemDisplayView.SelectedItemListChanged(items);
        }

        public MainWindow()
        {
            InitializeComponent();
            foodPageMenu0controller.notifier = changeObserver;
        }

        private void MainWindowClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            App.Current.MainWindow.Close();
        }

        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
