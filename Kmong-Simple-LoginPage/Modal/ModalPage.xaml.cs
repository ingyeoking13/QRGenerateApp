using Kmong_Simple_LoginPage.Infrastructure;
using Kmong_Simple_LoginPage.MessageDef;
using System;
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

        public ModalPage(EventAggregator eventAggregator, ICollection<string> showingItems)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            foreach (var item in showingItems) ShowingItems.Items.Add(item);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            eventAggregator.GetEvent<CloseModal>().Publish();
        }
    }
}
