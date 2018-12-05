using System;
using System.Globalization;
using Xamarin.Forms;

namespace MetalDetector.Converters
{
    public class StrengthLevelToFileNameConverter : IValueConverter
    {
        #region fields
        private const string FILENAME_TEMPLATE = "signal_strength_{0}.png";
        #endregion

        #region methods
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(FILENAME_TEMPLATE, (int)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
