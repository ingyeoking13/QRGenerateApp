using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Animation
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        bool state = false;
        private ObservableCollection<Person> _bSources;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChagned([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        public ObservableCollection<Person> bsources
        {
            get { return _bSources; }
            set { _bSources = value;  OnPropertyChagned(); }
        }

        public MainWindow()
        {
            bsources = new ObservableCollection<Person>
            { new Person("김", "부산"), new Person("정", "강원도"), new Person("최", "서울"), new Person("권", "전라도"), new Person("박", "대전") };

            InitializeComponent();
            DataContext = this;
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (state)
            {
                bsources = new ObservableCollection<Person>(bsources.OrderBy(i => i.Checked));
                state = false;
            }
            else 
            {
                bsources = new ObservableCollection<Person>(bsources.OrderByDescending(i => i.Checked));
                state = true;
            }
        }

        private void UpdateAnimation_Click(object sender, RoutedEventArgs e)
        {
            // update HasError
            foreach( Person p in bsources)
                p.HasError = p.Checked;
        }
    }
    public class Person : INotifyPropertyChanged
    {
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set { _Checked = value; OnPropertyChagned(); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChagned();  }
        }
        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; OnPropertyChagned(); }
        }

        /// <summary>
        /// added 
        /// </summary>
        private bool _HasError;
        public bool HasError
        {
            get { return _HasError; }
            set { _HasError = value; OnPropertyChagned(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChagned([CallerMemberName] string name=null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public Person(string name, string Address)
        {
            this.Checked = false;
            this.Name = name;
            this.Address = Address;
        }
    }
}
