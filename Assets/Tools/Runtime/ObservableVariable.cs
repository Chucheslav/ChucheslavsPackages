using System;
using UnityEngine;

[Serializable]
public class ObservableVariable<T>
{
    [SerializeField] private T value;

    public T Value
    {
        get => value;
        set
        {
            this.value = value;
            ValueChanged?.Invoke(this.value);
        }
    }

    public event Action<T> ValueChanged;

    public static implicit operator T(ObservableVariable<T> ov) => ov.Value;

}