using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MetalDetector.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets specified property value.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="property">Storage field.</param>
        /// <param name="value">New value of the property.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>True if property was changed, false otherwise.</returns>
        protected bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, value))
                return false;

            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
