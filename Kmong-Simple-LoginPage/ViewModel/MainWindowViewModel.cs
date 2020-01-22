using Kmong_Simple_LoginPage.Infrastructure;
using Kmong_Simple_LoginPage.MessageDef;
using Kmong_Simple_LoginPage.View;

namespace Kmong_Simple_LoginPage.ViewModel
{
    public class MainWindowViewModel  : BindableBase
    {
        private object _currentView;
        private readonly EventAggregator eventAggregator;

        public object BCurrentView 
        { 
            get { return _currentView; }
            set { SetProperty(ref _currentView, value); }
        }

        public MainWindowViewModel(EventAggregator _eventAggregator)
        {
            BCurrentView = new LoginView(_eventAggregator);
            eventAggregator = _eventAggregator;

            eventAggregator.GetEvent<GoToNextPage>().Subscribe(() =>
            {
                BCurrentView = new PageOne(eventAggregator);
            });
        }
    }
}
