using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Events/SimpleEvent", order = -100)] 
public class SimpleEvent : ScriptableObject
{
    [SerializeField] private bool clearOnEnable;
    [SerializeField] private bool clearOnDisable;
    [SerializeField] private UnityEvent onInvoked;

    [Header("For debugging purposes only.")]
    [SerializeField] protected bool debugReports;
    [SerializeField] private List<MonoBehaviour> mbSubscribers = new();
    [SerializeField] private List<ScriptableObject> soSubscribers = new();

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
        _invoked?.Invoke();
        onInvoked?.Invoke();
    }

    public void Subscribe(Action method, object target = null)
    {
        _invoked += method;
        if(target == null ) target = method.Target;
        Register(target);
    }

    public void Unsubscribe(Action method,object target = null)
    {
        _invoked -= method;
        if(target == null ) target = method.Target;
        Unregister(target);
    }

    protected void Register(object target)
    {
        if(target is MonoBehaviour mb)  mbSubscribers.Add(mb);
        else if(target is ScriptableObject so) soSubscribers.Add(so);
    }

    protected void Unregister(object target)
    {
        if (target is MonoBehaviour mb) mbSubscribers.Remove(mb);
        else if(target is ScriptableObject so) soSubscribers.Remove(so);
    }

    public virtual void Clear()
    {
        _invoked = null;
        mbSubscribers.Clear();
        soSubscribers.Clear();
    }
    public virtual void Reset() => Clear();
}
}