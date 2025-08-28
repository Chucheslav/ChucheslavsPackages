using System;
using System.Collections.Generic;
using Tools.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.Base
{
public abstract class GenericEvent<T> : ScriptableObject
{
    [SerializeField] private bool clearOnDisable;
    [SerializeField] private bool debugReports;
    [SerializeField] private List<MonoBehaviour> mbSubscribers = new();
    [SerializeField] private List<ScriptableObject> soSubscribers = new();
    [SerializeField] private UnityEvent<T> onValueChanged;
    [SerializeField] private UnityEvent onInvoked;

    private Action<T> Invoked;

    private void OnDisable()
    {
        if(clearOnDisable) Clear();
    }

    public void Raise(T value)
    {
        Invoked?.Invoke(value);
        onValueChanged.Invoke(value);
        onInvoked.Invoke();
        if(debugReports && value != null) this.LogMessage( $" event raised with value: {value.ToString()}");
    }

    public void Clear()
    {
        Invoked = null;
        mbSubscribers.Clear();
        soSubscribers.Clear();
    }
    
    public void Subscribe(Action<T> method, object target = null)
    {
        Invoked += method;
        if (target == null) target = method.Target;
        if (target is MonoBehaviour mb) mbSubscribers.Add(mb);
        else if(target is ScriptableObject so) soSubscribers.Add(so);
    }

    public void Unsubscribe(Action<T> method, object target = null)
    {
        Invoked -= method;
        if (target == null) target = method.Target;
        if (target is MonoBehaviour mb) mbSubscribers.Remove(mb);
        else if(target is ScriptableObject so) soSubscribers.Remove(so);
    }

    public virtual void Reset() => Clear();
}
}