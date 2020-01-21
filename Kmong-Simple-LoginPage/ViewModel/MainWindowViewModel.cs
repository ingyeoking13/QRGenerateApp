using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kmong_Simple_LoginPage.ViewModel
{
    public static class INotifyPropertyChangedExtension
    {
        public static void SetValue<T>(this INotifyPropertyChanged instance, T value, )
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
