using System;
using Tools.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.Base
{
public abstract class GenericEvent<T> : SimpleEvent
{
    [SerializeField] private UnityEvent<T> onValueChanged;

    private Action<T> _invoked;

    public void Raise(T value)
    {
        _invoked?.Invoke(value);
        onValueChanged.Invoke(value);
        Raise();
        if(debugReports) 
            this.LogMessage( $"event {name} raised with value: {value?.ToString()}");
    }

    public override void Clear()
    {
        _invoked = null;
        base.Clear();
    }
    
    public void Subscribe(Action<T> method, object target = null)
    {
        _invoked += method;
        if (target == null) target = method.Target;
        Register(target);
    }

    public void Unsubscribe(Action<T> method, object target = null)
    {
        _invoked -= method;
        if (target == null) target = method.Target;
        Unregister(target);
    }
}
}