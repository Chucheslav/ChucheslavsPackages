using System.Data;
using UnityEngine;

public static class MinMaxVector2Extensions
{
    public static float GetRandomValue(this Vector2 limits) => UnityEngine.Random.Range(limits.x, limits.y);

    public static float ClampFloat(this Vector2 to, float toClamp) =>
        Mathf.Clamp(toClamp, Mathf.Min(to.x, to.y), Mathf.Max(to.x, to.y));

    public static float ClampToVector2(this float f, Vector2 to) =>
        Mathf.Clamp(f, Mathf.Min(to.x, to.y), Mathf.Max(to.x, to.y));

    public static float Max(this Vector2 v2) => Mathf.Max(v2.x, v2.y);
    public static float Min(this Vector2 v2) => Mathf.Min(v2.x, v2.y);

    public static bool Contains(this Vector2 v2, float f) => f <= v2.y && f >= v2.x;
}