using PCcafe_food_order_App_client.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace PCcafe_food_order_App_client.Views
{
    public partial class TotalSelectedItemDisplayView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<SelectedItem> selectedItemList { get; set; } = new ObservableCollection<SelectedItem>();

        private int _totalAmount;
        public int bTotalAmount
        {
            get { return _totalAmount; }
            set {
                _totalAmount = value;
                OnPropertyChanged();
            }
        }

        public TotalSelectedItemDisplayView()
        {
            InitializeComponent();
            DataContext = this;
            _totalAmount = 0;
        }

        public void SelectedItemListChanged(OrderItem orderItem)
        {
            var res = selectedItemList.FirstOrDefault(i=>i.itemName == orderItem.itemName);
            bTotalAmount += orderItem.KRW;
            if (res == null)
            {
                selectedItemList.Add(new SelectedItem(orderItem.itemName, orderItem.KRW, 1));
                return;
            }
            selectedItemList.First(i => i.itemName == orderItem.itemName).Count++;
        }

        public void OnPropertyChanged( [CallerMemberName] string name = null ) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
