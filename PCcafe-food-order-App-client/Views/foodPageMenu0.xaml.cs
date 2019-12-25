using PCcafe_food_order_App_client.Model;
using PCcafe_food_order_App_client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace PCcafe_food_order_App_client.Views
{
    public partial class foodPageMenu0 : UserControl
    {
        public Action<OrderItem> notifier;

        public List<OrderItem> orderItems  { get; set; }


        private OrderItem _selected;
        public OrderItem Selected
        {
            get { return _selected; }
            set {
                _selected = value;
                notifier?.Invoke(value);
            }
        }
        public ICommand cBuyThisItem { get; set; }

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
            cBuyThisItem = new DelegateCommand(onBuyThisItem );
        }
        public void onBuyThisItem(object param)
        {
            var str = param as string;
            Selected = orderItems.First(i => i.itemName == param as string);
        }

    }
}
