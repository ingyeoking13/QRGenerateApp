namespace Kmong_Simple_LoginPage.Model
{
    public class ListViewItemModel
    {
        public string Menu1 { get; set; }
        public string Menu2 { get; set; }
        public string Menu3 { get; set; }
        public string Menu4 { get; set; }

        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }

        public ListViewItemModel(string _Menu1, string _Menu2, string _Menu3, string _Menu4, 
            string _Description1 = null, string _Description2 = null, string _Description3 = null, string _Description4 = null)
        {
            Menu1 = _Menu1;
            Menu2 = _Menu2;
            Menu3 = _Menu3;
            Menu4 = _Menu4;

            Description1 = _Description1;
            Description2 = _Description2;
            Description3 = _Description3;
            Description4 = _Description4;
        }

    }
}
