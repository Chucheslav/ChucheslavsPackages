using System;
using System.Collections;
using UnityEngine;

namespace Tools.Coroutines
{
    public class CoroutineHandle
    {
        private readonly IEnumerator coroutine;
        
        /// <summary>
        /// вызоветса в случае завершения корутины
        /// </summary>
        public event Action Finished;
        
        /// <summary>
        /// ложно если корутина завершилась
        /// </summary>
        public bool Running { get; private set;}
        public bool Paused { get; private set; }
        
        public CoroutineHandle(IEnumerator coroutine, MonoBehaviour owner = null)
        {
            Running = true;
            this.coroutine = coroutine;
            (owner ?? CoroutineManager.Instance).StartCoroutine(Wrapper()); //c# rules!
        }
        
        /// <summary>
        /// Приостановит выполнение корутины до команды Unpause
        /// </summary>
        public void Pause() => Paused = true;
        public void Unpause() => Paused = false;
        
        /// <summary>
        /// завершит корутину в следующем фрейме
        /// </summary>
        public void Stop() => Running = false;

        private IEnumerator Wrapper()
        {
            //yield return null;
            IEnumerator ie = coroutine;
            while (Running)
            {
                if (Paused) yield return null;
                else if (ie != null && ie.MoveNext()) yield return ie.Current;
                else Running = false;
            }
            
            Finished?.Invoke();
        }
    }
}