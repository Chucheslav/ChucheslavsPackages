using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
public class SimpleEventToUnityEventConverter : MonoBehaviour
{
    [SerializeField] private List<EventPair> eventBindings = new();

    [SerializeField] private UnityEvent response;

    private void OnEnable()
    {
        foreach (EventPair eventBinding in eventBindings) 
            eventBinding.simpleEvent.Subscribe( eventBinding.InvokeUnityEvent);
    }

    private void OnDisable()
    {
        foreach (EventPair eventBinding in eventBindings) 
            eventBinding.simpleEvent.Unsubscribe(eventBinding.InvokeUnityEvent);
    }

    private class EventPair
    {
        public SimpleEvent simpleEvent;
        public UnityEvent unityEvent;
        
        public void InvokeUnityEvent() => unityEvent.Invoke();
    }
}
}
