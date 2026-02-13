using Unity.Mathematics;

namespace Unity.Pool
{
    public interface ISpline
    {
        float LengthInv { get; }
        float Length { get; }

        float3 GetPosition(float t);
    }
}