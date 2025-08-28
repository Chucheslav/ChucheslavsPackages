using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Prefs/FloatPref")]
public class FloatPref : ScriptablePref<float>
{
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    public float MinValue => minValue;
    public float MaxValue => maxValue;

    protected override void Save() => PlayerPrefs.SetFloat(prefID, Mathf.Clamp(Value, minValue, maxValue));
    protected override float LoadValue() => PlayerPrefs.GetFloat(prefID);
}
}