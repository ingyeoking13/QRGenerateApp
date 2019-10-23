using MaterialDesignThemes.Wpf;
using QrGenerator.Views.Modal;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using BarcodeWriter = ZXing.Presentation.BarcodeWriter;

namespace QrGenerator.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _QRText;
        public string bQRText
        {
            get { return _QRText; }
            set
            {
                _QRText = value;
                GenQR(value);
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
        private void GenQR(string value)
        {
            EncodingOptions option = new EncodingOptions();
            option.Hints.Add(EncodeHintType.CHARACTER_SET, "utf-8");
            option.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            option.Hints.Add(EncodeHintType.WIDTH, 200);
            option.Hints.Add(EncodeHintType.HEIGHT, 200);

            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = option
            };

            if (string.IsNullOrEmpty(value))
            {
                QRCodeView.imageHolder.Source = new BitmapImage();
                return;
            }

            var result = writer.Write(value);

            BitmapImage bmImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(result));
                encoder.Save(stream);
                bmImage.BeginInit();
                bmImage.CacheOption = BitmapCacheOption.OnLoad;
                bmImage.StreamSource = stream;
                bmImage.EndInit();
                bmImage.Freeze();
            }

            QRCodeView.imageHolder.Source = bmImage;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private async void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            var exitModal = new ExitAppModal();
            await DialogHost.Show(exitModal, "RootDialog");
            if(exitModal.isEnd) Environment.Exit(0);
        }

        private async void Information_Click(object sender, RoutedEventArgs e)
        {
            var informModal = new InformModal();
            await DialogHost.Show(informModal, "RootDialog");
        }

        private void ViewMode_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.viewMode.Content = new PackIcon
                {
                    Kind = PackIconKind.ArrowCollapse
                };
                FooterInput.Visibility = Visibility.Collapsed;

                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.viewMode.Content = new PackIcon
                {
                    Kind = PackIconKind.ArrowTopRightBottomLeft
                };
                FooterInput.Visibility = Visibility.Visible;

                this.WindowState = WindowState.Normal;
            }
        }
    }
}
