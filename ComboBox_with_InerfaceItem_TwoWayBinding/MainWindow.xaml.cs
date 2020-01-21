using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace ComboBox_with_InerfaceItem_TwoWayBinding
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public ObservableCollection<IGroupable> Items { get; set; }

        private IGroupable _comboBoxSelectedItem;
        public IGroupable comboBoxSelectedItem 
        { 
            get { return _comboBoxSelectedItem; }
            set 
            {
                _comboBoxSelectedItem = value;
                OnPropertyChanged();
            }
        }

        private IGroupable _listViewSelecetdItem;
        public IGroupable listViewSelectedItem 
        { 
            get { return _listViewSelecetdItem; }
            set
            { 
                _listViewSelecetdItem = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Items = new ObservableCollection<IGroupable>();

            var p = new Person("JOHN");
            Groupable<Person> gp = new Groupable<Person>(p);
            Items.Add(gp);

            p = new Person("TOM");
            gp = new Groupable<Person>(p);
            Items.Add(gp);

            p = new Person("YOHAN"); 
            gp = new Groupable<Person>(p);
            Items.Add(gp);

            var a = new Animal("CAT");
            var ca = new Groupable<Animal>(a);
            Items.Add(ca);

            a = new Animal("DOG");
            ca = new Groupable<Animal>(a);

            Items.Add(ca);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSelectedItem = listViewSelectedItem;
        }
    }

    public interface IGroupable
    {
        object Target { get; }
    }

    public class Groupable<T> : IGroupable where T : class
    {
        public T _Target; 
        public T Target
        {
            get { return _Target; }
            set { _Target = value; }
        }
        object IGroupable.Target => _Target;
        public Groupable(T target)
        {
            Target = target;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public Person(string name) => Name = name;
    }
    public class Animal
    { 
        public string Kind { get; set; }
        public Animal(string kind) => Kind = kind;
    }

    class VariableActionObjectToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = string.Empty;

            if (value == null) return result;

            if (value is Groupable<Person>)
            {
                result = (value as Groupable<Person>).Target.Name;
            }
            else if (value is Groupable<Animal>)
            {
                result = (value as Groupable<Animal>).Target.Kind;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
