using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace ComboBox
{
    public class Student  : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private int _ClassId;

        public string name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        public int ClassId
        {
            get { return _ClassId; }
            set { _ClassId = value; OnPropertyChanged(); }
        }
        public Student(string name, int classId)
        {
            this.name = name;
            this.ClassId = classId;
        }
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> os { get; set; } = new ObservableCollection<Student>();
        public ICollectionView desc_os { get { return CollectionViewSource.GetDefaultView(os); } }
        public MainWindow()
        {
            desc_os.GroupDescriptions.Add(new PropertyGroupDescription(nameof(Student.ClassId)));

            os.Add(new Student("A1", 1));
            os.Add(new Student("A2", 1));
            os.Add(new Student("A3", 1));
            os.Add(new Student("B1", 2));
            os.Add(new Student("B2", 2));
            os.Add(new Student("B3", 2));
            os.Add(new Student("C1", 3));

            InitializeComponent();
            DataContext = this;
        }
    }
}
