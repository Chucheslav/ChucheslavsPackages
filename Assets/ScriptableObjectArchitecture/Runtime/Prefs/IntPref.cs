using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Prefs/IntPref")]
public class IntPref : ScriptablePref<int>
{
    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;
    
    public float MinValue => minValue;
    public float MaxValue => maxValue;

    protected override void Save() => PlayerPrefs.SetInt(prefID, Mathf.Clamp(Value, minValue, maxValue));
    protected override int LoadValue() => PlayerPrefs.GetInt(prefID);
}
}