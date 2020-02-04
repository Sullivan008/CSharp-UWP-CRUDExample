using System;
using Windows.UI.Xaml.Data;

namespace CRUDOperationsClient.Extensions
{
    public class NullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (string.IsNullOrEmpty((string)value) || !int.TryParse((string)value, out int temp))
            {
                return null;
            }

            return temp;
        }
    }
}
