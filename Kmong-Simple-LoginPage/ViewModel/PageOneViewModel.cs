using Kmong_Simple_LoginPage.Infrastructure;
using Kmong_Simple_LoginPage.MessageDef;
using Kmong_Simple_LoginPage.Modal;
using System.Collections.ObjectModel;

namespace Kmong_Simple_LoginPage.ViewModel
{
    public class PageOneViewModel : BindableBase
    {
        private object _Modal;
        public object Modal
        {
            get { return _Modal; }
            set { SetProperty(ref _Modal, value); }
        }

        private ObservableCollection<string> _listViewItemList;
        private readonly EventAggregator eventAggregator;

        public ObservableCollection<string> BListViewItemList
        {
            get { return _listViewItemList; }
            set { SetProperty(ref _listViewItemList, value); }
        }

        public PageOneViewModel(EventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            BListViewItemList = new ObservableCollection<string>();
            BListViewItemList.Add("김밥");
            BListViewItemList.Add("김밥2");
            BListViewItemList.Add("김밥3");
            BListViewItemList.Add("김밥4");

            eventAggregator.GetEvent<CloseModal>().Subscribe(() =>
            {
                Modal = null;
            });

            eventAggregator.GetEvent<OpenModal>().Subscribe(() =>
            {
                Modal = new ModalPage(this.eventAggregator, BListViewItemList);
            });
        }
    }
}
