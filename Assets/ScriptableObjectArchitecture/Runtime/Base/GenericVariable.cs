using System;
using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
public abstract class GenericVariable<T> : GenericEvent<T>
{
    [SerializeField] private T variable;
    [SerializeField] private T defaultValue;

    public void Raise() => Raise(variable);

    public T Value
    {
        get => variable;
        set
        {
            variable = value;
            Raise(value);
        }
    }

    public void Link(Action<T> method, object target = null)
    {
        Subscribe(method, target);
        method(variable);
    }

    public void Unlink(Action<T> method, object target = null) => Unsubscribe(method, target);

    public static implicit operator T(GenericVariable<T> so) => so.variable;

    public override void Reset()
    {
        base.Reset();
        variable = defaultValue;
    }
}
}