using System;
using Xamarin.Forms;

namespace Ejercicio2_3
{
    public class ImageNullOrEmptyConverter : IValueConverter
    {
        internal bool IsVisible;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is ImageSource imageSource)
            {
                return imageSource != null;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
