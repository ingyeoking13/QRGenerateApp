using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ComboBox
{
    public class SelectedClassConverterGroup : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedClassName = (values[0] as ComboBoxItem).Content as string;
            string studentClassName = (values[1]  as CollectionViewGroup).Name as string;

            if (selectedClassName.Equals("All") || selectedClassName.Equals (studentClassName)) 
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
