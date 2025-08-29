using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/UnityEvent Invoker")]
public class YarnUnityEventInvoker : MonoBehaviour
{
    [SerializeField] private List<EventById> events = new ();
    
    [Serializable]
    private class EventById
    {
        public string id;
        public UnityEvent unityEvent;
    }

    [YarnCommand("invokeEvent")]
    public void InvokeEvent(string id)
    {
        EventById ev = events.Find(e => e.id == id);
        if (ev == null)
        {
            Debug.LogError($"Event with id {id} not found on object {name}");
            return;
        }

        ev.unityEvent.Invoke();
    }
}
}