using UnityEngine;
using UnityEngine.Events;

public static class Math
{
    public static void Loop(ref float value, float add, float limit, UnityAction onSuccess = null)
    {
        value += add;
        if (value > limit) { value %= limit; onSuccess?.Invoke(); }
    }
}
public static class GlobalExtension
{
    public static float PositionX(this Transform transform) => transform.position.x;
    public static float LocalPositionX(this Transform transform) => transform.localPosition.x;

    public static void PositionX(this Transform transform, float value)
    {
        Vector2 pos = transform.position;
        pos.x = value;
        transform.position = pos;
    }
    public static void ClampPositionX(this Transform transform, float min, float max)
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min, max);
        transform.position = pos;
    }
    public static void LocalPositionX(this Transform transform, float value)
    {
        Vector2 pos = transform.localPosition;
        pos.x = value;
        transform.localPosition = pos;
    }

    public static float PositionY(this Transform transform) => transform.position.y;
    public static float LocalPositionY(this Transform transform) => transform.localPosition.y;

    public static void PositionY(this Transform transform, float value)
    {
        Vector2 pos = transform.position;
        pos.y = value;
        transform.position = pos;
    }
    public static void ClampPositionY(this Transform transform, float min, float max)
    {
        Vector2 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, min, max);
        transform.position = pos;
    }
    public static void LocalPositionY(this Transform transform, float value)
    {
        Vector2 pos = transform.localPosition;
        pos.y = value;
        transform.localPosition = pos;
    }
}