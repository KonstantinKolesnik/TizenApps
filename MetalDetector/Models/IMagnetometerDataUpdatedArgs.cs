namespace MetalDetector.Models
{
    /// <summary>
    /// IMagnetometerDataUpdatedArgs interface class.
    /// Defines properties that should be implemented by class used to notifying about the magnetometer data update.
    /// </summary>
    public interface IMagnetometerDataUpdatedArgs
    {
        #region properties
        /// <summary>
        /// Value of vector x.
        /// </summary>
        float X { get; }

        /// <summary>
        /// Value of vector y.
        /// </summary>
        float Y { get; }

        /// <summary>
        /// Value of vector z.
        /// </summary>
        float Z { get; }
        #endregion
    }
}
