namespace MetalDetector.Models
{
    public interface IMagnetometerDataUpdatedArgs
    {
        float X { get; }
        float Y { get; }
        float Z { get; }
    }
}
