using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MetalDetector.ViewModels
{
    /// <summary>
    /// Class that provides basic functionality for view models.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region properties

        /// <summary>
        /// Fired, when property was updated.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region methods

        /// <summary>
        /// Sets specified property value.
        /// </summary>
        /// <typeparam name="T">Property type.</typeparam>
        /// <param name="storage">Storage field.</param>
        /// <param name="value">New value of the property.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>True if property was changed, false otherwise.</returns>
        protected bool SetProperty<T>(ref T storage, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Called when property was changed.
        /// Fires PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
