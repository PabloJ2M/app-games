using System;
using Unity.Mathematics;

namespace UnityEngine.Animations
{
    [Flags] public enum Direction { Up = 1, Down = 2, Left = 4, Right = 8 }

    public static class TweenExtension
    {
        public static float3 Get(this Axis axis)
        {
            var result = float3.zero;

            if (axis.HasFlag(Axis.X)) result.x = 1;
            if (axis.HasFlag(Axis.Y)) result.y = 1;
            if (axis.HasFlag(Axis.Z)) result.z = 1;

            return result;
        }
        public static float3 GetInverse(this Axis axis)
        {
            var result = new float3(1f, 1f, 1f);

            if (axis.HasFlag(Axis.X)) result.x = 0;
            if (axis.HasFlag(Axis.Y)) result.y = 0;
            if (axis.HasFlag(Axis.Z)) result.z = 0;

            return result;
        }

        public static float3 Get(this Direction direction)
        {
            var result = float3.zero;
            
            if (direction.HasFlag(Direction.Up)) result.y = 1;
            if (direction.HasFlag(Direction.Down)) result.y = -1;
            if (direction.HasFlag(Direction.Left)) result.x = -1;
            if (direction.HasFlag(Direction.Right)) result.x = 1;

            return result;
        }

        public static float InverseLerp(float3 a, float3 b, float3 t)
        {
            var ab = b - a; var at = t - a;
            return math.clamp(math.dot(at, ab) / math.dot(ab, ab), 0, 1);
        }
    }
}