using UnityEngine;

namespace Tools
{
public abstract class ScriptableSingleton<T> : ScriptableObject where T: ScriptableObject
{
    protected static T Instance;
    
    protected virtual void OnEnable()
    {
        if (Instance != null)
            Debug.Log($"More then one {GetType()} scriptable object referenced, last referenced will be used");
        Instance = this as T;
    }
}
}