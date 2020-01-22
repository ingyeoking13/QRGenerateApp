using Kmong_Simple_LoginPage.Infrastructure;
using System.Windows;
using Kmong_Simple_LoginPage.MessageDef;
using Kmong_Simple_LoginPage.ViewModel;
using System.Windows.Controls;

namespace Kmong_Simple_LoginPage.View
{
    public partial class PageOne : UserControl
    {
        private readonly EventAggregator eventAggregator;

        public PageOne(EventAggregator _eventAggregator)
        {
            InitializeComponent();
            DataContext = new PageOneViewModel(_eventAggregator);
            eventAggregator = _eventAggregator;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            eventAggregator.GetEvent<OpenModal>().Publish();
        }

        private void VisibleToggleBtn1_Click(object sender, RoutedEventArgs e)
        {
            ListView1.Visibility ^= Visibility.Collapsed;
            Rec1.Visibility = ListView1.Visibility;
            Rec1.Visibility ^= Visibility.Collapsed;
        }

        private void VisibleToggleBtn2_Click(object sender, RoutedEventArgs e)
        {
            ListView2.Visibility ^= Visibility.Collapsed;
            Rec2.Visibility = ListView2.Visibility;
            Rec2.Visibility ^= Visibility.Collapsed;
        }

        private void CollapseAllListView_Click(object sender, RoutedEventArgs e)
        {
            if ((ListView1.Visibility & ListView2.Visibility) != Visibility.Collapsed )
            {
                ListView1.Visibility  = ListView2.Visibility  = Rec1.Visibility = Rec2.Visibility = Visibility.Collapsed;
            }
            else
            {
                ListView1.Visibility = ListView2.Visibility = Rec1.Visibility = Rec2.Visibility = Visibility.Visible;
            }
        }
    }
}
