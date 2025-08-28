using UnityEngine;

namespace Tools
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T Instance;
    
        protected virtual void Awake()
        {
            if (!Instance) Instance = this as T;
            else if (Instance != this as T) Destroy(gameObject);
        }
    }
}