using System;

namespace MetalDetector.Models
{
    /// <summary>
    /// Interface of magnetometer service which allows to obtain the magnetometer data.
    /// </summary>
    public interface IMagnetometerService
    {
        #region properties
        /// <summary>
        /// Notifies about magnetometer data update.
        /// </summary>
        event EventHandler<IMagnetometerDataUpdatedArgs> Updated;

        /// <summary>
        /// Returns true if the magnetometer is supported, false otherwise.
        /// </summary>
        /// <returns>Flag indicating whether magnetometer is supported or not.</returns>
        bool IsSupported();

        /// <summary>
        /// Starts magnetometer sensor.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops magnetometer sensor.
        /// </summary>
        void Stop();
        #endregion
    }
}
