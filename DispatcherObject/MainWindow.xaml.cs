using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DispatcherObject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Dispatcher_Button_Dispatcher_same_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.Dispatcher == MainWindow_Dispatcher_Button_Dispatcher_same_btn.Dispatcher )
            {
                resultTB.Text = "MainWindow Dispatcher, this btn Dispatcher Same!";
                if ( this.Dispatcher.Thread == MainWindow_Dispatcher_Button_Dispatcher_same_btn.Dispatcher.Thread)
                {
                    resultTB.Text += Environment.NewLine;
                    resultTB.Text += "and MainWindow Thread, this btn Thread Same!";
                }
                else
                {
                    resultTB.Text += Environment.NewLine;
                    resultTB.Text += "but MainWindow Thread, this btn Thread Diff!";
                }
            }
            else
            {
                resultTB.Text = "MainWindow Dispatcher, this btn Dispatcher Same!";
                if (this.Dispatcher.Thread == MainWindow_Dispatcher_Button_Dispatcher_same_btn.Dispatcher.Thread)
                {
                    resultTB.Text += Environment.NewLine;
                    resultTB.Text += "and MainWindow Thread, this btn Thread Same!";
                }
                else
                {
                    resultTB.Text += Environment.NewLine;
                    resultTB.Text += "but MainWindow Thread, this btn Thread Diff!";
                }
            }
        }

        private void CreateNewThread_And_It_Accesses_TextBlock_Click(object sender, RoutedEventArgs e)
        {

            Task.Run(() =>
            {
                    //resultTB.Text = "Modified in new Thread";
                    resultTB.Dispatcher?.Invoke(() => { resultTB.Text = "Modified in new Thread"; });
            });

        }
    }
}
