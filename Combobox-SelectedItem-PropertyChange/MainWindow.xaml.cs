using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Combobox_SelectedItem_PropertyChange
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Student> vs { get; set; }
        public ObservableCollection<WrappedStudent> Students { get; set; }

        private WrappedStudent _selectedItem;
        public WrappedStudent selectedItem { get { return _selectedItem; } set { _selectedItem = value; OnPropertyChanged(); Debug.WriteLine(value.Student.Name); } }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            vs = new ObservableCollection<Student> {
            new Student{Name="Tom", Age="15", Sex="male" },
            new Student { Name = "John", Age = "18", Sex = "male" },
            new Student {Name="Hi", Age="24", Sex="male"}
            };
            OnPropertyChanged(nameof(vs));

            Students = new ObservableCollection<WrappedStudent>();
            foreach(var s in vs )
                Students.Add(new WrappedStudent { Student = s });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class Student  : INotifyPropertyChanged
    {
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChange(); } }
        private string _Age;
        public string Age { get { return _Age; } set { _Age = value; OnPropertyChange(); } }
        private string _Sex;
        public string Sex { get { return _Sex; } set { _Sex = value; OnPropertyChange(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChange([CallerMemberName]string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public class WrappedStudent : INotifyPropertyChanged
    {
        private Student _student;
        public Student Student
        {
            get { return _student; }
            set { _student = value;
                OnPropertyChange();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChange([CallerMemberName]string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
