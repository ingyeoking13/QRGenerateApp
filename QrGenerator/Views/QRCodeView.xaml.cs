using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace QrGenerator.Views
{
    /// <summary>
    /// QRCodeView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class QRCodeView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string name=null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private Bitmap _image;

        public Bitmap bImage
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        public QRCodeView()
        {
            InitializeComponent();
        }

    }
}
