using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ComboBox
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _ClassId;
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        public string ClassId
        {
            get { return _ClassId; }
            set { _ClassId = value; OnPropertyChanged(); }
        }
        public Student(string name, string classId, int age)
        {
            this.Name = name;
            this.ClassId = classId;
            this.Age = age;
        }
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> StudentList { get; set; } = new ObservableCollection<Student>();
        public ListCollectionView GStudentList { get { return CollectionViewSource.GetDefaultView(StudentList) as ListCollectionView; } }
        public MainWindow()
        {
            GStudentList.GroupDescriptions.Add(new PropertyGroupDescription(nameof(Student.ClassId)));
            GStudentList.SortDescriptions.Add(new SortDescription(nameof(Student.Age), ListSortDirection.Ascending));
            GStudentList.SortDescriptions.Add(new SortDescription(nameof(Student.Name), ListSortDirection.Ascending));

            GStudentList.IsLiveGrouping = true;
            GStudentList.IsLiveSorting = true;

            StudentList.Add(new Student("Tom", "Junior", 20));
            StudentList.Add(new Student("djm03178", "Elite", 31));
            StudentList.Add(new Student("Mike", "Expert", 44));
            StudentList.Add(new Student("tourist", "Elite", 55));
            StudentList.Add(new Student("Amok", "Elite", 55));
            StudentList.Add(new Student("Dotory", "Elite", 55));
            StudentList.Add(new Student("Radewoosh", "Elite", 21));
            StudentList.Add(new Student("gaelim", "Junior", 33));

            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ns = new Student(NAMETB.Text, (CLASSCB.SelectedItem as ComboBoxItem).Content as string, int.Parse(AGETB.Text));
            StudentList.Add(ns);
        }
    }
}
