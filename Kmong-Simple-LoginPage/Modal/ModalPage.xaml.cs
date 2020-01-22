using Kmong_Simple_LoginPage.Infrastructure;
using Kmong_Simple_LoginPage.MessageDef;
using Kmong_Simple_LoginPage.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Kmong_Simple_LoginPage.Modal
{
    /// <summary>
    /// ModalPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ModalPage : UserControl
    {
        private readonly EventAggregator eventAggregator;

        public ModalPage(EventAggregator eventAggregator, ListViewItemModel showingItem)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            ShowingItems.Items.Add(showingItem.Menu1);
            ShowingItems.Items.Add(showingItem.Menu2);
            ShowingItems.Items.Add(showingItem.Menu3);
            ShowingItems.Items.Add(showingItem.Menu4);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            eventAggregator.GetEvent<CloseModal>().Publish();
        }
    }
}
