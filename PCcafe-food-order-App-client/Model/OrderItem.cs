namespace PCcafe_food_order_App_client.Model
{
    public class OrderItem
    {
        public string imageURL { get; set; }
        public string itemName { get; set; }
        public int KRW { get; set; }
        public string ingredientsOrigin { get; set; } // 부가설명

        public OrderItem(string imageURL, string itemName, int KRW, string ingredientsOrigin = null)
        {
            this.imageURL = imageURL;
            this.itemName = itemName;
            this.KRW = KRW;
            this.ingredientsOrigin = ingredientsOrigin;
        }
    }
    public class SelectedItem
    {
        public string itemName { get; set; }
        public int KRW { get; set; }
        public int Count { get; set; }

        public SelectedItem(string itemName, int kRW, int Count)
        {
            this.itemName = itemName;
            this.KRW = kRW;
            this.Count = Count;
        }
    }

}

