using PCcafe_food_order_App_client.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace PCcafe_food_order_App_client.Views
{
    public partial class TotalSelectedItemDisplayView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SelectedItem> selectedItemList { get; set; } = new ObservableCollection<SelectedItem>();

        public void SelectedItemListChanged(List<OrderItem> orderItems)
        {
            foreach (OrderItem item in orderItems)
            {
                selectedItemList.Add(new SelectedItem( item.itemName, item.KRW, 1 ));
            }
        }

        public TotalSelectedItemDisplayView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void OnPropertyChanged( [CallerMemberName] string name = null ) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
