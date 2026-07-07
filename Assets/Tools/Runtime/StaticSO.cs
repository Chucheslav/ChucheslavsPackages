using UnityEngine;

namespace Tools
{
public abstract class StaticSO<T> : ScriptableObject where T: ScriptableObject
{
    public static T Instance { get; private set; }
    
    protected virtual void OnEnable()
    {
#if UNITY_EDITOR
        if (Instance != null)
            Debug.Log($"More then one {GetType()} scriptable object referenced, last referenced will be used");
#endif
        Instance = this as T;
    }
}
}