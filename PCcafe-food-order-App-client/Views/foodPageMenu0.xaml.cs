using PCcafe_food_order_App_client.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PCcafe_food_order_App_client.Views
{
    public partial class foodPageMenu0 : UserControl
    {
        public Action<List<OrderItem>> notifier;

        public List<OrderItem> orderItems  { get; set; }

        private List<OrderItem> _selected;
        public List<OrderItem> Selected
        {
            get { return _selected; }
            set {
                _selected = value;
                notifier?.Invoke(value);
            }
        }

        public foodPageMenu0()
        {
            InitializeComponent();
            DataContext = this;

            orderItems = new List<OrderItem>
            {
                new OrderItem( "/PCcafe-food-order-App-client;component/Resources/Images/김밥.jpg", "김밥" ,  3000),
                new OrderItem( "/PCcafe-food-order-App-client;component/Resources/Images/떡볶이.jpg", "떡볶이", 3000),
                new OrderItem( "/PCcafe-food-order-App-client;component/Resources/Images/라면.jpg", "라면", 4000),
                new OrderItem( "/PCcafe-food-order-App-client;component/Resources/Images/순대.jpg", "순대", 5000),
                new OrderItem ("/PCcafe-food-order-App-client;component/Resources/Images/햄버거.jpg", "햄버거", 4000)
            };

        }

        private void FoodPageMenu0ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selected = new List<OrderItem>() { e.AddedItems[0] as OrderItem };
        }
    }
}
