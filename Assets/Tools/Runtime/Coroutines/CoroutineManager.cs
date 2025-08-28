using System;
using System.Collections;
using UnityEngine;

namespace Tools.Coroutines
{
    /// <summary>
    /// этот класс позволяет запускать корутины из кода без MonoBehaviour, и управлять ими с помощью CoroutineHandle;
    /// </summary>
    public class CoroutineManager : LazySingleton<CoroutineManager>
    {
        protected override bool Persistent => false;

        /// <summary>
        /// запустит переданную корутину от объекта синглтона менеджера
        /// </summary>
        public static CoroutineHandle Run(IEnumerator coroutine) =>
            new CoroutineHandle(coroutine); //todo: понять насколько это генерирует мусор

        //выполнит метод по переданному указателю через время - типа таймер
        public static void DelayMethod(Action method, float seconds = 0f) =>
            new Timer(method, seconds); //todo: понять насколько это генерирует мусор


        private class Timer
        {
            public Timer(Action method, float seconds) => Instance.StartCoroutine(timer(method, seconds));

            private IEnumerator timer(Action eventName, float seconds)
            {
                if (seconds <= 0) yield return new WaitForEndOfFrame();
                else yield return new WaitForSeconds(seconds);

                eventName();
            }
        }
    }
}
