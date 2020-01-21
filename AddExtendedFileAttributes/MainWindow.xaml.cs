using Microsoft.Win32;
using Shell32;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Windows;

namespace AddExtendedFileAttributes
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdialog = new OpenFileDialog();
            BinaryFormatter binaryFmt = new BinaryFormatter();
            if ( ofdialog.ShowDialog() == true)
            {
                var fileInfo = new FileInfo(ofdialog.FileName);
                StreamingContext a = new StreamingContext();
            }
        }
       private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

    }
}
