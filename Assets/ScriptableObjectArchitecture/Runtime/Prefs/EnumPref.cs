using System;
using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Prefs/EnumPref")]
public class EnumPref : ScriptablePref<string>
{
    [SerializeField] private string typeName;
    public Type Type;
    protected override void Save() => PlayerPrefs.SetString(prefID, Value);
    protected override string LoadValue() => PlayerPrefs.GetString(prefID);

    public static implicit operator Enum (EnumPref ep) => (Enum) Enum.Parse(ep.Type, ep.Value);
}
}