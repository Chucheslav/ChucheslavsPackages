using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools
{
    public abstract class LazySingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
    
        /// <summary>
        /// override to false if it shouldn't be pushed into dontDestroyOnLoad
        /// </summary>
        protected virtual bool Persistent => true;

        //private static bool _appQuitting;
    
        public static T Instance =>  _instance || !SceneManager.GetActiveScene().isLoaded ? _instance : new GameObject(typeof(T).Name, typeof(T)).GetComponent<T>();

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                if(Persistent) DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this as T) Destroy(gameObject);
            else if(Persistent) DontDestroyOnLoad(gameObject);
        }

        // private void OnDestroy()
        // {
        //     if (!Persistent && ReferenceEquals(_instance, this)) _instance = null;
        // }

        // private void OnApplicationQuit()
        // {
        //     _appQuitting = true;
        // }
    }
}