using UnityEngine;

namespace Tools
{
public static class SOCopier
{
    public static void JsonCopy<T>(T from, T to) where T : ScriptableObject 
        => JsonUtility.FromJsonOverwrite( JsonUtility.ToJson(from), to);
}
}
