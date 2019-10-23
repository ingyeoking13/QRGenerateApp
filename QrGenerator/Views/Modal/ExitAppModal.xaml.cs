using System.Windows.Controls;

namespace QrGenerator.Views.Modal
{
    /// <summary>
    /// ExitAppModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ExitAppModal : UserControl
    {
        private bool _isEnd;
        public bool isEnd
        {
            get { return _isEnd; }
            set { _isEnd = value; }
        }

        public ExitAppModal()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isEnd = true;
        }

        private void NoExitBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isEnd = false;
        }
    }
}
