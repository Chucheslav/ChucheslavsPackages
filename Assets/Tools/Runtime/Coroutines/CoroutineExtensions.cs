using System;
using System.Collections;
using UnityEngine;

namespace Tools.Coroutines
{
public static class CoroutineExtensions
{
    public static Coroutine DelayMethod(this MonoBehaviour mb, Action method, float seconds = 0)
    {
        return mb.StartCoroutine(Timer(method, seconds));
        
        IEnumerator Timer(Action eventName, float seconds)
        {
            if (seconds <= 0) yield return new WaitForEndOfFrame();
            else yield return new WaitForSeconds(seconds);

            eventName();
        }
    }
}
}
