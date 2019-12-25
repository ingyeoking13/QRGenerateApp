using System.Windows.Controls;

namespace QrGenerator.Views.Modal
{
    /// <summary>
    /// InformModal.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InformModal : UserControl
    {
        public InformModal()
        {
            InitializeComponent();
        }

        private void GithubLink_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ingyeoking13/QRGenerateApp");
        }
    }
}
