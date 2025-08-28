using System;
using System.Collections.Generic;
using ScriptableObjectArchitecture.Base;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Events/SimpleEvent", order = -100)] 
public class SimpleEvent : ScriptableObject
{
    [SerializeField] private bool clearOnEnable;
    [SerializeField] private bool clearOnDisable;
    [SerializeReference] private List<ISimpleEventListener> _listeners = new();
    [SerializeField] private UnityEvent onInvoked;
    
    
    private Action _invoked;
    private void OnEnable()
    {
        if(clearOnEnable) Clear();
    }

    private void OnDisable()
    {
        if(clearOnDisable) Clear();
    }

    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--) _listeners[i].OnEventRaised();
        _invoked?.Invoke();
        onInvoked?.Invoke();
    }
    
    public void Subscribe(Action method) => _invoked += method;
    public void Unsubscribe(Action method) => _invoked -= method;

    public void Clear()
    {
        _invoked = null;
        _listeners.Clear();
    }

    public void RegisterListener(ISimpleEventListener listener) => _listeners.Add(listener);
    public void UnregisterListener(ISimpleEventListener listener) => _listeners.Remove(listener);
}
}