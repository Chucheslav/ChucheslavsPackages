using System;
using UnityEngine;

[Serializable]
public struct FloatWithLimits
{
    [SerializeField] private float value;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    public float Fraction => (value - minValue) / (maxValue - minValue);

    public event Action<float,float, float> ValuesChanged;
    public event Action<float> FractionChanged;
    
    public FloatWithLimits(float value, float minValue, float maxValue)
    {
        this.value = value;
        this.minValue = Mathf.Min(maxValue, minValue);
        this.maxValue = Mathf.Max(maxValue, minValue);
        this.value = Mathf.Clamp(value, minValue, maxValue);
        ValuesChanged = null;
        FractionChanged = null;
    }

    public float Value
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

    public void Link(Action<float, float, float> onChanged)
    {
        ValuesChanged += onChanged;
        onChanged(value, minValue, maxValue);
    }

    public void Unlink(Action<float, float, float> onChanged) => ValuesChanged -= onChanged;

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

    public float MinValue
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

    public float MaxValue
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
    
    public static implicit operator float(FloatWithLimits fl) => fl.value;
}