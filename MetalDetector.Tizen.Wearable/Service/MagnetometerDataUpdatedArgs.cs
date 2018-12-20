using MetalDetector.Models;
using System;

namespace MetalDetector.Tizen.Wearable.Service
{
    class MagnetometerDataUpdatedArgs : EventArgs, IMagnetometerDataUpdatedArgs
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public MagnetometerDataUpdatedArgs(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
