using System;

namespace UnityEngine.Animations
{
    [Flags] public enum Direction { Up = 1, Down = 2, Left = 4, Right = 8 }

    public static class TweenExtension
    {
        public static Vector3 Get(this Axis axis)
        {
            var result = Vector3.zero;

            if (axis.HasFlag(Axis.X)) result.x = 1;
            if (axis.HasFlag(Axis.Y)) result.y = 1;
            if (axis.HasFlag(Axis.Z)) result.z = 1;

            return result;
        }
        public static Vector2 Get(this Direction direction)
        {
            var result = Vector2.zero;
            
            if (direction.HasFlag(Direction.Up)) result.y = 1;
            if (direction.HasFlag(Direction.Down)) result.y = -1;
            if (direction.HasFlag(Direction.Left)) result.x = -1;
            if (direction.HasFlag(Direction.Right)) result.x = 1;

            return result;
        }

        public static float InverseLerp(Vector3 a, Vector3 b, Vector3 t)
        {
            var ab = b - a; var at = t - a;
            return Mathf.Clamp01(Vector3.Dot(at, ab) / Vector3.Dot(ab, ab));
        }
    }
}