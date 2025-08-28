using UnityEngine;

namespace Tools
{
public static class VectorExtensions
{
    public static bool IsBetween(this Vector2Int toCheck, Vector2Int one, Vector2Int two) =>
        toCheck.x.IsBetween(one.x, two.x) && toCheck.y.IsBetween(one.y, two.y);
    
    public static bool IsBetween(this Vector2 toCheck, Vector2 one, Vector2 two) =>
        toCheck.x.IsBetween(one.x, two.x) && toCheck.y.IsBetween(one.y, two.y);
    
    public static bool IsBetweenExclusive(this Vector2Int toCheck, Vector2Int one, Vector2Int two) =>
        toCheck.x.IsBetweenExclusive(one.x, two.x) && toCheck.y.IsBetweenExclusive(one.y, two.y);
    
    public static bool IsBetweenExclusive(this Vector2 toCheck, Vector2 one, Vector2 two) =>
        toCheck.x.IsBetweenExclusive(one.x, two.x) && toCheck.y.IsBetweenExclusive(one.y, two.y);

    public static Vector3 Abs(this Vector3 vector) => new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    public static Vector2 Abs(this Vector2 vector) => new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
}
}