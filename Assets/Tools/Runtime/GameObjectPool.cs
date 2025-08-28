using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//to release T just deactivate its gameObject
namespace Tools
{
    public class GameObjectPool<T>  where T: MonoBehaviour
    {
        private T prefab;
        private HashSet<T> pool = new HashSet<T>();
        public IReadOnlyCollection<T> AllObjects => pool;

        public int Size => pool.Count;
        public int InactiveAmount => pool.Count(t => !t.gameObject.activeSelf);

        public GameObjectPool(T prefab)
        {
            this.prefab = prefab;
        }
    
        /// <summary>
        /// returns an activated object from the pool, creates one if pool is empty
        /// </summary>
        public T GetOne(Vector3 position, Quaternion rotation)
        {
            T instance = pool.FirstOrDefault(t => !t.gameObject.activeSelf);
            if (!instance)
            {
                instance = GameObject.Instantiate(prefab, position, rotation);
                pool.Add(instance);
            }
            else
            {
                Transform transform = instance.transform;
                transform.position = position;
                transform.rotation = rotation;
                instance.gameObject.SetActive(true);
            }

            return instance;
        }
    
        /// <summary>
        /// disables all objects effectively releasing them to the pool
        /// </summary>
        public void ReleaseAll()
        {
            KillZombies();
            foreach (T instance in pool)
            {
                instance.gameObject.SetActive(false);
            }
        }

        private void KillZombies() => pool.RemoveWhere(t => !t);

        /// <summary>
        /// clears pool, destroys the objects
        /// </summary>
        public void Clear()
        {
            KillZombies();
            foreach (T instance in pool) GameObject.Destroy(instance.gameObject);
            pool.Clear();
        }
    }
}