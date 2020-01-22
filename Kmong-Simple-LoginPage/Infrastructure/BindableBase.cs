using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kmong_Simple_LoginPage.Infrastructure
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        protected virtual bool SetProperty<T>(ref T storage, T value , [CallerMemberName]string propName= null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propName);
            return true;
        }
    }
}
