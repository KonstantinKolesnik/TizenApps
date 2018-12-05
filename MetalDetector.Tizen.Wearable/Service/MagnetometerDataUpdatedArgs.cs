using MetalDetector.Models;
using System;

namespace MetalDetector.Tizen.Wearable.Service
{
    /// <summary>
    /// Class defining structure of object being parameter of the MagnetometerDataUpdated event.
    /// </summary>
    class MagnetometerDataUpdatedArgs : EventArgs, IMagnetometerDataUpdatedArgs
    {
        #region properties

        /// <summary>
        /// Value of vector x.
        /// </summary>
        public float X { get; }

        /// <summary>
        /// Value of vector y.
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// Value of vector z.
        /// </summary>
        public float Z { get; }

        #endregion

        #region methods

        /// <summary>
        /// MagnetometerDataUpdatedArgs class constructor.
        /// </summary>
        /// <param name="x">X component of the magnetometer.</param>
        /// <param name="y">Y component of the magnetometer.</param>
        /// <param name="z">Z component of the magnetometer.</param>
        public MagnetometerDataUpdatedArgs(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion
    }
}
