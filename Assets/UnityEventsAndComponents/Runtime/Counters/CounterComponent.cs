using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace UnityEventsAndComponents.Counters
{
public class CounterComponent<T> : MonoBehaviour where T: IComparable<T>, IEquatable<T>
{
    [SerializeField] private List<CounterConditions> conditions = new();
    [SerializeField] protected T value;
    [SerializeField] private T defaultValue;
    [SerializeField] private bool resetOnEnable;
    [SerializeField] private bool resetOnDisable;

    public void SetValue(T newValue)
    {
        value = newValue;
        CheckConditions();
    }

    public void Reset()
    {
        value = defaultValue;
    }

    private void OnEnable()
    {
        if (resetOnEnable) Reset();
    }

    private void OnDisable()
    {
        if (resetOnDisable) Reset();
    }

    private void CheckConditions()
    {
        if(!conditions.Any()) return;
        foreach (var condition in conditions) condition.CheckAndInvoke(value);
    }
    
    
    [Serializable]
    private class CounterConditions
    {
        [SerializeField] public T valueTarget;
        [SerializeField] private Conditions condition;
        [SerializeField] private UnityEvent basicEvent;
        [SerializeField] private Vector3UnityEvent vector3Event;
        [SerializeField] private Vector3 vectorValue;

        public void CheckAndInvoke(T value)
        {
            bool needToInvoke = condition switch
            {
                Conditions.Less => value.CompareTo(valueTarget) < 0,
                Conditions.LessOrEqual => value.CompareTo(valueTarget) <= 0,
                Conditions.Equals => value.Equals(valueTarget),
                Conditions.GreaterOrEqual => value.CompareTo(valueTarget) >= 0,
                Conditions.Greater => value.CompareTo(valueTarget) > 0,
                _ => false
            };
            
            if(!needToInvoke) return;
            basicEvent.Invoke();
            vector3Event.Invoke(vectorValue);
        }
        
        public enum Conditions
        {
            Less,
            LessOrEqual,
            Equals,
            GreaterOrEqual,
            Greater
        }
    }
}
}