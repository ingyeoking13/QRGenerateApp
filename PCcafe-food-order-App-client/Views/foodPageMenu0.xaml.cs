using System.Collections.Generic;
using System.Windows.Controls;

namespace PCcafe_food_order_App_client.Views
{
    /// <summary>
    /// foodPageMenu0.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class foodPageMenu0 : UserControl
    {
        public List<string> fileNames  { get; set; }

        public foodPageMenu0()
        {
            InitializeComponent();
            DataContext = this;

            fileNames = new List<string>
            {
                "/PCcafe-food-order-App-client;component/Resources/Images/김밥.jpg",
                "/PCcafe-food-order-App-client;component/Resources/Images/떡볶이.jpg",
                "/PCcafe-food-order-App-client;component/Resources/Images/라면.jpg",
                "/PCcafe-food-order-App-client;component/Resources/Images/순대.jpg",
                "/PCcafe-food-order-App-client;component/Resources/Images/햄버거.jpg",
            };

        }
    }
}
