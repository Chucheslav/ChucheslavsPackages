using System;
using UnityEngine;

[Serializable]
public struct IntWithLimits
{
    [SerializeField] private int value;
    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;

    public float Fraction => (float) (value - minValue) / (maxValue - minValue);

    public event Action<int,int, int> ValuesChanged;
    public event Action<float> FractionChanged;
    
    public IntWithLimits(int value, int minValue, int maxValue)
    {
        this.minValue = Mathf.Min(maxValue, minValue);
        this.maxValue = Mathf.Max(maxValue, minValue);
        this.value = Mathf.Clamp(value, minValue, maxValue);
        ValuesChanged = null;
        FractionChanged = null;
    }

    public int Value
    {
        get => value;
        set
        {
            this.value = Mathf.Clamp(value, minValue, maxValue);
            ValuesChanged?.Invoke(this.value, minValue, maxValue);
            FractionChanged?.Invoke(Fraction);
        }
    }
    
    /// <summary>
    /// Subscribe with an action to be played if values change
    /// </summary>
    /// <param name="onChanged"> value, minValue, maxValue</param>

    public void Link(Action<int, int, int> onChanged)
    {
        ValuesChanged += onChanged;
        onChanged(value, minValue, maxValue);
    }

    public void Unlink(Action<int, int, int> onChanged) => ValuesChanged -= onChanged;

    /// <summary>
    /// Subscribe with an action to be played if fraction changes
    /// </summary>
    /// <param name="onChanged"> fraction </param>
    public void Link(Action<float> onChanged)
    {
        FractionChanged += onChanged;
        onChanged(Fraction);
    }
    
    public void Unlink(Action<float> onChanged) => FractionChanged -= onChanged;

    public int MinValue
    {
        get => minValue;
        set
        {
            minValue = value;
            this.value = Mathf.Clamp(this.value, minValue, maxValue);
            ValuesChanged?.Invoke(this.value, minValue, maxValue);
            FractionChanged?.Invoke(Fraction);
        }
    }

    public int MaxValue
    {
        get => maxValue;
        set
        {
            maxValue = value;
            this.value = Mathf.Clamp(this.value, minValue, maxValue);
            ValuesChanged?.Invoke(this.value, minValue, maxValue);
            FractionChanged?.Invoke(Fraction);
        }
    }

    public void ClearSubscribers() => ValuesChanged = null;

    public static implicit operator int(IntWithLimits il) => il.value;
}