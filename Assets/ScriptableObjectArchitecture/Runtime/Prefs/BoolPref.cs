using System;
using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Prefs/BoolPref")]
public class BoolPref : ScriptablePref<bool>
{
    protected override void Save() => PlayerPrefs.SetString(prefID, Value.ToString());

    protected override bool LoadValue() => Boolean.Parse(PlayerPrefs.GetString(prefID));
}
}